using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;

namespace Infrastructure.Endpoint.Data
{
    public class SqlDbConnection : ISqlDbConnection
    {
        private static SqlDbConnection _instance;
        public readonly SqlConnection connection;

        private SqlDbConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSQLServer"].ConnectionString;
            connection = new SqlConnection(connectionString);

            OpenConnection();
        }

        public static SqlDbConnection GetInstance()
        {
            if (_instance is null)
            {
                _instance = new SqlDbConnection();
            }

            return _instance;
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Open) return;

            connection.Open();
        }

        //nuevo
        public SqlCommand TraerConsulta(string cmd)
        {
            return new SqlCommand(cmd, connection);
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Closed) return;

            connection.Close();
        }



        public T GetDataRowValue<T>(DataRow row, string index, T defaultValue = default)
        {
            return !row.IsNull(index) ? (T)row[index] : defaultValue;
        }

        public async Task<DataTable> ExecuteQueryCommandAsync(SqlCommand command)
        {
            OpenConnection();
            DataTable dt = new DataTable();
            command.Connection = connection;
            SqlDataReader reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            command.Dispose();
            return dt;
        }

        public async Task<int> ExecuteNonQueryCommandAsync(SqlCommand command)
        {
            OpenConnection();
            command.Connection = connection;
            int affectedRows = await command.ExecuteNonQueryAsync();
            command.Dispose();
            return affectedRows;
        }
        
        public int ExecuteNonQueryCommand(SqlCommand command)
        {
            OpenConnection();
            command.Connection = connection;
            int affectedRows = command.ExecuteNonQuery();
            command.Dispose();
            return affectedRows;
        }

        public Task<bool> RunTransactionAsync(params SqlCommand[] commands)
        {
            OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                foreach (var command in commands)
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                Console.WriteLine("The records were written to database.");
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                transaction.Rollback();
                Console.WriteLine("Transaction failed. Rolled back.");
                return Task.FromResult(false);
            }
        }
    }
}