using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class AccessoryRepository
    {
        private readonly string AccessoriesTable = "REG_AccessoriesSamples";
        private readonly string AccessoryTypesTable = "AccessoryTypes";

        public async Task<bool> SaveAccessoryDetails(string imagePath, AccessoryDetails _accessoryDetails)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@tipo", _accessoryDetails.Tipo},
                {"@CapotAngle", _accessoryDetails.CapotAngle ?? (object)DBNull.Value},
                {"@ClipColor", _accessoryDetails.ClipColor ?? (object)DBNull.Value},
                {"@connectorName", _accessoryDetails.ConnectorName },
                {"@imagePath", imagePath },
                {"@reference", _accessoryDetails.Reference },
                {"@Qty", _accessoryDetails.Quantity },
                {"@RefDV", _accessoryDetails.RefDV },
                {"@ColorAssociated", _accessoryDetails.ColorAssociated },
            };

            // Construct the SQL INSERT query
            string query = $@"
            INSERT INTO {AccessoriesTable} 
            ([AccessoryType], CapotAngle, ClipColor, [ConnName], [AccImagePath], [RefClient], Qty, RefDV, ColorAssociated)
            VALUES 
            (@tipo, @CapotAngle, @ClipColor, @connectorName, @imagePath, @reference, @Qty, @RefDV, @ColorAssociated);";

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
