using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.Database
{
    public class MetadataRepository
    {

        // Reads available cores from the database and returns them as a list of strings.
        public async Task<IEnumerable<KeyValue>> ReadAvailableTipo()
        {
            string query = "SELECT [Type], [Section] FROM [ImageFeaturesDB].[dbo].[ConnectorTypes]";
            return await DbHelper.ExecuteQueryAsyncTwoCols(query);
        }

        // Reads available Vias from the database and returns them as a list of strings.
        public async Task<IEnumerable<KeyValue>> ReadAvailableVias()
        {
            //string query = "SELECT [ContagemVias] FROM [ImageFeaturesDB].[dbo].[ContagemNumVias]";
            //return await DbHelper.ExecuteQueryAsync(query);

            string query = "SELECT  [QtdVias], [ContagemVias] FROM [ImageFeaturesDB].[dbo].[ContagemNumVias]";
            return await DbHelper.ExecuteQueryAsyncTwoCols(query);
        }

        // Reads available cores from the database and returns them as a list of strings.
        public async Task<IEnumerable<KeyValue>> ReadAvailableCors()
        {
            //string query = "SELECT [Cor Id] FROM [ImageFeaturesDB].[dbo].[Cores]";
            //return await DbHelper.ExecuteQueryAsync(query);

            string query = "SELECT [Cores_UK], [Cor Id] FROM [ImageFeaturesDB].[dbo].[Cores]";
            return await DbHelper.ExecuteQueryAsyncTwoCols(query);
        }

        public async Task<IEnumerable<string>> ReadAvailableSampleSection()
        {
            string query = "SELECT DISTINCT [Section] FROM [ImageFeaturesDB].[dbo].[ConnectorTypes]";
            return await DbHelper.ExecuteQueryAsync(query);
        }

        public async Task<IEnumerable<string>> ReadAvailableFabricante()
        {
            string query = "SELECT Fabricante FROM ImageFeaturesDB.dbo.Fabricantes";
            return await DbHelper.ExecuteQueryAsync(query);
        }

        public async Task<IEnumerable<string>> ReadAvailableCapotAngles()
        {
            string query = "SELECT DegreesNum FROM ImageFeaturesDB.dbo.CapotAngles";
            return await DbHelper.ExecuteQueryAsync(query);
        }
    }
}
