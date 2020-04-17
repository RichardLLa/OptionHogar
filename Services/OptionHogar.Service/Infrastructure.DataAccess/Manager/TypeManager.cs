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
using Type = Infrastructure.Entities.Models.Type;

namespace Infrastructure.DataAccess.Manager
{
    public class TypeManager
    {

        public bool Insert(Type Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Types_Insert");
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodTable", Item.TYPE_CodTable, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodType", Item.TYPE_CodType, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Desc1", Item.TYPE_Desc1, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Desc2", Item.TYPE_Desc2, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Num1", Item.TYPE_Num1, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Num2", Item.TYPE_Num2, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Status", Item.TYPE_Status, SqlDbType.Char, 1, ParameterDirection.Input);
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

        public bool Update(Type Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Types_Update");

                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodTable", Item.TYPE_CodTable, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodType", Item.TYPE_CodType, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Desc1", Item.TYPE_Desc1, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Desc2", Item.TYPE_Desc2, SqlDbType.VarChar, 100, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Num1", Item.TYPE_Num1, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Num2", Item.TYPE_Num2, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_Status", Item.TYPE_Status, SqlDbType.Char, 1, ParameterDirection.Input);
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

        public bool Delete(string codTable, string codType, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Types_Delete");
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodTable", codTable, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodType", codType, SqlDbType.VarChar, 3, ParameterDirection.Input);
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

        public Type SelectById(string codTable, string codType, out LogError logError)
        {
            logError = null;
            Type _type = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Types_Select");
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodTable", codTable, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodType", codType, SqlDbType.VarChar, 3, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string CodTable = (string)reader["TYPE_CodTable"];
                        string CodType = (string)reader["TYPE_CodType"];
                        string Desc1 = (string)reader["TYPE_Desc1"];
                        string Desc2 = (string)reader["TYPE_Desc2"];
                        int Num1 = (int)reader["TYPE_Num1"];
                        int Num2 = (int)reader["TYPE_Num2"];
                        char Status = Convert.ToChar(reader["TYPE_Status"]);
                        string audi_usercrea = (string)reader["audi_usercrea"];
                        DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                        string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _type = new Type()
                        {
                            TYPE_CodTable = CodTable,
                            TYPE_CodType = CodType,
                            TYPE_Desc1 = Desc1,
                            TYPE_Desc2 = Desc2,
                            TYPE_Num1 = Num1,
                            TYPE_Num2 = Num2,
                            TYPE_Status = Status,
                            AUDI_UserCrea = audi_usercrea,
                            AUDI_FechCrea = audi_fechcrea,
                            AUDI_UserModi = audi_usermodi,
                            AUDI_FechModi = audi_fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_type == null)
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
                return _type;
        }

        public List<Type> SelectAll( out LogError logError)
        {
            logError = null;
            List<Type> _typeList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Types_SelectAll");
                _typeList = new List<Type>();
                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
          _typeList = new List<Type>();
                        while (reader.Read()) 
                        {
                            string CodTable = (string)reader["TYPE_CodTable"];
                            string CodType = (string)reader["TYPE_CodType"];
                            string Desc1 = (string)reader["TYPE_Desc1"];
                            string Desc2 = (string)reader["TYPE_Desc2"];
                            int Num1 = (int)reader["TYPE_Num1"];
                            int Num2 = (int)reader["TYPE_Num2"];
                            char Status = Convert.ToChar(reader["TYPE_Status"]);
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                           var _type = new Type()
                            {
                                TYPE_CodTable = CodTable,
                                TYPE_CodType = CodType,
                                TYPE_Desc1 = Desc1,
                                TYPE_Desc2 = Desc2,
                                TYPE_Num1 = Num1,
                                TYPE_Num2 = Num2,
                                TYPE_Status = Status,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _typeList.Add(_type);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_typeList == null)
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
            return _typeList;
        }
    }
}
