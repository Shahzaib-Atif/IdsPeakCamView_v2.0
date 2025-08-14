using Emgu.CV;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using System.Data.SqlClient;
using static ImageProcessingLibrary.Services.Database.DatabaseManager;
using static ImageProcessingLibrary.Services.SerializationHandler;

namespace ImageProcessingLibrary.Services.Database
{
    internal class ReadHandler
    {
        /// <summary>
        /// Reads image data and deserializes features into the results list.
        /// </summary>
        internal static List<ExtractedImageFeatures> Start(SampleDetail sampleDetails)
        {
            // open a new connection
            using var connection = new SqlConnection(ProjectSettings.DbConnectionString);
            connection.Open();

            var results = new List<ExtractedImageFeatures>();

            var command = BuildSearchCommand(sampleDetails, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    var result = new ExtractedImageFeatures
                    {
                        CodivmacRef = (string)reader["CodivmacRef"]
                    };

                    // Deserialize the histogram
                    if (reader["Histogram"] is not DBNull)
                    {
                        byte[] histBytes = (byte[])reader["Histogram"];
                        float[]? histData = DeserializeObject<float[]>(histBytes);
                        if (histData is not null)
                        {
                            Mat histogram = new(histData.Length, 1, Emgu.CV.CvEnum.DepthType.Cv32F, 1);
                            histogram.SetTo(histData);
                            result.Histogram = histogram;
                        }
                    }
                    else
                        continue; // goto the next record

                    // Deserialize the hash
                    if (reader["Hash"] is not DBNull)
                    {
                        byte[] hashBytes = (byte[])reader["Hash"];
                        result.Hash = DeserializeObject<List<bool>>(hashBytes);
                    }
                    else
                        continue; // goto the next record

                    // ORB
                    byte[] keyPointsBytes = (byte[])reader["ORBKeyPoints"];
                    byte[] descriptorBytes = (byte[])reader["ORBDescriptors"];
                    result.OrbDetectorFeatures = GetDeserializedDetectorFeatures(keyPointsBytes, descriptorBytes);

                    // Akaze
                    keyPointsBytes = (byte[])reader["AkazeKeyPoints"];
                    descriptorBytes = (byte[])reader["AkazeDescriptors"];
                    result.AkazeDetectorFeatures = GetDeserializedDetectorFeatures(keyPointsBytes, descriptorBytes, 61);

                    // Fast feature
                    keyPointsBytes = (byte[])reader["FastKeyPoints"];
                    descriptorBytes = (byte[])reader["FastDescriptors"];
                    result.FastDetectorFeatures = GetDeserializedDetectorFeatures(keyPointsBytes, descriptorBytes);

                    // GFTT
                    keyPointsBytes = (byte[])reader["GFTTKeyPoints"];
                    descriptorBytes = (byte[])reader["GFTTDescriptors"];
                    result.GfttDetectorFeatures = GetDeserializedDetectorFeatures(keyPointsBytes, descriptorBytes);

                    // Add the result to the list
                    results.Add(result);
                }
                catch
                {
                    ExceptionHelper.DisplayErrorMessage($"Error occured while reading: {sampleDetails.BasicDetails.PosId}");
                    continue; // goto the next record
                }
            }
            return results;
        }

        private static SqlCommand BuildSearchCommand(SampleDetail sampleDetails, SqlConnection connection)
        {
            //string searchQuery =
            //    "SELECT * FROM ImageRoot" +
            //    " INNER JOIN ImageDescription ON ImageRoot.Id = ImageDescription.ImageRootId" +
            //    " INNER JOIN ImageFeatures ON ImageRoot.Id = ImageFeatures.ImageRootId";    
            string searchQuery =
                $"SELECT * FROM [ImageFeaturesDB].[dbo].[{MainReferenceTable}] " +
                $"INNER JOIN {ImageFeaturesTable} ON {MainReferenceTable}.CODIVMAC = {ImageFeaturesTable}.CodivmacRef";

            List<string> conditions = new();
            var command = new SqlCommand();

            var basicDetails = sampleDetails.BasicDetails;
            var dimensions = sampleDetails.Dimensions;

            // Add conditions dynamically
            if (!string.IsNullOrWhiteSpace(basicDetails.PosId))
            {
                conditions.Add("[Pos ID] LIKE @posId");
                command.Parameters.AddWithValue("@posId", "%" + basicDetails.PosId + "%");
            }

            if (!string.IsNullOrWhiteSpace(basicDetails.Vias))
            {
                conditions.Add("Vias = @Vias");
                command.Parameters.AddWithValue("@Vias", basicDetails.Vias);
            }

            if (!string.IsNullOrWhiteSpace(basicDetails.Tipo))
            {
                conditions.Add("ConnType = @Tipo");
                command.Parameters.AddWithValue("@Tipo", basicDetails.Tipo);
            }

            if (!string.IsNullOrWhiteSpace(basicDetails.Cor))
            {
                conditions.Add("Cor = @Cor");
                command.Parameters.AddWithValue("@Cor", basicDetails.Cor);
            }

            if (dimensions.InternalDiameter is not null)
            {
                conditions.Add("InternalDiameter = @InternalDiameter");
                command.Parameters.AddWithValue("@InternalDiameter", dimensions.InternalDiameter);
            }

            if (dimensions.ExternalDiameter is not null)
            {
                conditions.Add("ExternalDiameter = @ExternalDiameter");
                command.Parameters.AddWithValue("@ExternalDiameter", dimensions.ExternalDiameter);
            }

            if (dimensions.Thickness is not null)
            {
                conditions.Add("Thickness = @Thickness");
                command.Parameters.AddWithValue("@Thickness", dimensions.Thickness);
            }

            // Add conditions to the query
            if (conditions.Any())
            {
                searchQuery += " WHERE " + string.Join(" AND ", conditions);
            }

            command.CommandText = searchQuery;
            command.Connection = connection;

            return command;
        }

    }
}
