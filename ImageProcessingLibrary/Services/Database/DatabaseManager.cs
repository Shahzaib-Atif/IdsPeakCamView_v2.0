using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class DatabaseManager
    {





        #region -- SampleDetailsForm related functions

        // Reads available cores from the database and returns them as a list of strings.
        public static async Task<IEnumerable<KeyValue>> ReadAvailableTipo()
        {
            try
            {
                string query = "SELECT [Type], [Section] FROM [ImageFeaturesDB].[dbo].[ConnectorTypes]";
                return await DbHelper.ExecuteQueryAsyncTwoCols(query);
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage($"Database Error: {ex.Message}");
                return Enumerable.Empty<KeyValue>();
            }
        }

        // Reads available Vias from the database and returns them as a list of strings.
        public static async Task<IEnumerable<KeyValue>> ReadAvailableVias()
        {
            //string query = "SELECT [ContagemVias] FROM [ImageFeaturesDB].[dbo].[ContagemNumVias]";
            //return await DbHelper.ExecuteQueryAsync(query);

            string query = "SELECT  [QtdVias], [ContagemVias] FROM [ImageFeaturesDB].[dbo].[ContagemNumVias]";
            return await DbHelper.ExecuteQueryAsyncTwoCols(query);
        }

        // Reads available cores from the database and returns them as a list of strings.
        public static async Task<IEnumerable<KeyValue>> ReadAvailableCors()
        {
            //string query = "SELECT [Cor Id] FROM [ImageFeaturesDB].[dbo].[Cores]";
            //return await DbHelper.ExecuteQueryAsync(query);

            string query = "SELECT [Cores_UK], [Cor Id] FROM [ImageFeaturesDB].[dbo].[Cores]";
            return await DbHelper.ExecuteQueryAsyncTwoCols(query);
        }


        #endregion

        public static async Task<IEnumerable<string>> ReadAvailableSampleSection()
        {
            string query = "SELECT DISTINCT [Section] FROM [ImageFeaturesDB].[dbo].[ConnectorTypes]";
            return await DbHelper.ExecuteQueryAsync(query);
        }




    }
}
