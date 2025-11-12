using ImageProcessingLibrary.Models;
using static ImageProcessingLibrary.Services.Database.DbHelper;

namespace ImageProcessingLibrary.Services.Database
{
    public class InsertHandler
    {
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
