using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using static ImageProcessingLibrary.Services.Database.DbHelper;

namespace ImageProcessingLibrary.Services.Database
{
    public class DatabaseManager
    {
        /// <summary> Inserts new position data into the appropriate country-specific table.</summary>
        public static async Task<bool> InsertNewPosID(NewPositionCoordinates newPosition)
        {
            string Vert_Column, Horiz_Column;
            var username = Environment.UserName ?? "";
            var lastChangeDate = DateTime.Now;

            var parameters = new Dictionary<string, object>
            {
                {"@posId", newPosition.PosId},
                {"@CV", newPosition.CV },
                {"@CH", newPosition.CH },
                {"@section", newPosition.SampleSection },
                {"@user", username },
                {"@lastChangeDate", lastChangeDate },
            };

            // select CV,CH OR CV_Ma,CH_Ma based on the Country
            switch (newPosition.Country)
            {
                case "Portugal":
                    Vert_Column = "[CV]"; Horiz_Column = "[CH]";
                    break;
                case "Morocco":
                    Vert_Column = "[CV_Ma]"; Horiz_Column = "[CH_Ma]";
                    break;
                default:
                    ExceptionHelper.ShowWarningMessage("Error: Unknown country selected!");
                    return false;
            }

            // Check if the combination of CV and CH already exists
            bool isAlreadyExist = await IsCoordinatesAlreadyExistsAsync(newPosition.CV, newPosition.CH, Vert_Column, Horiz_Column);
            if (isAlreadyExist)
            {
                ExceptionHelper.ShowWarningMessage("Error: Duplicate CV and CH combination.");
                return false;
            }

            // Construct the SQL INSERT query
            string query = $@"
            INSERT INTO {CordCONTable} 
            ([CON], {Vert_Column}, {Horiz_Column}, [SampleSection], [LastChangeBy], [LastChangeDate], [ESTADO])
            VALUES 
            (@posId, @CV, @CH, @section, @user, @lastChangeDate, 1);";

            int rowsAffected = await DbHelper.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }

        /// <summary> Returns true if the combination of CV and CH already exists. </summary>
        private static async Task<bool> IsCoordinatesAlreadyExistsAsync(string CV, string CH, string vert_Column, string horiz_Column)
        {
            // Check if the combination of CV and CH already exists
            string query = $@"
            SELECT COUNT(*) FROM {CordCONTable} 
            WHERE {vert_Column} = @CV AND {horiz_Column} = @CH;";

            var parameters = new Dictionary<string, object>
            {
                {"@CV", CV },
                {"@CH", CH },
            };

            string existingCount = await DbHelper.ExecuteScalarAsync(query, parameters);

            // return true if count>0
            var count = int.Parse(existingCount);
            return count > 0;
        }

        /// <summary> Check if this PosId already exists. Return true if it exists. </summary>
        public static async Task<bool> CheckIfPosIdExists(string posId)
        {
            var parameters = new Dictionary<string, object>
                {
                    { "@PosId", posId }
                };


            // find a match in Cord_CON table
            string query1 = $"SELECT TOP (1) [CON] FROM [ImageFeaturesDB].[dbo].{CordCONTable} WHERE [CON] = @PosId";
            string result1 = await DbHelper.ExecuteScalarAsync(query1, parameters);

            //return true if a match is found, otherwise false
            return !string.IsNullOrWhiteSpace(result1);
        }


        #region -- SampleDetailsForm related functions

        // Reads available cores from the database and returns them as a list of strings.
        public static async Task<IEnumerable<KeyValue>> ReadAvailableTipo()
        {
            try
            {
                string query = "SELECT [Type], [Section] FROM [ImageFeaturesDB].[dbo].[ConnectorTypes]";
                return await DbHelper.ExecuteQueryAsyncTwoCols(query);
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage($"Database Error: {ex.Message}");
                return Enumerable.Empty<KeyValue>();
            }
        }

        // Reads available Vias from the database and returns them as a list of strings.
        public static async Task<IEnumerable<KeyValue>> ReadAvailableVias()
        {
            //string query = "SELECT [ContagemVias] FROM [ImageFeaturesDB].[dbo].[ContagemNumVias]";
            //return await DbHelper.ExecuteQueryAsync(query);

            string query = "SELECT  [QtdVias], [ContagemVias] FROM [ImageFeaturesDB].[dbo].[ContagemNumVias]";
            return await DbHelper.ExecuteQueryAsyncTwoCols(query);
        }

        // Reads available cores from the database and returns them as a list of strings.
        public static async Task<IEnumerable<KeyValue>> ReadAvailableCors()
        {
            //string query = "SELECT [Cor Id] FROM [ImageFeaturesDB].[dbo].[Cores]";
            //return await DbHelper.ExecuteQueryAsync(query);

            string query = "SELECT [Cores_UK], [Cor Id] FROM [ImageFeaturesDB].[dbo].[Cores]";
            return await DbHelper.ExecuteQueryAsyncTwoCols(query);
        }

        // Method to get the CON entry with the least highest number based on alphabet prefixes
        public static async Task<string> GetLeastHighestConAsync(string section)
        {
            // SQL query to find the CON entry with the least highest numeric suffix
            string query = @$"
                WITH MaxValues AS (
                -- Select the alphabet and the maximum numeric value for each alphabet
                SELECT 
                    LEFT(CON, 1) AS Alphabet, -- Get the first character (alphabet) 
                    MAX(CAST(SUBSTRING(CON, 2, LEN(CON) - 1) AS INT)) AS MaxValue -- Get the maximum numeric suffix as integer
                FROM 
                    [ImageFeaturesDB].[dbo].{CordCONTable}
                    WHERE SampleSection LIKE '{section}%'
                    AND LEFT(CON,1) != 'X' AND LEFT(CON,1) != 'Y' AND LEFT(CON,1) != 'Z'
                GROUP BY 
                    LEFT(CON, 1) -- Group by the alphabet
                )

                -- Select the actual CON entry that corresponds to the alphabet with the least highest number
                SELECT TOP 1 
                    c.CON
                FROM 
                    MaxValues mv -- CTE with maximum values
                JOIN 
                    [ImageFeaturesDB].[dbo].{CordCONTable} c ON 
                    LEFT(c.CON, 1) = mv.Alphabet AND  -- Match the alphabet
                    CAST(SUBSTRING(c.CON, 2, LEN(c.CON) - 1) AS INT) = mv.MaxValue -- Match the maximum numeric value
                ORDER BY 
                    mv.MaxValue ASC;  -- Order by MaxValue to get the alphabet with the least highest number
            ";

            // Execute the query and return the result
            return await DbHelper.ExecuteScalarAsync(query);
        }

        #endregion

        public static async Task<IEnumerable<string>> ReadAvailableSampleSection()
        {
            string query = "SELECT DISTINCT [Section] FROM [ImageFeaturesDB].[dbo].[ConnectorTypes]";
            return await DbHelper.ExecuteQueryAsync(query);
        }




    }
}
