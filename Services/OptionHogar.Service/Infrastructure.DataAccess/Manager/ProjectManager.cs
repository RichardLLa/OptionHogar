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
    public class ProjectManager
    {
        public bool Insert(Project Item, out LogError logError)
        {
            logError = null;
            try
            {

                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Projects_Insert");
                DataAccessEnterprise.AddParameter(_command, "@INVE_ID", Item.INVE_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Name", Item.PROJ_Name, SqlDbType.VarChar, 50, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_OverallProfitability", Item.PROJ_OverallProfitability, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ExecutionTime", Item.PROJ_ExecutionTime, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_InvestmentCapital", Item.PROJ_InvestmentCapital, SqlDbType.Decimal, 10, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Modality", Item.PROJ_Modality, SqlDbType.VarChar, 50, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_PromotionDate", Item.PROJ_PromotionDate, SqlDbType.Date, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ExpirationDate", Item.PROJ_ExpirationDate, SqlDbType.Date, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Progress", Item.PROJ_Progress, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Description", Item.PROJ_Description, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_State", Item.PROJ_State, SqlDbType.Char, 1, ParameterDirection.Input);
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

        public bool Update(Project Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Projects_Update");
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID", Item.PROJ_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@INVE_ID", Item.INVE_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Name", Item.PROJ_Name, SqlDbType.VarChar, 50, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_OverallProfitability", Item.PROJ_OverallProfitability, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ExecutionTime", Item.PROJ_ExecutionTime, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_InvestmentCapital", Item.PROJ_InvestmentCapital, SqlDbType.Decimal, 10, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Modality", Item.PROJ_Modality, SqlDbType.VarChar, 50, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_PromotionDate", Item.PROJ_PromotionDate, SqlDbType.Date, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ExpirationDate", Item.PROJ_ExpirationDate, SqlDbType.Date, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Progress", Item.PROJ_Progress, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_Description", Item.PROJ_Description, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PROJ_State", Item.PROJ_State, SqlDbType.Char, 1, ParameterDirection.Input);
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

        public bool Delete(int PROJ_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Projects_Delete");
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID", PROJ_ID, SqlDbType.Int, 1, ParameterDirection.Input);
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
        public Project SelectById(int PROJ_ID, out LogError logError)
        {
            logError = null;
            Project _project = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Projects_Select");
                DataAccessEnterprise.AddParameter(_command, "@PROJ_ID", PROJ_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int ID = (int)reader["PROJ_ID"];
                        int IDInvestment = (int)reader["INVE_ID"];
                        string Name = (string)reader["PROJ_Name"];
                        int OverallProfitability = (int)reader["PROJ_OverallProfitability"];
                        int ExecutionTime = (int)reader["PROJ_ExecutionTime"];
                        decimal InvestmentCapital = (decimal)reader["PROJ_InvestmentCapital"];
                        string Modality = (string)reader["PROJ_Modality"];
                        DateTime PromotionDate = (DateTime)reader["PROJ_PromotionDate"];
                        DateTime ExpirationDate = (DateTime)reader["PROJ_ExpirationDate"];
                        int Progress = (int)reader["PROJ_Progress"];
                        string Description = (string)reader["PROJ_Description"];
                            char State = Convert.ToChar( reader["PROJ_State"]);

                        string Usercrea = (string)reader["audi_usercrea"];
                        DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                        string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _project = new Project()
                        {
                            PROJ_ID = ID,
                            INVE_ID = IDInvestment,
                            PROJ_Name = Name,
                            PROJ_OverallProfitability = OverallProfitability,
                            PROJ_ExecutionTime = ExecutionTime,
                            PROJ_InvestmentCapital = InvestmentCapital,
                            PROJ_Modality = Modality,
                            PROJ_PromotionDate = PromotionDate,
                            PROJ_ExpirationDate = ExpirationDate,
                            PROJ_Progress = Progress,
                            PROJ_Description = Description,
                            PROJ_State = State,
                            AUDI_UserCrea = Usercrea,
                            AUDI_FechCrea = Fechcrea,
                            AUDI_UserModi = Usermodi,
                            AUDI_FechModi = Fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_project == null)
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
            return _project;
        }

        public List<Project> SelectAll(out LogError logError)
        {
            logError = null;
            List<Project> _projectList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Projects_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {

            _projectList = new List<Project>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["PROJ_ID"];
                            int IDInvestment = (int)reader["INVE_ID"];
                            string Name = (string)reader["PROJ_Name"];
                            int OverallProfitability = (int)reader["PROJ_OverallProfitability"];
                            int ExecutionTime = (int)reader["PROJ_ExecutionTime"];
                            decimal InvestmentCapital = (decimal)reader["PROJ_InvestmentCapital"];
                            string Modality = (string)reader["PROJ_Modality"];
                            DateTime PromotionDate = (DateTime)reader["PROJ_PromotionDate"];
                            DateTime ExpirationDate = (DateTime)reader["PROJ_ExpirationDate"];
                            int Progress = (int)reader["PROJ_Progress"];
                            string Description = (string)reader["PROJ_Description"];
                            char State = Convert.ToChar( reader["PROJ_State"]);

                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _project = new Project()
                            {
                                PROJ_ID = ID,
                                INVE_ID = IDInvestment,
                                PROJ_Name = Name,
                                PROJ_OverallProfitability = OverallProfitability,
                                PROJ_ExecutionTime = ExecutionTime,
                                PROJ_InvestmentCapital = InvestmentCapital,
                                PROJ_Modality = Modality,
                                PROJ_PromotionDate = PromotionDate,
                                PROJ_ExpirationDate = ExpirationDate,
                                PROJ_Progress = Progress,
                                PROJ_Description = Description,
                                PROJ_State = State,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _projectList.Add(_project);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_projectList == null)
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
            return _projectList;
        }
        public List<Project> SelectByIdInvestment(int INVE_ID, out LogError logError)
        {
            logError = null;
            List<Project> _projectList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Projects_SelectAllByINVE_ID");
                DataAccessEnterprise.AddParameter(_command, "@INVE_ID", INVE_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {

            _projectList = new List<Project>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["PROJ_ID"];
                            int IDInvestment = (int)reader["INVE_ID"];
                            string Name = (string)reader["PROJ_Name"];
                            int OverallProfitability = (int)reader["PROJ_OverallProfitability"];
                            int ExecutionTime = (int)reader["PROJ_ExecutionTime"];
                            decimal InvestmentCapital = (decimal)reader["PROJ_InvestmentCapital"];
                            string Modality = (string)reader["PROJ_Modality"];
                            DateTime PromotionDate = (DateTime)reader["PROJ_PromotionDate"];
                            DateTime ExpirationDate = (DateTime)reader["PROJ_ExpirationDate"];
                            int Progress = (int)reader["PROJ_Progress"];
                            string Description = (string)reader["PROJ_Description"];
                            char State = Convert.ToChar( reader["PROJ_State"]);

                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _project = new Project()
                            {
                                PROJ_ID = ID,
                                INVE_ID = IDInvestment,
                                PROJ_Name = Name,
                                PROJ_OverallProfitability = OverallProfitability,
                                PROJ_ExecutionTime = ExecutionTime,
                                PROJ_InvestmentCapital = InvestmentCapital,
                                PROJ_Modality = Modality,
                                PROJ_PromotionDate = PromotionDate,
                                PROJ_ExpirationDate = ExpirationDate,
                                PROJ_Progress = Progress,
                                PROJ_Description = Description,
                                PROJ_State = State,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _projectList.Add(_project);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_projectList == null)
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
            return _projectList;
        }
    }
}
