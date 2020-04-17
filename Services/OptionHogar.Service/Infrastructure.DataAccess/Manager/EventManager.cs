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
    public class EventManager
    {

        public bool Insert(Event Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Events_Insert");
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID", Item.PROJ_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_StartDate", Item.EVEN_StartDate, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_EndingDate", Item.EVEN_EndingDate, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_State", Item.EVEN_State, SqlDbType.Char, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_Title", Item.EVEN_Title, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_Description", Item.EVEN_Description, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_UserCrea", Item.AUDI_UserCrea, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_FechCrea", Item.AUDI_FechCrea, SqlDbType.Date, 8, ParameterDirection.Input);

                if (DataAccessEnterprise.ExecuteNonQuery(_command, null) > 0)
                {
                    //if (Int32.TryParse(_command.Parameters["@PERS_ID"].Value.ToString(), out Int32 _PERS_ID))
                    //{ Item.PERS_ID = _PERS_ID; }

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
            return false;
        }

        public bool Update(Event Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Events_Update");
                DataAccessEnterprise.AddParameter(_command, "@EVEN_ID", Item.EVEN_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID", Item.PROJ_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_StartDate", Item.EVEN_StartDate, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_EndingDate", Item.EVEN_EndingDate, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_State", Item.EVEN_State, SqlDbType.Char, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_Title", Item.EVEN_Title, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_Description", Item.EVEN_Description, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_UserModi", Item.AUDI_UserModi, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_FechModi", Item.AUDI_FechModi, SqlDbType.DateTime, 8, ParameterDirection.Input);
                if (DataAccessEnterprise.ExecuteNonQuery(_command, null) > 0)
                {
                    //if (Int32.TryParse(_command.Parameters["@PERS_ID"].Value.ToString(), out Int32 _PERS_ID))
                    //{ Item.PERS_ID = _PERS_ID; }

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

        public bool Delete(int EVEN_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Events_Delete");
                DataAccessEnterprise.AddParameter(_command, "@EVEN_ID", EVEN_ID, SqlDbType.Int, 1, ParameterDirection.Input);
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
            return false;
        }

        public Event SelectById(int EVEN_ID, out LogError logError)
        {
            logError = null;
            Event _event = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Events_Select");
                DataAccessEnterprise.AddParameter(_command, "@even_id", EVEN_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int even_id = (int)reader["even_id"];
                        int proj_id = (int)reader["proj_id"];
                        DateTime even_startdate = (DateTime)reader["even_startdate"];
                        DateTime even_endingdate = (DateTime)reader["even_endingdate"];
                        char even_state = Convert.ToChar(reader["even_state"]);
                        string even_title = (string)reader["even_title"];
                        string even_description = (string)reader["even_description"];
                        string audi_usercrea = (string)reader["audi_usercrea"];
                        DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                        string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _event = new Event()
                        {
                            EVEN_ID = even_id,
                            PROJ_ID = proj_id,
                            EVEN_StartDate = even_startdate,
                            EVEN_EndingDate = even_endingdate,
                            EVEN_State = even_state,
                            EVEN_Title = even_title,
                            EVEN_Description = even_description,
                            AUDI_UserCrea = audi_usercrea,
                            AUDI_FechCrea = audi_fechcrea,
                            AUDI_UserModi = audi_usermodi,
                            AUDI_FechModi = audi_fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_event == null)
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
            return _event;
        }

        public List<Event> SelectAll(out LogError logError)
        {
            logError = null;
            List<Event> _eventList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Events_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _eventList = new List<Event>();
                        while (reader.Read())
                        {
                            int even_id = (int)reader["even_id"];
                            int proj_id = (int)reader["proj_id"];
                            DateTime even_startdate = (DateTime)reader["even_startdate"];
                            DateTime even_endingdate = (DateTime)reader["even_endingdate"];
                            char even_state = Convert.ToChar(reader["even_state"]);
                            string even_title = (string)reader["even_title"];
                            string even_description = (string)reader["even_description"];
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _event = new Event()
                            {
                                EVEN_ID = even_id,
                                PROJ_ID = proj_id,
                                EVEN_StartDate = even_startdate,
                                EVEN_EndingDate = even_endingdate,
                                EVEN_State = even_state,
                                EVEN_Title = even_title,
                                EVEN_Description = even_description,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _eventList.Add(_event);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_eventList == null)
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
            return _eventList;
        }

        public List<Event> SelectByProjectId(int project_id, out LogError logError)
        {
            logError = null;
            List<Event> _eventList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Events_SelectProj_id");
                DataAccessEnterprise.AddParameter(_command, "@proj_id", project_id, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _eventList = new List<Event>();
                        while (reader.Read())
                        {
                            int even_id = (int)reader["even_id"];
                            int proj_id = (int)reader["proj_id"];
                            DateTime even_startdate = (DateTime)reader["even_startdate"];
                            DateTime even_endingdate = (DateTime)reader["even_endingdate"];
                            char even_state = Convert.ToChar(reader["even_state"]);
                            string even_title = (string)reader["even_title"];
                            string even_description = (string)reader["even_description"];
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];
                            var _event = new Event()

                            {
                                EVEN_ID = even_id,
                                PROJ_ID = proj_id,
                                EVEN_StartDate = even_startdate,
                                EVEN_EndingDate = even_endingdate,
                                EVEN_State = even_state,
                                EVEN_Title = even_title,
                                EVEN_Description = even_description,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _eventList.Add(_event);
                        }
                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_eventList == null)
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
            return _eventList;
        }
    }
}
