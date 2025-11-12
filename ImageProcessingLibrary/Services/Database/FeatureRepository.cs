using ImageProcessingLibrary.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ImageProcessingLibrary.Services.Database
{
    public class FeatureRepository
    {
        private readonly string _tableName = "ConnectorFeatures";

        public async Task UpdateFeatures(string name, float[] vector1, float[] vector2)
        {
            string resnetJsonVector = JsonConvert.SerializeObject(vector1);
            string dinov2JsonVector = JsonConvert.SerializeObject(vector2);

            string query = $"UPDATE {_tableName} " +
                "SET ResnetVector=@ResnetVector, Dinov2Vector=@Dinov2Vector " +
                "WHERE CodivmacRef=@CodivmacRef";

            var parameters = new Dictionary<string, object>
                {
                    { "@CodivmacRef", name },
                    { "@ResnetVector", resnetJsonVector },
                    { "@Dinov2Vector", dinov2JsonVector }
                };

            await DbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        public async Task SaveFeatures(string name, float[] vector1, float[] vector2)
        {
            string resnetJsonVector = JsonConvert.SerializeObject(vector1);
            string dinov2JsonVector = JsonConvert.SerializeObject(vector2);

            string query = $@"
                        IF EXISTS (SELECT 1 FROM {_tableName} WHERE CodivmacRef = @CodivmacRef)
                            UPDATE {_tableName}
                            SET ResnetVector = @ResnetVector,
                                Dinov2Vector = @Dinov2Vector
                        WHERE CodivmacRef = @CodivmacRef
                        ELSE
                            INSERT INTO {_tableName} (CodivmacRef, ResnetVector, Dinov2Vector)
                            VALUES (@CodivmacRef, @ResnetVector, @Dinov2Vector);
                        ";

            var parameters = new Dictionary<string, object>
                {
                    { "@CodivmacRef", name },
                    { "@ResnetVector", resnetJsonVector },
                    { "@Dinov2Vector", dinov2JsonVector }
                };

            await DbHelper.ExecuteNonQueryAsync(query, parameters);
        }


        // Delete existing record from features table
        public async Task DeleteFromFeaturesTableAsync(string codivmacRef)
        {
            string query = $"DELETE FROM [ImageFeaturesDB].[dbo].[{_tableName}] WHERE CodivmacRef = @codivmacRef";
            var parameters = new Dictionary<string, object>
                {
                    { "@codivmacRef", codivmacRef }
                };

            await DbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        public List<ConnectorFeature> LoadAllVectors()
        {
            var result = new List<ConnectorFeature>();

            using (SqlConnection conn = new(ProjectSettings.DbConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT Id, CodivmacRef, ResnetVector, Dinov2Vector FROM {_tableName}" +
                        $" WHERE ResnetVector IS NOT NULL";
                    using SqlCommand cmd = new(query, conn);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var vectorJson1 = reader.GetString(2);
                        var vectorJson2 = reader.GetString(3);

                        // Ensure deserialization does not result in null values  
                        var resnetVector = JsonConvert.DeserializeObject<float[]>(vectorJson1) ?? Array.Empty<float>();
                        var dinov2Vector = JsonConvert.DeserializeObject<float[]>(vectorJson2) ?? Array.Empty<float>();

                        result.Add(new ConnectorFeature
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ResnetVector = resnetVector,
                            Dinov2Vector = dinov2Vector
                        });
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Database error: " + e.Message);
                }
            }

            return result;
        }
    }
}
