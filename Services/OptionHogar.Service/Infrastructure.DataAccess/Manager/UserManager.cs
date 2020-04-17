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
    public class UserManager
    {


        public bool Insert(User Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Users_Insert");

                DataAccessEnterprise.AddParameter(_command, "@PERS_ID", Item.PERS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Email", Item.USER_Email, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Password", Item.USER_Password, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Admin", Item.USER_Admin, SqlDbType.Bit, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Status", Item.USER_Status, SqlDbType.Char, 1, ParameterDirection.Input);
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

        public bool Update(User Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Users_Update");
                DataAccessEnterprise.AddParameter(_command, "@USER_ID", Item.USER_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_ID", Item.PERS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Email", Item.USER_Email, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Password", Item.USER_Password, SqlDbType.VarChar, 200, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Admin", Item.USER_Admin, SqlDbType.Bit, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@USER_Status", Item.USER_Status, SqlDbType.Char, 1, ParameterDirection.Input);
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
            return false;
        }

        public bool Delete(int USER_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Users_Delete");
                DataAccessEnterprise.AddParameter(_command, "@USER_ID", USER_ID, SqlDbType.Int, 1, ParameterDirection.Input);
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

        public User SelectById(int USER_ID, out LogError logError)
        {
            logError = null;
            User _user = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Users_Select");
                DataAccessEnterprise.AddParameter(_command, "@USER_ID", USER_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int ID = (int)reader["USER_ID"];
                        int IDPers = (int)reader["PERS_ID"];
                        string Email = (string)reader["USER_Email"];
                        string Password = (string)reader["USER_Password"];
                        bool Admin = (bool)reader["USER_Admin"];
                        char Status = Convert.ToChar(reader["USER_Status"]);
                        string audi_usercrea = (string)reader["audi_usercrea"];
                        DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                        string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _user = new User()
                        {
                            USER_ID = ID,
                            PERS_ID = IDPers,
                            USER_Email = Email,
                            USER_Password = Password,
                            USER_Admin = Admin,
                            USER_Status = Status,
                            AUDI_UserCrea = audi_usercrea,
                            AUDI_FechCrea = audi_fechcrea,
                            AUDI_UserModi = audi_usermodi,
                            AUDI_FechModi = audi_fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_user == null)
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
            return _user;

        }

        public List<User> SelectAll(out LogError logError)
        {
            logError = null;
            List<User> _userList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Users_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _userList = new List<User>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["USER_ID"];
                            int IDPers = (int)reader["PERS_ID"];
                            string Email = (string)reader["USER_Email"];
                            string Password = (string)reader["USER_Password"];
                            bool Admin = (bool)reader["USER_Admin"];
                            char Status = Convert.ToChar(reader["USER_Status"]);
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _user = new User()
                            {
                                USER_ID = ID,
                                PERS_ID = IDPers,
                                USER_Email = Email,
                                USER_Password = Password,
                                USER_Admin = Admin,
                                USER_Status = Status,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _userList.Add(_user);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_userList == null)
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
            return _userList;


        }

        public List<User> SelectByIdPerson(int PERS_ID, out LogError logError)
        {
            logError = null;
            List<User> _userList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Users_SelectAllByPERS_ID");
                DataAccessEnterprise.AddParameter(_command, "@PERS_ID", PERS_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _userList = new List<User>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["USER_ID"];
                            int IDPers = (int)reader["PERS_ID"];
                            string Email = (string)reader["USER_Email"];
                            string Password = (string)reader["USER_Password"];
                            bool Admin = (bool)reader["USER_Admin"];
                            char Status = Convert.ToChar(reader["USER_Status"]);
                            string audi_usercrea = (string)reader["audi_usercrea"];
                            DateTime audi_fechcrea = (DateTime)reader["audi_fechcrea"];
                            string audi_usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? audi_fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _user = new User()
                            {
                                USER_ID = ID,
                                PERS_ID = IDPers,
                                USER_Email = Email,
                                USER_Password = Password,
                                USER_Admin = Admin,
                                USER_Status = Status,
                                AUDI_UserCrea = audi_usercrea,
                                AUDI_FechCrea = audi_fechcrea,
                                AUDI_UserModi = audi_usermodi,
                                AUDI_FechModi = audi_fechmodi
                            };
                            _userList.Add(_user);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_userList == null)
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
            return _userList;

        }
    }
}
