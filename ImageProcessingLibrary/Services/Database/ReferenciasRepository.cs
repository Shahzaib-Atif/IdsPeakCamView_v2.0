using ImageProcessingLibrary.Models;
using System.Data.SqlClient;

namespace ImageProcessingLibrary.Services.Database
{
    public class ReferenciasRepository

    {
        //public static readonly string MainReferenceTable = "Referências_test";
        //public static readonly string MainReferenceTable = "Referências";
        public static readonly string MainReferenceTable = "Connectors_Main";
        private static readonly string DetailsTable = "Connectors_Details";
        private static readonly string DimensionsTable = "Connectors_Dimensions";
        private static readonly string ComponentsTable = "Connectors_Comps";

        public async Task InsertNewConnector(string imagePath, SampleDetail sampleDetails)
        {
            using var conn = new SqlConnection(ProjectSettings.DbConnectionString);
            await conn.OpenAsync();

            using var tx = conn.BeginTransaction();

            try
            {
                // main query
                string mainQuery = @$"
                INSERT INTO {MainReferenceTable} 
                (PosId, Cor, Vias, CODIVMAC, Qty, ESTADO, Imagem, ConnType, LastChangeBy, LastUpdateDate)
                OUTPUT INSERTED.CODIVMAC
                VALUES 
                (@PosId, @Cor, @Vias, @Codivmac, @Qty, @ESTADO, @Imagem, @ConnType, @LastChangeBy, @LastUpdateDate)";

                var basicDetails = sampleDetails.BasicDetails;
                var parameters = new Dictionary<string, object>
                {
                    {"@posId", basicDetails.PosId },
                    {"@Cor", basicDetails.Cor },
                    {"@Vias", basicDetails.Vias },
                    {"@CODIVMAC", basicDetails.Codivmac },
                    {"@Qty", basicDetails.Qty },
                    {"@ESTADO", 1 },
                    {"@Imagem", imagePath },
                    {"@ConnType", basicDetails.Tipo},
                    {"@LastChangeBy", Environment.UserName?.ToUpper() ?? (object)DBNull.Value},
                    {"@LastUpdateDate", DateTime.Now},
                };
                using var mainCommand = new SqlCommand(mainQuery, conn, tx);
                foreach (var parameter in parameters)
                    mainCommand.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);

                var insertedId = (string)mainCommand.ExecuteScalar();

                // details query
                string detailsQuery = @$"
                INSERT INTO {DetailsTable} 
                (ConnId, Designação, Fabricante, Refabricante, OBS, ClipColor, CapotAngle, Family)
                VALUES 
                (@ConnId, @Designação, @Fabricante, @Refabricante, @OBS, @ClipColor, @CapotAngle, @Family)";

                var additionalDetails = sampleDetails.AdditionalDetails;
                var detailsParameters = new Dictionary<string, object>
                {
                    {"@ConnId", insertedId },
                    {"@Designação", additionalDetails?.Designação ?? (object)DBNull.Value},
                    {"@Fabricante", additionalDetails?.Fabricante ?? (object)DBNull.Value},
                    {"@Refabricante", additionalDetails?.Refabricante ?? (object)DBNull.Value},
                    {"@OBS", additionalDetails?.OBS ?? (object)DBNull.Value},
                    {"@ClipColor", additionalDetails?.ClipColor ?? (object)DBNull.Value},
                    {"@CapotAngle", additionalDetails?.CapotAngle ?? (object)DBNull.Value},
                    {"@Family", additionalDetails?.Family ?? 1},
                };
                using var detailsCommand = new SqlCommand(detailsQuery, conn, tx);
                foreach (var parameter in detailsParameters)
                    detailsCommand.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                detailsCommand.ExecuteNonQuery();

                // dimensions query
                string dimensionQuery = @$"
                INSERT INTO {DimensionsTable} 
                (ConnId,InternalDiameter,ExternalDiameter,Thickness)
                VALUES 
                (@ConnId, @InternalDiameter, @ExternalDiameter, @Thickness)";

                var dimensions = sampleDetails.Dimensions;
                var dimensionParameters = new Dictionary<string, object>
                {
                    {"@ConnId", insertedId },
                    {"@InternalDiameter", dimensions.InternalDiameter ?? (object)DBNull.Value},
                    {"@ExternalDiameter", dimensions.ExternalDiameter?? (object)DBNull.Value},
                    {"@Thickness", dimensions.Thickness?? (object)DBNull.Value },
                };
                using var dimensionCommand = new SqlCommand(dimensionQuery, conn, tx);
                foreach (var parameter in dimensionParameters)
                    dimensionCommand.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                dimensionCommand.ExecuteNonQuery();

                // components query
                string compsQuery = @$"
                INSERT INTO {ComponentsTable} 
                (ConnId,Clip,Spacer,Vedante,Tampa,Mola,Moldagem,Travão,Abracadeira,Linguetes,Outros,Amostra,Olhal)
                VALUES 
                (@ConnId,@Clip,@Spacer,@Vedante,@Tampa,@Mola,@Moldagem,@Travão,@Abracadeira,@Linguetes,@Outros,@Amostra,@Olhal)";

                var componentDetails = sampleDetails.ComponentsDetails;
                var compsParameters = new Dictionary<string, object>
                {
                    {"@ConnId", insertedId },
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
                };
                using var compsCommand = new SqlCommand(compsQuery, conn, tx);
                foreach (var parameter in compsParameters)
                    compsCommand.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                await compsCommand.ExecuteNonQueryAsync();

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
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

        // Read available PosId from the database and return them as a list of strings.
        public async Task<IEnumerable<string>> ReadAvailablePosId()
        {
            string query = $"SELECT PosId FROM [ImageFeaturesDB].[dbo].{MainReferenceTable}";
            return await DbHelper.ExecuteQueryAsync(query);
        }
    }
}
