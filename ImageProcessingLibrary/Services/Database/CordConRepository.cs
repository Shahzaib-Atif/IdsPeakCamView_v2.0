using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class CordConRepository
    {
        private readonly string CordCONTable = "Cord_CON";

        /// <summary> Check if this PosId already exists. Return true if it exists. </summary>
        public async Task<bool> CheckIfPosIdExists(string posId)
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

        // Method to get the CON entry with the least highest number based on alphabet prefixes
        public async Task<string> GetLeastHighestConAsync(string section)
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

        /// <summary> Inserts new position data into the appropriate country-specific table.</summary>
        public async Task<bool> InsertNewPosID(NewPositionCoordinates newPosition, string vertColumn, string horizColumn)
        {
            var username = Environment.UserName ?? "";
            var lastChangeDate = DateTime.Now;

            // Check if the combination of CV and CH already exists
            bool isAlreadyExist = await IsCoordinatesAlreadyExistsAsync(newPosition.CV, newPosition.CH, vertColumn, horizColumn);
            if (isAlreadyExist)
            {
                ExceptionHelper.ShowWarningMessage("Error: Duplicate CV and CH combination.");
                return false;
            }

            // Construct the SQL INSERT query
            string query = $@"
            INSERT INTO {CordCONTable} 
            ([CON], {vertColumn}, {horizColumn}, [SampleSection], [LastChangeBy], [LastChangeDate], [ESTADO])
            VALUES 
            (@posId, @CV, @CH, @section, @user, @lastChangeDate, 1);";

            // Define the parameters for the query
            var parameters = new Dictionary<string, object>
            {
                {"@posId", newPosition.PosId},
                {"@CV", newPosition.CV },
                {"@CH", newPosition.CH },
                {"@section", newPosition.SampleSection },
                {"@user", username },
                {"@lastChangeDate", lastChangeDate },
            };

            int rowsAffected = await DbHelper.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }


        #region Private Methods
        /// <summary> Returns true if the combination of CV and CH already exists. </summary>
        private async Task<bool> IsCoordinatesAlreadyExistsAsync(string CV, string CH, string vert_Column, string horiz_Column)
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
        #endregion

    }
}
