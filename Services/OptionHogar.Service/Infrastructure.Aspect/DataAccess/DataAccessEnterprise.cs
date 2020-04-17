using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Aspect.DataAccess
{
    public class DataAccessEnterprise
    {
        public static DataAccessEnterprise Instance { get; set; }
        public static string StringConnection { get; set; }
        public static SqlConnection SQLSConnection { get; set; }
        public static SqlTransaction SQLSTransaction { get; set; }

        /// <summary>
        /// Data Access Enterprise Construct in PRIVATE MODE 
        /// </summary>
        /// <param name="aplicationConnection">String connection to database</param>
        private DataAccessEnterprise(string aplicationConnection)
        {
            try
            {
                StringConnection = aplicationConnection;
                SQLSConnection = new SqlConnection(aplicationConnection);
            }
            catch (Exception)
            { throw; }
        }

        public static DataAccessEnterprise Initialize(string aplicationConnection)
        {
            try
            {
                if (Instance == null)
                { Instance = new DataAccessEnterprise(aplicationConnection); }
                return Instance;
            }
            catch (Exception)
            { throw; }
        }

        public static DataAccessEnterprise Restart(string aplicationConnection)
        {
            try
            {
                Instance = new DataAccessEnterprise(aplicationConnection);
                return Instance;
            }
            catch (Exception)
            {
                EndConnection();
                throw; }
        }

        private static void ValidateConnection()
        {
            try
            {
                if (SQLSConnection == null || string.IsNullOrEmpty(SQLSConnection.ConnectionString))
                { SQLSConnection = new SqlConnection(StringConnection); }
            }
            catch (Exception)
            { 
                EndConnection();
                throw; }
        }





        public static SqlCommand AsignProcedure(string procedureName)
        {
            try
            {
                SqlCommand _command ;

                _command = SQLSConnection.CreateCommand();
                _command.CommandText = procedureName;
                _command.Connection = SQLSConnection;
                _command.CommandTimeout = SQLSConnection.ConnectionTimeout;
                _command.CommandType = CommandType.StoredProcedure;

                return _command;
            }
            catch (Exception)
            { 
                EndConnection();
                throw; }
        }

        public static void AddParameter(SqlCommand sqlCommand, string parameterName, object value, SqlDbType sqlType, int size, ParameterDirection direction)
        {
            try
            {
                SqlParameter _parameter;
                _parameter = sqlCommand.CreateParameter();
                _parameter.ParameterName = parameterName;
                _parameter.SqlDbType = sqlType;
                _parameter.Size = size;
                _parameter.Direction = direction;
                _parameter.IsNullable = true;
                if (value == null)
                { _parameter.Value = DBNull.Value; }
                else
                { _parameter.Value = value; }

                sqlCommand.Parameters.Add(_parameter);
            }
            catch (Exception)
            { 
                EndConnection();
                throw; }
        }

        public static int ExecuteNonQuery(SqlCommand sqlCommand, SqlTransaction sqlTransaction)
        {
            try
            {
                if (sqlTransaction == null)
                {
                    int _affected;
                    using (sqlCommand.Connection = BeginConnection())
                    {
                        _affected = sqlCommand.ExecuteNonQuery();
                        EndConnection();
                    }
                    return _affected;
                    //return sqlCommand.ExecuteNonQuery();  
                }
                else
                {
                    if (sqlTransaction.Connection == null)
                    {
                        sqlTransaction = null;
                        int _affected;
                        using (BeginConnection())
                        {
                            _affected = sqlCommand.ExecuteNonQuery();
                            EndConnection();
                        }
                        return _affected;
                    }
                    else
                    {
                        sqlCommand.Transaction = sqlTransaction;
                        return sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            { 
                //EndConnection();
                throw; }
        }

        public static SqlConnection BeginConnection()
        {
            try
            {
                ValidateConnection();
                SQLSConnection.Open();
                return SQLSConnection;
            }
            catch (Exception e)
            {
                EndConnection();
                throw; }
        }

        public static void EndConnection()
        {
            try
            {
                if (SQLSConnection.State == ConnectionState.Open)
                {
                    SQLSConnection.Close();
                }
            }
            catch (Exception)
            { throw; }
        }


        public static void BeginTransaction()
        {
            try
            {
                ValidateConnection();
                SQLSConnection.Open();
                SQLSTransaction = SQLSConnection.BeginTransaction();
            }
            catch (Exception)
            {
                EndConnection();
                throw;
            }
        }

        public static void CommitTransaction()
        {
            try
            {
                if (SQLSTransaction != null)
                {
                    SQLSTransaction.Commit();
                    SQLSConnection.Close();
                    SQLSTransaction = null;
                }
            }
            catch (Exception)
            { 
                EndConnection();
                throw; }
        }

        public static void RollBackTransaction()
        {
            try
            {
                if (SQLSTransaction != null)
                {
                    SQLSTransaction.Rollback();
                    SQLSConnection.Close();
                    SQLSTransaction = null;
                }
            }
            catch (Exception)
            { 
                EndConnection();
                throw; }
        }

    }
}
