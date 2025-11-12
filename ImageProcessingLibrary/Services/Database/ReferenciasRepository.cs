using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class ReferenciasRepository

    {
        private readonly string _tableName = "Referências_test";

        /// <summary> Inserts basic reference data into the database. </summary>
        public async Task<bool> InsertDataAsync(string imagePath, SampleDetail sampleDetails)
        {
            // include tipo
            string query = @$"
                INSERT INTO [ImageFeaturesDB].[dbo].[{_tableName}] 
                ([Pos ID], Cor, Vias, CODIVMAC, ESTADO, ConnType, InternalDiameter, ExternalDiameter, Thickness, Imagem,
                [Clip] ,[Spacer] ,[Vedante] ,[Tampa] ,[Mola] ,[Moldagem] ,[Travão] ,[Abracadeira] ,[Linguetes] ,[Outros] ,[Amostra])
                VALUES 
                (@PosId, @Cor, @Vias, @Codivmac, 1, @ConnType, @InternalDiameter, @ExternalDiameter, @Thickness, @ImagePath,
                0,0,0,0,0,0,0,0,0,0,0);";

            var basicDetails = sampleDetails.BasicDetails;
            var dimensions = sampleDetails.Dimensions;

            var parameters = new Dictionary<string, object>
            {
                {"@posId", basicDetails.PosId },
                {"@Cor", basicDetails.Cor },
                {"@Vias", basicDetails.Vias },
                {"@CODIVMAC", basicDetails.Codivmac },
                {"@ConnType", basicDetails.Tipo},
                {"@InternalDiameter", dimensions.InternalDiameter ?? (object)DBNull.Value},
                {"@ExternalDiameter", dimensions.ExternalDiameter?? (object)DBNull.Value},
                {"@Thickness", dimensions.Thickness?? (object)DBNull.Value },
                {"@ImagePath", imagePath },
            };

            int rowsAffected = await DbHelper.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }

        // Delete existing record from main referencias table
        public async Task DeleteDataAsync(string fileName)
        {
            string query = $"DELETE FROM [ImageFeaturesDB].[dbo].[{_tableName}] WHERE CODIVMAC = @Name";
            var parameters = new Dictionary<string, object>
                {
                    { "@Name", fileName }
                };

            await DbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        // Read available Codivmac from the database and return them as a list of strings.
        public async Task<IEnumerable<string>> ReadAvailableCodivmac()
        {
            string query = $"SELECT [CODIVMAC] FROM [ImageFeaturesDB].[dbo].{_tableName}";
            return await DbHelper.ExecuteQueryAsync(query);
        }

        // Read available [Pos Id] from the database and return them as a list of strings.
        public async Task<IEnumerable<string>> ReadAvailablePosId()
        {
            string query = $"SELECT [Pos ID] FROM [ImageFeaturesDB].[dbo].{_tableName}";
            return await DbHelper.ExecuteQueryAsync(query);
        }
    }
}
