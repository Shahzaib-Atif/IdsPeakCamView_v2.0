using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class AccessoryRepository
    {
        private readonly string AccessoriesTable = "REG_AccessoriesSamples";
        private readonly string AccessoryTypesTable = "AccessoryTypes";

        public async Task<bool> SaveAccessoryDetails(string imagePath, AccessoryDetails _accessoryDetails)
        {
            // is image valid?
            //if (!IsImagePathValid(imagePath)) return false;

            var parameters = new Dictionary<string, object>
            {
                {"@tipo", _accessoryDetails.Tipo},
                {"@connectorName", _accessoryDetails.ConnectorName },
                {"@imagePath", imagePath },
                {"@reference", _accessoryDetails.Reference },
            };

            // Construct the SQL INSERT query
            string query = $@"
            INSERT INTO {AccessoriesTable} 
            ([AccessoryType], [ConnName], [AccImagePath], [RefClient])
            VALUES 
            (@tipo, @connectorName, @imagePath, @reference);";

            int rowsAffected = await DbHelper.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }

        // Reads available accessory types from the database and returns them as a list of strings.
        public async Task<IEnumerable<string>> ReadAvailableAccessoryTypes()
        {
            string query = $"SELECT [TypeDescription] FROM [ImageFeaturesDB].[dbo].[{AccessoryTypesTable}]";
            return await DbHelper.ExecuteQueryAsync(query);
        }
    }
}
