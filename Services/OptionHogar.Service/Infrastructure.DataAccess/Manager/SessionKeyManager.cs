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
    public class SessionKeyManager
    {
        public bool Insert(SessionKey Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("SessionKeys_Insert");

                DataAccessEnterprise.AddParameter(_command, "@SESS_ID", Item.SESS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_Date", Item.SESS_Date, SqlDbType.Date, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PrivateKeyXML", Item.SESS_PrivateKeyXML, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PublicKeyXML", Item.SESS_PublicKeyXML, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PrivateKeyPEM", Item.SESS_PrivateKeyPEM, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PublicKeyPEM", Item.SESS_PublicKeyPEM, SqlDbType.VarChar, 100, ParameterDirection.Input);
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

        public bool Update(SessionKey Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("SessionKeys_Update");

                DataAccessEnterprise.AddParameter(_command, "@SESS_ID", Item.SESS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_Date", Item.SESS_Date, SqlDbType.Date, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PrivateKeyXML", Item.SESS_PrivateKeyXML, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PublicKeyXML", Item.SESS_PublicKeyXML, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PrivateKeyPEM", Item.SESS_PrivateKeyPEM, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_PublicKeyPEM", Item.SESS_PublicKeyPEM, SqlDbType.VarChar, 100, ParameterDirection.Input);
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

        public bool Delete(int SESS_ID, DateTime SESS_Date, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("SessionKeys_Delete");
                DataAccessEnterprise.AddParameter(_command, "@SESS_ID", SESS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_Date", SESS_Date, SqlDbType.DateTime, 8, ParameterDirection.Input);
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

        public SessionKey SelectById(int SESS_ID, DateTime SESS_Date, out LogError logError)
        {
            logError = null;
            SessionKey _sessionKey = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("SessionKeys_Select");
                DataAccessEnterprise.AddParameter(_command, "@SESS_ID", SESS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@SESS_Date", SESS_Date, SqlDbType.DateTime, 8, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        int ID = (int)reader["SESS_ID"];
                        DateTime Date = (DateTime)reader["SESS_Date"];
                        string PrivateKeyXML = (string)reader["SESS_PrivateKeyXML"];
                        string PublicKeyXML = (string)reader["SESS_PublicKeyXML"];
                        string PrivateKeyPEM = (string)reader["SESS_PrivateKeyPEM"];
                        string PublicKeyPEM = (string)reader["SESS_PublicKeyPEM"];
                        string audi_usercrea = (string)reader["audi_usercrea"];
                        DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                        string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _sessionKey = new SessionKey()
                        {
                            SESS_ID = ID,
                            SESS_Date = Date,
                            SESS_PrivateKeyXML = PrivateKeyXML,
                            SESS_PublicKeyXML = PublicKeyXML,
                            SESS_PrivateKeyPEM = PrivateKeyPEM,
                            SESS_PublicKeyPEM = PublicKeyPEM,
                            AUDI_UserCrea = audi_usercrea,
                            AUDI_FechCrea = audi_fechcrea,
                            AUDI_UserModi = audi_usermodi,
                            AUDI_FechModi = audi_fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_sessionKey == null)
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
            return _sessionKey;
        }

        public List<SessionKey> SelectAll(out LogError logError)
        {
            logError = null;
            List<SessionKey> _sessionKeyList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("SessionKeys_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _sessionKeyList = new List<SessionKey>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["SESS_ID"];
                            DateTime Date = (DateTime)reader["SESS_Date"];
                            string PrivateKeyXML = (string)reader["SESS_PrivateKeyXML"];
                            string PublicKeyXML = (string)reader["SESS_PublicKeyXML"];
                            string PrivateKeyPEM = (string)reader["SESS_PrivateKeyPEM"];
                            string PublicKeyPEM = (string)reader["SESS_PublicKeyPEM"];
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _sessionKey = new SessionKey()
                            {
                                SESS_ID = ID,
                                SESS_Date = Date,
                                SESS_PrivateKeyXML = PrivateKeyXML,
                                SESS_PublicKeyXML = PublicKeyXML,
                                SESS_PrivateKeyPEM = PrivateKeyPEM,
                                SESS_PublicKeyPEM = PublicKeyPEM,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _sessionKeyList.Add(_sessionKey);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_sessionKeyList == null)
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
            DataAccessEnterprise.EndConnection();
            return _sessionKeyList;
        }

    }

}
