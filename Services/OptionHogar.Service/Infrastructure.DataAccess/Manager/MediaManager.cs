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
    public class MediaManager
    {
        public bool Insert(Media Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_Insert");
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID         ", Item.PROJ_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_ID         ", Item.EVEN_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Event      ", Item.MEDI_Event, SqlDbType.Bit, 2, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Title      ", Item.MEDI_Title, SqlDbType.VarChar, 50, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Description", Item.MEDI_Description, SqlDbType.VarChar, 250, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Url        ", Item.MEDI_Url, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabMED     ", Item.TYPE_TabMED, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodMED     ", Item.TYPE_CodMED, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_UserCrea", Item.AUDI_UserCrea, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_FechCrea", Item.AUDI_FechCrea, SqlDbType.Date, 8, ParameterDirection.Input);

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

        public bool Update(Media Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_Update");
                DataAccessEnterprise.AddParameter(_command, "@MEDI_ID         ", Item.MEDI_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID         ", Item.PROJ_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@EVEN_ID         ", Item.EVEN_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Event      ", Item.MEDI_Event, SqlDbType.Bit, 2, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Title      ", Item.MEDI_Title, SqlDbType.VarChar, 50, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Description", Item.MEDI_Description, SqlDbType.VarChar, 250, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@MEDI_Url        ", Item.MEDI_Url, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabMED     ", Item.TYPE_TabMED, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodMED     ", Item.TYPE_CodMED, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_UserModi", Item.AUDI_UserModi, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_FechModi", Item.AUDI_FechModi, SqlDbType.DateTime, 8, ParameterDirection.Input);
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

        public bool Delete(int MEDI_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_Delete");
                DataAccessEnterprise.AddParameter(_command, "@MEDI_ID", MEDI_ID, SqlDbType.Int, 1, ParameterDirection.Input);
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
        public Media SelectById(int MEDI_ID, out LogError logError)
        {
            logError = null;
            Media _media = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_Select");
                DataAccessEnterprise.AddParameter(_command, "@MEDI_ID", MEDI_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int ID = (int)reader["MEDI_ID"];
                        int IDPROJ = (int)reader["PROJ_ID"];
                        int IDEVEN = (int)reader["EVEN_ID"];
                        bool Event = (bool)reader["MEDI_Event"];
                        string Title = (string)reader["MEDI_Title"];
                        string Description = (string)reader["MEDI_Description"];
                        string Url = (string)reader["MEDI_Url"];
                        string TabMED = (string)reader["TYPE_TabMED"];
                        string CodMED = (string)reader["TYPE_CodMED"];
                        string Usercrea = (string)reader["audi_usercrea"];
                        DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                        string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _media = new Media()
                        {
                            MEDI_ID = ID,
                            PROJ_ID = IDPROJ,
                            EVEN_ID = IDEVEN,
                            MEDI_Event = Event,
                            MEDI_Title = Title,
                            MEDI_Description = Description,
                            MEDI_Url = Url,
                            TYPE_TabMED = TabMED,
                            TYPE_CodMED = CodMED,
                            AUDI_UserCrea = Usercrea,
                            AUDI_FechCrea = Fechcrea,
                            AUDI_UserModi = Usermodi,
                            AUDI_FechModi = Fechmodi
                        };
                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_media == null)
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
            return _media;
        }

        public List<Media> SelectAll(out LogError logError)
        {
            logError = null;
            List<Media> _mediaList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        _mediaList = new List<Media>();

                        while (reader.Read())
                        {
                            int ID = (int)reader["MEDI_ID"];
                            int IDPROJ = (int)reader["PROJ_ID"];
                            int IDEVEN = (int)reader["EVEN_ID"];
                            bool Event = (bool)reader["MEDI_Event"];
                            string Title = (string)reader["MEDI_Title"];
                            string Description = (string)reader["MEDI_Description"];
                            string Url = (string)reader["MEDI_Url"];
                            string TabMED = (string)reader["TYPE_TabMED"];
                            string CodMED = (string)reader["TYPE_CodMED"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _media = new Media()
                            {
                                MEDI_ID = ID,
                                PROJ_ID = IDPROJ,
                                EVEN_ID = IDEVEN,
                                MEDI_Event = Event,
                                MEDI_Title = Title,
                                MEDI_Description = Description,
                                MEDI_Url = Url,
                                TYPE_TabMED = TabMED,
                                TYPE_CodMED = CodMED,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _mediaList.Add(_media);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_mediaList == null)
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
            return _mediaList;

        }
        public List<Media> SelectByIdEvent(int idEvent, out LogError logError)
        {
            logError = null;
            List<Media> _mediaList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_SelectAllByEVEN_ID");
                DataAccessEnterprise.AddParameter(_command, "@EVEN_ID         ", idEvent, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        _mediaList = new List<Media>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["MEDI_ID"];
                            int IDPROJ = (int)reader["PROJ_ID"];
                            int IDEVEN = (int)reader["EVEN_ID"];
                            bool Event = (bool)reader["MEDI_Event"];
                            string Title = (string)reader["MEDI_Title"];
                            string Description = (string)reader["MEDI_Description"];
                            string Url = (string)reader["MEDI_Url"];
                            string TabMED = (string)reader["TYPE_TabMED"];
                            string CodMED = (string)reader["TYPE_CodMED"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _media = new Media()
                            {
                                MEDI_ID = ID,
                                PROJ_ID = IDPROJ,
                                EVEN_ID = IDEVEN,
                                MEDI_Event = Event,
                                MEDI_Title = Title,
                                MEDI_Description = Description,
                                MEDI_Url = Url,
                                TYPE_TabMED = TabMED,
                                TYPE_CodMED = CodMED,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _mediaList.Add(_media);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_mediaList == null)
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
            return _mediaList;
        }

        public List<Media> SelectByIdProject(int idProject, out LogError logError)
        {
            logError = null;
            List<Media> _mediaList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_SelectAllByPROJ_ID");
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID", idProject, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        _mediaList = new List<Media>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["MEDI_ID"];
                            int IDPROJ = (int)reader["PROJ_ID"];
                            int IDEVEN = (int)reader["EVEN_ID"];
                            bool Event = (bool)reader["MEDI_Event"];
                            string Title = (string)reader["MEDI_Title"];
                            string Description = (string)reader["MEDI_Description"];
                            string Url = (string)reader["MEDI_Url"];
                            string TabMED = (string)reader["TYPE_TabMED"];
                            string CodMED = (string)reader["TYPE_CodMED"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _media = new Media()
                            {
                                MEDI_ID = ID,
                                PROJ_ID = IDPROJ,
                                EVEN_ID = IDEVEN,
                                MEDI_Event = Event,
                                MEDI_Title = Title,
                                MEDI_Description = Description,
                                MEDI_Url = Url,
                                TYPE_TabMED = TabMED,
                                TYPE_CodMED = CodMED,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _mediaList.Add(_media);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_mediaList == null)
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
            return _mediaList;
        }
        public List<Media> SelectByIdTypeMED(string tabMED, string codMED, out LogError logError)
        {
            logError = null;
            List<Media> _mediaList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Media_SelectAllByTypeMED");
                DataAccessEnterprise.AddParameter(_command, "TYPE_TabMED", tabMED, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "TYPE_CodMED", codMED, SqlDbType.VarChar, 3, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        _mediaList = new List<Media>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["MEDI_ID"];
                            int IDPROJ = (int)reader["PROJ_ID"];
                            int IDEVEN = (int)reader["EVEN_ID"];
                            bool Event = (bool)reader["MEDI_Event"];
                            string Title = (string)reader["MEDI_Title"];
                            string Description = (string)reader["MEDI_Description"];
                            string Url = (string)reader["MEDI_Url"];
                            string TabMED = (string)reader["TYPE_TabMED"];
                            string CodMED = (string)reader["TYPE_CodMED"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _media = new Media()
                            {
                                MEDI_ID = ID,
                                PROJ_ID = IDPROJ,
                                EVEN_ID = IDEVEN,
                                MEDI_Event = Event,
                                MEDI_Title = Title,
                                MEDI_Description = Description,
                                MEDI_Url = Url,
                                TYPE_TabMED = TabMED,
                                TYPE_CodMED = CodMED,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _mediaList.Add(_media);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_mediaList == null)
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
            return _mediaList;
        }
    }
}
