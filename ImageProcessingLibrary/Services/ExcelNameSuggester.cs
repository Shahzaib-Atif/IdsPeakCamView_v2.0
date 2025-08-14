using ImageProcessingLibrary.Helpers;
using OfficeOpenXml;

namespace ImageProcessingLibrary.Services
{
    public class ExcelNameSuggester
    {
        private static string ExcelFilePath { get; set; } = string.Empty;

        public static string Start()
        {
            // Prompt user to select an Excel file if no path is already set
            //if (string.IsNullOrWhiteSpace(ExcelFilePath))
            SelectExcelFile();

            if (string.IsNullOrWhiteSpace(ExcelFilePath))
                return string.Empty;

            try
            {
                // Ensure the license is accepted for non-commercial use
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Load the first worksheet
                using var package = new ExcelPackage(new FileInfo(ExcelFilePath));
                using var worksheet = package.Workbook.Worksheets[0];

                if (worksheet is null)
                {
                    MessageBox.Show("Worksheet not found in the Excel file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }

                return SuggestNameFromWorksheet(worksheet);
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
                return string.Empty;
            }
        }


        /// <summary>
        /// If obsolete row is found, return the name from that row.
        /// If no obsolete row is found, find the last non-empty row and suggest the next available name.
        /// </summary>
        private static string SuggestNameFromWorksheet(ExcelWorksheet worksheet)
        {
            int rowNumber = FindFirstObsoleteRow(worksheet, 9);
            if (rowNumber > 1)
                return GetCellValue(worksheet, rowNumber, 3);
            else
            {
                rowNumber = FindLastNonEmptyRow(worksheet, 3);
                string lastNonEmptyCellValue = GetCellValue(worksheet, rowNumber, 3);
                return SuggestNextAvailableName(lastNonEmptyCellValue);
            }
        }

        // suggest next available name based on this cell value
        private static string SuggestNextAvailableName(string lastCellValue)
        {
            if (string.IsNullOrWhiteSpace(lastCellValue))
            {
                ExceptionHelper.ShowWarningMessage("SuggestNextAvailableName: input string is empty or null!");
                return string.Empty;
            }

            // Extract the alphabetic prefix and numeric suffix.
            string prefix = new(lastCellValue.TakeWhile(char.IsLetter).ToArray());
            string numberPart = new(lastCellValue.SkipWhile(char.IsLetter).ToArray());

            if (int.TryParse(numberPart, out int num))
            {
                // Increment the numeric part and format it with leading zeros.
                string nextNumber = (num + 1).ToString($"D{numberPart.Length}");
                return $"{prefix}{nextNumber}";
            }

            return string.Empty;
        }

        private static void SelectExcelFile()
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                ExcelFilePath = openFileDialog.FileName;
        }

        // find the last non-empty row and suggest next name
        private static string GetCellValue(ExcelWorksheet worksheet, int rowNumber, int columnIndex)
        {
            if (rowNumber > 0)
                return worksheet.Cells[rowNumber, columnIndex].Text;
            else
                return string.Empty;
        }

        // try to find last non-empty row number            
        private static int FindLastNonEmptyRow(ExcelWorksheet worksheet, int columnIndex)
        {
            int lastRowNum = worksheet.Dimension.End.Row;
            while (lastRowNum > 0 && worksheet.Cells[lastRowNum, columnIndex].Text == "")
                lastRowNum--;
            return lastRowNum;
        }

        /// <summary>
        /// try to find the first row with observacao = obsoleto   
        /// return 1 if no matching value (obsoleto) found
        /// </summary>
        private static int FindFirstObsoleteRow(ExcelWorksheet worksheet, int columnIndex)
        {
            string obsoleto = "obsoleto";
            int lastNonEmptyRow = FindLastNonEmptyRow(worksheet, columnIndex);
            int firstObsoleteRow = 1; // start from 1 (which is the headers row)
            while (firstObsoleteRow < lastNonEmptyRow && worksheet.Cells[firstObsoleteRow, columnIndex].Text.Trim() != obsoleto)
                firstObsoleteRow++;
            return firstObsoleteRow;
        }
    }
}
