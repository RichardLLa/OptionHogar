using Infrastructure.Aspect.DataAccess;
using Infrastructure.Entities.Models;
using Infrastructure.Entities.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Manager
{
    public class LogManager
    {
        public bool Insert(  Log Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Logs_Insert");
                DataAccessEnterprise.AddParameter(_command, "@LOG_Date", Item.LOG_Date, SqlDbType.DateTime, 0, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabAUD", Item.TYPE_TabAUD, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodAUD", Item.TYPE_CodAUD, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@LOG_Object", Item.LOG_Object, SqlDbType.VarChar, 30, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@LOG_Text", Item.LOG_Text, SqlDbType.Text, 250, ParameterDirection.Input);

                if (DataAccessEnterprise.ExecuteNonQuery(_command, null) > 0)
                {

                    return true;
                }
            }
            catch (SqlException e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = e.Number
                };
            }
            catch (Exception e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = null
                };
            }
            DataAccessEnterprise.EndConnection();
            return false;
        }

        public bool Update(  Log Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Logs_Update");
                DataAccessEnterprise.AddParameter(_command, "@LOG_ID", Item.LOG_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@LOG_Date", Item.LOG_Date, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabAUD", Item.TYPE_TabAUD, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodAUD", Item.TYPE_CodAUD, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@LOG_Object", Item.LOG_Object, SqlDbType.VarChar, 30, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@LOG_Text", Item.LOG_Text, SqlDbType.Text, 250, ParameterDirection.Input);

                if (DataAccessEnterprise.ExecuteNonQuery(_command, null) > 0)
                {
                    return true;
                }
                logError = new LogError()
                {
                    Message = "Registro no encontrado",
                    ErrorValidado = true,
                    MensajeUsuario = "Error en procesar petición, El registro no existe"
                };
            }
            catch (SqlException e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = e.Number
                };
            }
            catch (Exception e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = null
                };
            }
            DataAccessEnterprise.EndConnection();
            return false;
        }
        public bool Delete(int LOG_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Logs_Delete");
                DataAccessEnterprise.AddParameter(_command, "@LOG_ID", LOG_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                if (DataAccessEnterprise.ExecuteNonQuery(_command, null) > 0)
                {
                    return true;
                }
                logError = new LogError()
                {
                    Message = "Registro no encontrado",
                    ErrorValidado = true,
                    MensajeUsuario = "Error en procesar petición, El registro no existe"
                };
            }
            catch (SqlException e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = e.Number
                };
            }
            catch (Exception e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = null
                };
            }
            DataAccessEnterprise.EndConnection();
            return false;
        }

        public Log SelectById(int id, out LogError logError)
        {
            logError = null;
            Log _log = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Logs_Select");
                DataAccessEnterprise.AddParameter(_command, "@log_id", id, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int log_id = (int)reader["log_id"];
                        DateTime log_date = (DateTime)reader["log_date"];
                        string TYPE_TabAUD = (string)reader["TYPE_TabAUD"];
                        string TYPE_CodAUD = (string)reader["TYPE_CodAUD"];
                        string LOG_Object = (string)reader["LOG_Object"];
                        string LOG_Text = (string)reader["LOG_Text"];

                        _log = new Log()
                        {
                            LOG_ID = log_id,
                            LOG_Date = log_date,
                            TYPE_TabAUD = TYPE_TabAUD,
                            TYPE_CodAUD = TYPE_CodAUD,
                            LOG_Object = LOG_Object,
                            LOG_Text = LOG_Text
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_log == null)
                {
                    logError = new LogError()
                    {
                        Message = "Registro no encontrado",
                        ErrorValidado = true,
                        MensajeUsuario = "Error en procesar petición, El registro no existe"
                    };
                }
            }
            catch (SqlException e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = e.Number
                };
            }
            catch (Exception e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = null
                };
            }
            DataAccessEnterprise.EndConnection();
            return _log;
        }

        public List<Log> SelectAll(out LogError logError)
        {
            logError = null;
            List<Log> _logList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Logs_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                         _logList = new List<Log>();
                        while (reader.Read()){
                            int log_id = (int)reader["log_id"];
                            DateTime log_date = (DateTime)reader["log_date"];
                            string TYPE_TabAUD = (string)reader["TYPE_TabAUD"];
                            string TYPE_CodAUD = (string)reader["TYPE_CodAUD"];
                            string LOG_Object = (string)reader["LOG_Object"];
                            string LOG_Text = (string)reader["LOG_Text"];

                           var  _log = new Log()
                            {
                                LOG_ID = log_id,
                                LOG_Date = log_date,
                                TYPE_TabAUD = TYPE_TabAUD,
                                TYPE_CodAUD = TYPE_CodAUD,
                                LOG_Object = LOG_Object,
                                LOG_Text = LOG_Text
                            };
                            _logList.Add(_log);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_logList == null)
                {
                    logError = new LogError()
                    {
                        Message = "Registros no encontrados",
                        ErrorValidado = true,
                        MensajeUsuario = "Error en procesar petición, El registro no existe"
                    };
                }
            }
            catch (SqlException e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = e.Number
                };
            }
            catch (Exception e)
            {
                logError = new LogError()
                {
                    Message = e.Message,
                    StackTracer = e.StackTrace,
                    NumberError = null
                };
            }
            DataAccessEnterprise.EndConnection();
            return _logList;
        }


    }
}
