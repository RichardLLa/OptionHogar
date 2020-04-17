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
    public class ParamManager
    {

        public bool Insert(Param Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Params_Insert");
                DataAccessEnterprise.AddParameter(_command, "@PARA_Key ", Item.PARA_Key, SqlDbType.VarChar, 5, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PARA_Value ", Item.PARA_Value, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PARA_Description      ", Item.PARA_Description, SqlDbType.VarChar, 100, ParameterDirection.Input);
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
            DataAccessEnterprise.EndConnection();
            return false;
        }

        public bool Update(Param Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Params_Update");
                DataAccessEnterprise.AddParameter(_command, "@PARA_ID", Item.PARA_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PARA_Key", Item.PARA_Key, SqlDbType.VarChar, 5, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PARA_Value", Item.PARA_Value, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PARA_Description", Item.PARA_Description, SqlDbType.VarChar, 100, ParameterDirection.Input);
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

        public bool Delete(int PARA_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Params_Delete");
                DataAccessEnterprise.AddParameter(_command, "@PARA_ID", PARA_ID, SqlDbType.Int, 1, ParameterDirection.Input);
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
        public Param SelectById(int PARA_ID, out LogError logError)
        {
            logError = null;
            Param _param = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Params_Select");
                DataAccessEnterprise.AddParameter(_command, "@PARA_ID", PARA_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int ID = (int)reader["PARA_ID"];
                        string Key = (string)reader["PARA_Key"];
                        string Value = (string)reader["PARA_Value"];
                        string Description = (string)reader["PARA_Description"];
                        string Usercrea = (string)reader["audi_usercrea"];
                        DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                        string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _param = new Param()
                        {
                            PARA_ID = ID,
                            PARA_Key = Key,
                            PARA_Value = Value,
                            PARA_Description = Description,
                            AUDI_UserCrea = Usercrea,
                            AUDI_FechCrea = Fechcrea,
                            AUDI_UserModi = Usermodi,
                            AUDI_FechModi = Fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_param == null)
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
            return _param;
        }

        public List<Param> SelectAll(out LogError logError)
        {
            logError = null;
            List<Param> _paramList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Params_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {

            _paramList = new List<Param>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["PARA_ID"];
                            string Key = (string)reader["PARA_Key"];
                            string Value = (string)reader["PARA_Value"];
                            string Description = (string)reader["PARA_Description"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _param = new Param()
                            {
                                PARA_ID = ID,
                                PARA_Key = Key,
                                PARA_Value = Value,
                                PARA_Description = Description,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _paramList.Add(_param);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_paramList == null)
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
            return _paramList;
        }


    }
}
