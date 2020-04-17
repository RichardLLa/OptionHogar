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
    public class InvestmentManager
    {

        public bool Insert(Investment Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Investments_Insert");
                DataAccessEnterprise.AddParameter(_command, "@USER_ID", Item.USER_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_Amount", Item.INVE_Amount, SqlDbType.Decimal, 10, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_Date", Item.INVE_Date, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_Observation", Item.INVE_Observation, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_CostEffectiveness", Item.INVE_CostEffectiveness, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_State", Item.INVE_State, SqlDbType.Char, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_UserCrea", Item.AUDI_UserCrea, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_FechCrea", Item.AUDI_FechCrea, SqlDbType.DateTime, 8, ParameterDirection.Input);

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

        public bool Update(Investment Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Investments_Update");
                DataAccessEnterprise.AddParameter(_command, "@INVE_ID", Item.INVE_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_ID", Item.USER_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_Amount", Item.INVE_Amount, SqlDbType.Decimal, 10, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_Date", Item.INVE_Date, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_Observation", Item.INVE_Observation, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_CostEffectiveness", Item.INVE_CostEffectiveness, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_State", Item.INVE_State, SqlDbType.Char, 1, ParameterDirection.Input);
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

        public bool Delete(int INVE_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Investments_Delete");
                DataAccessEnterprise.AddParameter(_command, "@INVE_ID", INVE_ID, SqlDbType.Int, 1, ParameterDirection.Input);
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

        public Investment SelectById(int id, out LogError logError)
        {
            logError = null;
            Investment _investment = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Investments_Select");
                DataAccessEnterprise.AddParameter(_command, "@inve_id", id, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int inve_id = (int)reader["inve_id"];
                        int user_id = (int)reader["user_id"];
                        decimal inve_amount = (decimal)reader["inve_amount"];
                        DateTime inve_date = (DateTime)reader["inve_date"];
                        string inve_observation = (string)reader["inve_observation"];
                        int inve_costeffectiveness = (int)reader["inve_costeffectiveness"];
                        char inve_state = Convert.ToChar(reader["inve_state"]);
                        string audi_usercrea = (string)reader["audi_usercrea"];
                        DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                        string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _investment = new Investment()
                        {
                            INVE_ID = inve_id,
                            USER_ID = user_id,
                            INVE_Amount = inve_amount,
                            INVE_Date = inve_date,
                            INVE_Observation = inve_observation,
                            INVE_CostEffectiveness = inve_costeffectiveness,
                            INVE_State = inve_state,
                            AUDI_UserCrea = audi_usercrea,
                            AUDI_FechCrea = audi_fechcrea,
                            AUDI_UserModi = audi_usermodi,
                            AUDI_FechModi = audi_fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_investment == null)
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
            return _investment;
        }

        public List<Investment> SelectAll(out LogError logError)
        {
            logError = null;
            List<Investment> _investmentList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Investments_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _investmentList = new List<Investment>();

                        while (reader.Read())
                        {
                            int inve_id = (int)reader["inve_id"];
                            int user_id = (int)reader["user_id"];
                            decimal inve_amount = (decimal)reader["inve_amount"];
                            DateTime inve_date = (DateTime)reader["inve_date"];
                            string inve_observation = (string)reader["inve_observation"];
                            int inve_costeffectiveness = (int)reader["inve_costeffectiveness"];
                            char inve_state = Convert.ToChar(reader["inve_state"]);
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _investment = new Investment()
                            {
                                INVE_ID = inve_id,
                                USER_ID = user_id,
                                INVE_Amount = inve_amount,
                                INVE_Date = inve_date,
                                INVE_Observation = inve_observation,
                                INVE_CostEffectiveness = inve_costeffectiveness,
                                INVE_State = inve_state,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _investmentList.Add(_investment);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_investmentList == null)
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
            return _investmentList;
        }


        public List<Investment> SelectByUserId(int userId, out LogError logError)
        {
            logError = null;
            List<Investment> _investmentList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Investments_SelectByUser_Id");
                DataAccessEnterprise.AddParameter(_command, "@user_id", userId, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _investmentList = new List<Investment>();
                        while (reader.Read())
                        {
                            int inve_id = (int)reader["inve_id"];
                            int user_id = (int)reader["user_id"];
                            decimal inve_amount = (decimal)reader["inve_amount"];
                            DateTime inve_date = (DateTime)reader["inve_date"];
                            string inve_observation = (string)reader["inve_observation"];
                            int inve_costeffectiveness = (int)reader["inve_costeffectiveness"];
                            char inve_state = Convert.ToChar(reader["inve_state"]);
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _investment = new Investment()
                            {
                                INVE_ID = inve_id,
                                USER_ID = user_id,
                                INVE_Amount = inve_amount,
                                INVE_Date = inve_date,
                                INVE_Observation = inve_observation,
                                INVE_CostEffectiveness = inve_costeffectiveness,
                                INVE_State = inve_state,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _investmentList.Add(_investment);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_investmentList == null)
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
            return _investmentList;
        }

    }
}
