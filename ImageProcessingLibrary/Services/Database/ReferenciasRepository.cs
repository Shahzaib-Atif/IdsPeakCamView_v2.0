using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class ReferenciasRepository

    {
        //public static readonly string MainReferenceTable = "Referências_test";
        public static readonly string MainReferenceTable = "Referências";

        /// <summary> Inserts basic reference data into the database. </summary>
        public async Task<bool> InsertDataAsync(string imagePath, SampleDetail sampleDetails)
        {
            // include tipo
            string query = @$"
                INSERT INTO [ImageFeaturesDB].[dbo].[{MainReferenceTable}] 
                ([Pos ID], Cor, Vias, CODIVMAC, ESTADO, ConnType, InternalDiameter, ExternalDiameter, Thickness, Imagem,
                Fabricante, Refabricante, Designação, OBS,
                [Clip] ,[Spacer] ,[Vedante] ,[Tampa] ,[Mola] ,[Moldagem] ,[Travão] ,[Abracadeira] ,[Linguetes] ,[Outros] ,[Amostra], [Olhal],
                LastChangeBy, LastUpdateDate)
                VALUES 
                (@PosId, @Cor, @Vias, @Codivmac, 1, @ConnType, @InternalDiameter, @ExternalDiameter, @Thickness, @ImagePath,
                @Fabricante,@Refabricante,@Designação,@OBS,
                @Clip, @Spacer, @Vedante, @Tampa, @Mola, @Moldagem, @Travão, @Abracadeira, @Linguetes, @Outros, @Amostra, @Olhal,
                @LastChangeBy, @LastUpdateDate);";

            var basicDetails = sampleDetails.BasicDetails;
            var dimensions = sampleDetails.Dimensions;
            var additionalDetails = sampleDetails.AdditionalDetails;
            var componentDetails = sampleDetails.ComponentsDetails;

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

                {"@Fabricante", additionalDetails?.Fabricante ?? (object)DBNull.Value},
                {"@Refabricante", additionalDetails?.Refabricante ?? (object)DBNull.Value},
                {"@Designação", additionalDetails?.Designação ?? (object)DBNull.Value},
                {"@OBS", additionalDetails?.OBS ?? (object)DBNull.Value},

                {"@Clip", componentDetails?.Clip == true ? 1 : 0},
                {"@Spacer", componentDetails?.Spacer == true ? 1 : 0 },
                { "@Vedante", componentDetails?.Vedante == true ? 1 : 0 },
                { "@Tampa", componentDetails?.Tampa == true ? 1 : 0 },
                { "@Mola", componentDetails?.Mola == true ? 1 : 0 },
                { "@Moldagem", componentDetails?.Moldagem == true ? 1 : 0 },
                { "@Travão", componentDetails?.Travão == true ? 1 : 0 },
                { "@Abracadeira", componentDetails?.Abracadeira == true ? 1 : 0 },
                { "@Linguetes", componentDetails?.Linguetes == true ? 1 : 0 },
                { "@Outros", componentDetails?.Outros == true ? 1 : 0 },
                { "@Amostra", componentDetails?.Amostra == true ? 1 : 0 },
                { "@Olhal", componentDetails?.Olhal == true ? 1 : 0 },

                {"@LastChangeBy", Environment.UserName?.ToUpper() ?? (object)DBNull.Value},
                {"@LastUpdateDate", DateTime.Now},
            };

            int rowsAffected = await DbHelper.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }

        // Delete existing record from main referencias table
        public async Task DeleteDataAsync(string fileName)
        {
            string query = $"DELETE FROM [ImageFeaturesDB].[dbo].[{MainReferenceTable}] WHERE CODIVMAC = @Name";
            var parameters = new Dictionary<string, object>
                {
                    { "@Name", fileName }
                };

            await DbHelper.ExecuteNonQueryAsync(query, parameters);
        }

        // Read available Codivmac from the database and return them as a list of strings.
        public async Task<IEnumerable<string>> ReadAvailableCodivmac()
        {
            string query = $"SELECT [CODIVMAC] FROM [ImageFeaturesDB].[dbo].{MainReferenceTable}";
            return await DbHelper.ExecuteQueryAsync(query);
        }

        // Read available [Pos Id] from the database and return them as a list of strings.
        public async Task<IEnumerable<string>> ReadAvailablePosId()
        {
            string query = $"SELECT [Pos ID] FROM [ImageFeaturesDB].[dbo].{MainReferenceTable}";
            return await DbHelper.ExecuteQueryAsync(query);
        }
    }
}
