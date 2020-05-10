using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace OCCMK_Kartoteka
{
    public sealed class DatabaseContext
    {

        /// <summary>
        /// Соединение с БД
        /// </summary>
        public SqlConnection _connection = new SqlConnection("Persist Security Info=False;User ID=1;Initial Catalog=OCCMK;Data Source=VS-NMZ-02");

        private Dictionary<String, String> columnNameForUpdate = new Dictionary<string, string>() 
        { 
            {"docstatus","status"},{"docsecret","docsecret"},{"developer","developer"}
        };

        public string getUpdateColumnNameForTable(string tableName)
        {
            string lowTableName = tableName.ToLower();
            string colName = null;
            try
            {
                colName = columnNameForUpdate[lowTableName];
                return colName;
            }
            catch
            {
                throw;
            }

        }
        
        /// <summary>
        /// Объект контекста БД который и взаимодействует с бд, с которым в свою очередь работают все остальные классы
        /// </summary>
        private static DatabaseContext _instance = new DatabaseContext();

        private DatabaseContext()
        {

        }

        /// <summary>
        /// Свойство для предоставления в окрущающую среду объекта для работы с БД
        /// </summary>
        public static DatabaseContext Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Execute command with parameters in database
        /// </summary>
        /// <param name="commandText">Command text</param>
        /// <param name="type">Command type System.Data.CommandType</param>
        /// <param name="parameters">Set of parameters names with values</param>
        public void ExecuteCommand(string commandText, Dictionary<string, object> parameters, CommandType type = CommandType.StoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Invalid command text");

            if (parameters == null || parameters.Count == 0)
                this.ExecuteCommand(commandText, type);
            else
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = type;
                    this.ExecuteCommand(command, parameters);
                }
        }

        /// <summary>
        /// Execute command without parameters in database
        /// </summary>
        /// <param name="commandText">Command text</param>
        /// <param name="type">Command type System.Data.CommandType</param>
        public void ExecuteCommand(string commandText, CommandType type = CommandType.StoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Invalid command text");
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = type;
                this.ExecuteCommand(command);
            }
        }

        /// <summary>
        /// Execute command in database
        /// </summary>
        /// <param name="command">SqlCommand command</param>
        /// <param name="parameters">Set of parameters names with values</param>
        public void ExecuteCommand(SqlCommand command, Dictionary<string, object> parameters)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentException("Invalid command");
            if (parameters != null && parameters.Count != 0)
            {
                command.Parameters.Clear();
                foreach (var parameter in parameters)
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value == null ? DBNull.Value : parameter.Value);
            }
            this.ExecuteCommand(command);
        }

        /// <summary>
        /// Execute command in database
        /// </summary>
        /// <param name="command">SqlCommand command</param>
        public void ExecuteCommand(SqlCommand command)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentException("InvalidCommand");
            try
            {
                _connection.Open();
                 command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// Loads table from database using command
        /// </summary>
        /// <param name="command">SqlCommand command</param>
        /// <returns>DataTable object</returns>
        public DataTable LoadFromDatabase(SqlCommand command)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentException("Invalid command");
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                table.Load(command.ExecuteReader());
            }
            catch
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        /// <summary>
        /// Loads table from database using command
        /// </summary>
        /// <param name="command">SqlCommand command</param>
        /// <param name="parameters">Set of parameters names with values</param>
        /// <returns>DataTable object</returns>
        public DataTable LoadFromDatabase(SqlCommand command, Dictionary<string, object> parameters)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentException("InvalidCommand");
            if (parameters != null && parameters.Count != 0)
            {
                command.Parameters.Clear();
                foreach (var parameter in parameters)
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value == null ? DBNull.Value : parameter.Value);
            }
            return LoadFromDatabase(command);
        }

        /// <summary>
        /// Loads table from database using command
        /// </summary>
        /// <param name="commandText">command text</param>
        /// <param name="type">System.Data.CommandType type</param>
        /// <returns>DataTable object</returns>
        public DataTable LoadFromDatabase(string commandText, CommandType type = CommandType.StoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Invalid command text");
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = type;
                return LoadFromDatabase(command);
            }
        }

        /// <summary>
        /// Loads table from database using command
        /// </summary>
        /// <param name="commandText">command text</param>
        /// <param name="parameters">set of parameters names with values</param>
        /// <param name="type">System.Data.CommandType type</param>
        /// <returns>DataTable object</returns>
        public DataTable LoadFromDatabase(string commandText, Dictionary<string, object> parameters, CommandType type = CommandType.StoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Invalid command text");

            if (parameters == null || parameters.Count == 0)
                return this.LoadFromDatabase(commandText, type);
            else
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = type;
                    return this.LoadFromDatabase(command, parameters);
                }
        }



        public SqlDataReader ExecuteReader(string commandText) 
        {

            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Invalid command text");

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = CommandType.Text;
                SqlDataReader reader;
                try
                {
                    _connection.Open();
                    reader = command.ExecuteReader();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    _connection.Close();
                }
                return reader;
            }

        }
        
        /// <summary>
        /// Execute command in database and return scalar result
        /// </summary>
        /// <param name="command">SqlComm</param>
        /// <returns>Returns the first column of the first row in the result set</returns>
        public object ExecuteScalar(SqlCommand command)
        {
            object result = null;

            if (command == null || string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentException("InvalidCommand");
            try
            {
                _connection.Open();
                result = command.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Execute command in database and return scalar result
        /// </summary>
        /// <param name="command">SqlCommand command</param>
        /// <param name="parameters">Set of parameters names with values</param>
        /// <returns>Returns the first column of the first row in the result set</returns>
        public object ExecuteScalar(SqlCommand command, Dictionary<string, object> parameters)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentException("Invalid command");
            if (parameters != null && parameters.Count != 0)
            {
                command.Parameters.Clear();
                foreach (var parameter in parameters)
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value == null ? DBNull.Value : parameter.Value);
            }
            return this.ExecuteScalar(command);
        }

        /// <summary>
        /// Execute command in database and return scalar result
        /// </summary>
        /// <param name="commandText">Command text</param>
        /// <param name="type">Command type System.Data.CommandType</param>
        /// <returns>Returns the first column of the first row in the result set</returns>
        public object ExecuteScalar(string commandText, CommandType type = CommandType.StoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Invalid command text");
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = type;
                return this.ExecuteScalar(command);
            }
        }

        /// <summary>
        /// Execute command in database and return scalar result
        /// </summary>
        /// <param name="commandText">Command text</param>
        /// <param name="type">Command type System.Data.CommandType</param>
        /// <param name="parameters">Set of parameters names with values</param>
        /// <returns>Returns the first column of the first row in the result set</returns>
        public object ExecuteScalar(string commandText, Dictionary<string, object> parameters, CommandType type = CommandType.StoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Invalid command text");
            object result = null;

            if (parameters == null || parameters.Count == 0)
                result = this.ExecuteScalar(commandText, type);
            else
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = type;
                    result = this.ExecuteScalar(command, parameters);
                }
            return result;
        }
    }
}
