namespace ImageProcessingLibrary.Services.Database
{
    using ImageProcessingLibrary.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using static ImageProcessingLibrary.ProjectSettings;

    public static class DbHelper
    {
        public static readonly string CordCONTable = "Cord_CON";

        /// <summary> Executes a query and returns the first column of the first row as a scalar value. </summary>
        public static async Task<string> ExecuteScalarAsync(string query, Dictionary<string, object>? parameters = null)
        {
            ValidateConnectionString(DbConnectionString);

            try
            {
                using SqlConnection connection = new(DbConnectionString);
                await connection.OpenAsync();

                using SqlCommand command = CreateCommand(query, connection, parameters);
                var result = await command.ExecuteScalarAsync();
                return result?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
                return string.Empty;
            }
        }


        /// <summary>
        /// Executes a query and returns an enumerable list of results from the first column.
        /// </summary>
        public static async Task<IEnumerable<string>> ExecuteQueryAsync(string query, Dictionary<string, object>? parameters = null)
        {
            ValidateConnectionString(DbConnectionString);

            var results = new List<string>();

            using SqlConnection connection = new(DbConnectionString);
            await connection.OpenAsync();

            using SqlCommand command = CreateCommand(query, connection, parameters);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                if (reader[0].ToString() is string str)
                    results.Add(str);
            }

            return results;
        }

        public static async Task<IEnumerable<Models.KeyValue>> ExecuteQueryAsyncTwoCols(string query, Dictionary<string, object>? parameters = null)
        {
            ValidateConnectionString(DbConnectionString);

            var results = new List<Models.KeyValue>();

            using SqlConnection connection = new(DbConnectionString);
            await connection.OpenAsync();

            using SqlCommand command = CreateCommand(query, connection, parameters);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                results.Add(new Models.KeyValue
                {
                    Key = reader[0].ToString() ?? string.Empty,
                    Value = reader[1].ToString() ?? string.Empty
                });
            }

            return results;
        }


        /// <summary>
        /// Executes a query that does not return results (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
        public static async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object>? parameters = null)
        {
            ValidateConnectionString(DbConnectionString);

            using SqlConnection connection = new(DbConnectionString);
            await connection.OpenAsync();

            using SqlCommand command = CreateCommand(query, connection, parameters);
            int rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected;
        }


        /// <summary>
        /// Creates a SQL command with optional parameters.
        /// </summary>
        private static SqlCommand CreateCommand(string query, SqlConnection connection, Dictionary<string, object>? parameters)
        {
            SqlCommand command = new(query, connection);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                }
            }

            return command;
        }

        /// <summary>
        /// Validates the connection string before executing a query.
        /// </summary>
        private static void ValidateConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string is not set.");
            }
        }


    }

}
