using ImageProcessingLibrary.Models;
using System.Data.SqlClient;
using static ImageProcessingLibrary.ProjectSettings;
using static ImageProcessingLibrary.Services.Database.DatabaseManager;

namespace ImageProcessingLibrary.Services.Database
{
    internal class InsertHandler
    {
        // Insert image features in the DB
        internal static async Task<bool> AddNewImageDataAsync(string imagePath, ImageFeaturesStruct features, SampleDetail sampleDetails)
        {
            // open connection
            using var connection = new SqlConnection(DbConnectionString);
            await connection.OpenAsync();

            // insert data in main table
            bool referenceInserted = await InsertReferenceDataAsync(imagePath, sampleDetails);
            if (!referenceInserted) return false;


            // insert data in image features table
            string codivmac = sampleDetails.BasicDetails.Codivmac;
            await DeleteFromFeaturesTableAsync(codivmac); // Remove existing features with same codivmacRef
            return await InsertImageFeaturesAsync(codivmac, features); // add new features
        }


        /// <summary> Inserts basic reference data into the database. </summary>
        private static async Task<bool> InsertReferenceDataAsync(string imagePath, SampleDetail sampleDetails)
        {
            // include tipo
            string query = @$"
                INSERT INTO [ImageFeaturesDB].[dbo].[{MainReferenceTable}] 
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


        /// <summary> Inserts extracted image features into the database. </summary>       
        private static async Task<bool> InsertImageFeaturesAsync(string codivmacRef, ImageFeaturesStruct features)
        {
            string query = $@"
                INSERT INTO {ImageFeaturesTable} 
                (CodivmacRef, Histogram, Hash, ORBKeyPoints, ORBDescriptors, AkazeKeyPoints, AkazeDescriptors, 
                FastKeyPoints, FastDescriptors, GFTTKeyPoints, GFTTDescriptors) 
                VALUES 
                (@CodivmacRef, @Histogram, @Hash, @ORBKeyPoints, @ORBDescriptors, @AkazeKeyPoints, @AkazeDescriptors, 
                @FastKeyPoints, @FastDescriptors, @GFTTKeyPoints, @GFTTDescriptors);";

            var parameters = new Dictionary<string, object>
            {
                {"@CodivmacRef", codivmacRef},
                {"@Histogram", features.Histogram ?? (object)DBNull.Value},
                {"@Hash", features.Hash ?? (object)DBNull.Value},
                {"@ORBKeyPoints", features.ORBKeyPoints ?? (object)DBNull.Value},
                {"@ORBDescriptors", features.ORBDescriptors ?? (object)DBNull.Value},
                {"@AkazeKeyPoints", features.AkazeKeyPoints ?? (object)DBNull.Value},
                {"@AkazeDescriptors", features.AkazeDescriptors ?? (object)DBNull.Value},
                {"@FastKeyPoints", features.FastKeyPoints ?? (object)DBNull.Value},
                {"@FastDescriptors", features.FastDescriptors ?? (object)DBNull.Value},
                {"@GFTTKeyPoints", features.GFTTKeyPoints ?? (object)DBNull.Value},
                {"@GFTTDescriptors", features.GFTTDescriptors ?? (object)DBNull.Value},
            };

            int rowsAffected = await DbHelper.ExecuteNonQueryAsync(query, parameters);
            return (rowsAffected > 0);
        }


        #region -- OBSOLETE FUNCTIONS
        /*
        // insert sample details
        private static void InsertSampleDetails(SqlConnection connection, int imageRootId, SampleDetail sampleDetails)
        {
            using var command = new SqlCommand(@"
                INSERT INTO ImageDescription
                (ImageRootId, Vias, Tipo, Cor, InternalDiameter, ExternalDiameter, Thickness)
                VALUES
                (@ImageRootId, @Vias, @Tipo, @Cor, @InternalDiameter, @ExternalDiameter, @Thickness);
                ", connection);

            var basicDetails = sampleDetails.BasicDetails;
            var dimensions = sampleDetails.Dimensions;

            command.Parameters.AddWithValue("@ImageRootId", imageRootId);
            command.Parameters.AddWithValue("@Vias", basicDetails.Vias ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Tipo", basicDetails.Tipo);
            command.Parameters.AddWithValue("@Cor", basicDetails.Cor ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@InternalDiameter", dimensions.InternalDiameter ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ExternalDiameter", dimensions.ExternalDiameter ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Thickness", dimensions.Thickness ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }
        */
        #endregion
    }
}
