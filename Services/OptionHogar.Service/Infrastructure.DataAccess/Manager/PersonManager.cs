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
    public class PersonManager
    {

        public bool Insert(Person Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Persons_Insert");
                //  _command.Connection = DataAccessEnterprise.BeginConnection();
                //  {
                DataAccessEnterprise.AddParameter(_command, "@PERS_Names", Item.PERS_Names, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_LastName", Item.PERS_LastName, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_MotherLastName", Item.PERS_MotherLastName, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_BirthDate", Item.PERS_BirthDate, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabGEN", Item.TYPE_TabGEN, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodGEN", Item.TYPE_CodGEN, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabDOC", Item.TYPE_TabDOC, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodDOC", Item.TYPE_CodDOC, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_UserCrea", Item.AUDI_UserCrea, SqlDbType.VarChar, 20, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@AUDI_FechCrea", Item.AUDI_FechCrea, SqlDbType.Date, 8, ParameterDirection.Input);

                if (DataAccessEnterprise.ExecuteNonQuery(_command, null) > 0)
                {
                    return true;
                }
                // }
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

        public bool Update(Person Item, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Persons_Update");
                DataAccessEnterprise.AddParameter(_command, "@PERS_ID", Item.PERS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_Names", Item.PERS_Names, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_LastName", Item.PERS_LastName, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_MotherLastName", Item.PERS_MotherLastName, SqlDbType.VarChar, 25, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@PERS_BirthDate", Item.PERS_BirthDate, SqlDbType.DateTime, 8, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabGEN", Item.TYPE_TabGEN, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodGEN", Item.TYPE_CodGEN, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabDOC", Item.TYPE_TabDOC, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodDOC", Item.TYPE_CodDOC, SqlDbType.VarChar, 3, ParameterDirection.Input);
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

        public bool Delete(int PERS_ID, out LogError logError)
        {
            logError = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Persons_Delete");
                DataAccessEnterprise.AddParameter(_command, "@PERS_ID", PERS_ID, SqlDbType.Int, 1, ParameterDirection.Input);
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
        public Person SelectById(int PERS_ID, out LogError logError)
        {
            logError = null;
            Person _person = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Persons_Select");
                DataAccessEnterprise.AddParameter(_command, "@PERS_ID", PERS_ID, SqlDbType.Int, 1, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int ID = (int)reader["PERS_ID"];
                        string Names = (string)reader["PERS_Names"];
                        string LastName = (string)reader["PERS_LastName"];
                        string MotherLastName = (string)reader["PERS_MotherLastName"];
                        DateTime BirthDate = (DateTime)reader["PERS_BirthDate"];
                        string TabGEN = (string)reader["TYPE_TabGEN"];
                        string CodGEN = (string)reader["TYPE_CodGEN"];
                        string TabDOC = (string)reader["TYPE_TabDOC"];
                        string CodDOC = (string)reader["TYPE_CodDOC"];
                        string Usercrea = (string)reader["audi_usercrea"];
                        DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                        string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                        DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                        _person = new Person()
                        {
                            PERS_ID = ID,
                            PERS_Names = Names,
                            PERS_LastName = LastName,
                            PERS_MotherLastName = MotherLastName,
                            PERS_BirthDate = BirthDate,
                            TYPE_TabGEN = TabGEN,
                            TYPE_CodGEN = CodGEN,
                            TYPE_TabDOC = TabDOC,
                            TYPE_CodDOC = TabDOC,
                            AUDI_UserCrea = Usercrea,
                            AUDI_FechCrea = Fechcrea,
                            AUDI_UserModi = Usermodi,
                            AUDI_FechModi = Fechmodi
                        };

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_person == null)
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
            return _person;
        }

        public List<Person> SelectAll(out LogError logError)
        {
            logError = null;
            List<Person> _personList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Persons_SelectAll");

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _personList = new List<Person>();
                        while (reader.Read())
                        {
                            int ID = (int)reader["PERS_ID"];
                            string Names = (string)reader["PERS_Names"];
                            string LastName = (string)reader["PERS_LastName"];
                            string MotherLastName = (string)reader["PERS_MotherLastName"];
                            DateTime BirthDate = (DateTime)reader["PERS_BirthDate"];
                            string TabGEN = (string)reader["TYPE_TabGEN"];
                            string CodGEN = (string)reader["TYPE_CodGEN"];
                            string TabDOC = (string)reader["TYPE_TabDOC"];
                            string CodDOC = (string)reader["TYPE_CodDOC"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _person = new Person()
                            {
                                PERS_ID = ID,
                                PERS_Names = Names,
                                PERS_LastName = LastName,
                                PERS_MotherLastName = MotherLastName,
                                PERS_BirthDate = BirthDate,
                                TYPE_TabGEN = TabGEN,
                                TYPE_CodGEN = CodGEN,
                                TYPE_TabDOC = TabDOC,
                                TYPE_CodDOC = TabDOC,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _personList.Add(_person);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_personList == null)
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
            return _personList;
        }
        public List<Person> SelectByIdTypeDOC(string tabDOC, string codDOC, out LogError logError)
        {
            logError = null;
            List<Person> _personList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Persons_SelectAllByTypeDOC");
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabDOC", tabDOC, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodDOC", codDOC, SqlDbType.VarChar, 3, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _personList = new List<Person>();
                        while (reader.Read())
                        {

                            int ID = (int)reader["PERS_ID"];
                            string Names = (string)reader["PERS_Names"];
                            string LastName = (string)reader["PERS_LastName"];
                            string MotherLastName = (string)reader["PERS_MotherLastName"];
                            DateTime BirthDate = (DateTime)reader["PERS_BirthDate"];
                            string TabGEN = (string)reader["TYPE_TabGEN"];
                            string CodGEN = (string)reader["TYPE_CodGEN"];
                            string TabDOC = (string)reader["TYPE_TabDOC"];
                            string CodDOC = (string)reader["TYPE_CodDOC"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _person = new Person()
                            {
                                PERS_ID = ID,
                                PERS_Names = Names,
                                PERS_LastName = LastName,
                                PERS_MotherLastName = MotherLastName,
                                PERS_BirthDate = BirthDate,
                                TYPE_TabGEN = TabGEN,
                                TYPE_CodGEN = CodGEN,
                                TYPE_TabDOC = TabDOC,
                                TYPE_CodDOC = TabDOC,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _personList.Add(_person);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_personList == null)
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
            return _personList;
        }
        public List<Person> SelectByIdTypeGEN(string tabGEN, string codGEN, out LogError logError)
        {
            logError = null;
            List<Person> _personList = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("Persons_SelectAllByTypeGEN");
                DataAccessEnterprise.AddParameter(_command, "@TYPE_TabGEN", tabGEN, SqlDbType.VarChar, 3, ParameterDirection.Input);
                DataAccessEnterprise.AddParameter(_command, "@TYPE_CodGEN", codGEN, SqlDbType.VarChar, 3, ParameterDirection.Input);

                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _personList = new List<Person>();
                        while (reader.Read())
                        {

                            int ID = (int)reader["PERS_ID"];
                            string Names = (string)reader["PERS_Names"];
                            string LastName = (string)reader["PERS_LastName"];
                            string MotherLastName = (string)reader["PERS_MotherLastName"];
                            DateTime BirthDate = (DateTime)reader["PERS_BirthDate"];
                            string TabGEN = (string)reader["TYPE_TabGEN"];
                            string CodGEN = (string)reader["TYPE_CodGEN"];
                            string TabDOC = (string)reader["TYPE_TabDOC"];
                            string CodDOC = (string)reader["TYPE_CodDOC"];
                            string Usercrea = (string)reader["audi_usercrea"];
                            DateTime Fechcrea = (DateTime)reader["audi_fechcrea"];
                            string Usermodi = reader["audi_usermodi"] == DBNull.Value ? null : (string)reader["audi_usermodi"];
                            DateTime? Fechmodi = reader["audi_fechmodi"] == DBNull.Value ? null : (DateTime?)reader["audi_fechmodi"];

                            var _person = new Person()
                            {
                                PERS_ID = ID,
                                PERS_Names = Names,
                                PERS_LastName = LastName,
                                PERS_MotherLastName = MotherLastName,
                                PERS_BirthDate = BirthDate,
                                TYPE_TabGEN = TabGEN,
                                TYPE_CodGEN = CodGEN,
                                TYPE_TabDOC = TabDOC,
                                TYPE_CodDOC = TabDOC,
                                AUDI_UserCrea = Usercrea,
                                AUDI_FechCrea = Fechcrea,
                                AUDI_UserModi = Usermodi,
                                AUDI_FechModi = Fechmodi
                            };
                            _personList.Add(_person);
                        }

                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                if (_personList == null)
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
            return _personList;
        }


    }
}
