using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class AccessoryRepository
    {
        private readonly string AccessoriesTable = "REG_AccessoriesSamples";
        private readonly string AccessoryTypesTable = "AccessoryTypes";

        public async Task SaveNewAccessory(string imagePath, AccessoryDetails _accessoryDetails)
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

            await DbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        public async Task UpdateAccessory(AccessoryDetails details)
        {
            string query = $@"
                            UPDATE {AccessoriesTable} 
                            SET Qty = Qty + @Qty
                            WHERE ConnName = @connectorName
                            AND RefClient = @reference
                            AND (RefDV = @RefDV OR (RefDV IS NULL AND @RefDV IS NULL))";

            var parameters = new Dictionary<string, object>
            {
                {"@Qty", details.Quantity },
                {"@connectorName", details.ConnectorName },
                {"@reference", details.Reference },
                {"@RefDV", details.RefDV ?? (object)DBNull.Value },
            };

            await DbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        // Reads available accessory types from the database and returns them as a list of strings.
        public async Task<IEnumerable<string>> ReadAvailableAccessoryTypes()
        {
            string query = $"SELECT [TypeDescription] FROM [ImageFeaturesDB].[dbo].[{AccessoryTypesTable}]";
            return await DbHelper.ExecuteQueryAsync(query);
        }

        public async Task<bool> FindExistingRecord(AccessoryDetails details)
        {
            string query = @"
                        SELECT COUNT(*) 
                        FROM ImageFeaturesDB.dbo.REG_AccessoriesSamples
                        WHERE ConnName = @connectorName
                        AND RefClient = @reference
                        AND (RefDV = @RefDV OR (RefDV IS NULL AND @RefDV IS NULL))";

            var parameters = new Dictionary<string, object>
            {
                {"@connectorName", details.ConnectorName },
                {"@reference", details.Reference },
                {"@RefDV", details.RefDV ?? (object)DBNull.Value },
            };

            string existingCount = await DbHelper.ExecuteScalarAsync(query, parameters);

            // return true if count>0
            var count = int.Parse(existingCount);
            return count > 0;
        }
    }
}
