using Infrastructure.DataAccess.Manager;
using Infrastructure.Entities.Util;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Infrastructure.Entities.Models;
using Type = Infrastructure.Entities.Models.Type;

namespace OptionHogar.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthService : IAuthService
    {

        #region Variables

        EventManager DAEvent = new EventManager();
        InvestmentManager DAInvestment = new InvestmentManager();
        LogManager DALog = new LogManager();
        MediaManager DAMedia = new MediaManager();
        ParamManager DAParam = new ParamManager();
        PersonManager DAPerson = new PersonManager();
        ProjectManager DAProject = new ProjectManager();
        SessionKeyManager DASessionKey = new SessionKeyManager();
        TypeManager DAType = new TypeManager();
        UserManager DAUser = new UserManager();

        ServiceData myServiceData = new ServiceData();

        #endregion

        #region Events

        public bool Event_Save(Event eventModel, out LogError logError)
        {
            try
            {
                return DAEvent.Insert(eventModel, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Event_Modified(Event eventModel, out LogError logError)
        {
            try
            {
                return DAEvent.Update(eventModel, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public bool Event_Delete(int INVE_ID)
        {
            try
            {
                return DAEvent.Delete(INVE_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }


        public Event Event_SelectById(int id)
        {
            try
            {
                return DAEvent.SelectById(id);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Event> Event_SelectAll()
        {
            try
            {
                return DAEvent.SelectAll();
            }
            catch (Exception)
            { throw; }
        }
        public List<Event> Event_SelectByProjectId(int project_id)
        {
            try
            {
                return DAEvent.SelectByProjectId(project_id);
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region Investments
        public bool Investment_Save(Investment investment, out LogError logError)
        {
            try
            {
                return DAInvestment.Insert(investment, out logError);
            }
            catch (Exception)
            { throw; }
        }
        public bool Investment_Modified(Investment investment, out LogError logError)
        {
            try
            {
                return DAInvestment.Update(investment, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public bool Investment_Delete(int INVE_ID)
        {
            try
            {
                return DAInvestment.Delete(INVE_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public Investment Investment_SelectById(int INVE_ID)
        {
            try
            {
                return DAInvestment.SelectById(INVE_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Investment> Investment_SelectAll()
        {
            try
            {
                return DAInvestment.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public List<Investment> Investment_SelectByUserId(int userId)
        {
            try
            {
                return DAInvestment.SelectByUserId(userId);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        #endregion



        #region Logs

        public bool Log_Save(Log Item, out LogError logError)
        {
            try
            {
                return DALog.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Log_Modified(Log Item, out LogError logError)
        {
            try
            {
                return DALog.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Log_Delete(int LOG_ID)
        {
            try
            {
                return DALog.Delete(LOG_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public Log Log_SelectById(int id)
        {
            try
            {
                return DALog.SelectById(id);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Log> Log_SelectAll()
        {
            try
            {
                return DALog.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        #endregion

        #region Media

        public bool Media_Save(Media Item, out LogError logError)
        {
            try
            {
                return DAMedia.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Media_Modified(Media Item, out LogError logError)
        {
            try
            {
                return DAMedia.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Media_Delete(int LOG_ID)
        {
            try
            {
                return DAMedia.Delete(LOG_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public Media Media_SelectById(int id)
        {
            try
            {
                return DAMedia.SelectById(id);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Media> Media_SelectAll()
        {
            try
            {
                return DAMedia.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Media> Media_SelectByIdEvent(int idEvent)
        {
            try
            {
                return DAMedia.SelectByIdEvent(idEvent);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Media> Media_SelectByIdProject(int idProject)
        {
            try
            {
                return DAMedia.SelectByIdProject(idProject);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Media> Media_SelectByIdTypeMED(string tabMED, string codMED)
        {
            try
            {
                return DAMedia.SelectByIdTypeMED(tabMED, codMED);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        #endregion

        #region Params

        public bool Param_Save(Param Item, out LogError logError)
        {
            try
            {
                return DAParam.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Param_Modified(Param Item, out LogError logError)
        {
            try
            {
                return DAParam.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Param_Delete(int PARA_ID)
        {
            try
            {
                return DAParam.Delete(PARA_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public Param Param_SelectById(int PARA_ID)
        {
            try
            {
                return DAParam.SelectById(PARA_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Param> Param_SelectAll()
        {
            try
            {
                return DAParam.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        #endregion

        #region Persons

        public bool Person_Save(Person Item, out LogError logError)
        {
            try
            {
                return DAPerson.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Person_Modified(Person Item, out LogError logError)
        {
            try
            {
                return DAPerson.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Person_Delete(int PERS_ID)
        {
            try
            {
                return DAPerson.Delete(PERS_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public Person Person_SelectById(int PERS_ID)
        {
            try
            {
                return DAPerson.SelectById(PERS_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Person> Person_SelectAll()
        {
            try
            {
                return DAPerson.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Person> Person_SelectByIdTypeDOC(string tabDOC, string codDOC)
        {
            try
            {
                return DAPerson.SelectByIdTypeDOC(tabDOC, codDOC);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Person> Person_SelectByIdTypeGEN(string tabGEN, string codGEN)

        {
            try
            {
                return DAPerson.SelectByIdTypeGEN(tabGEN, codGEN);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        #endregion

        #region Projects

        public bool Project_Save(Project Item, out LogError logError)
        {
            try
            {
                return DAProject.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public bool Project_Modified(Project Item, out LogError logError)
        {
            try
            {
                return DAProject.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Project_Delete(int PROJ_ID)
        {
            try
            {
                return DAProject.Delete(PROJ_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public Project Project_SelectById(int PROJ_ID)
        {
            try
            {
                return DAProject.SelectById(PROJ_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Project> Project_SelectAll()
        {
            try
            {
                return DAProject.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Project> Project_SelectByIdInvestment(int INVE_ID)
        {
            try
            {
                return DAProject.SelectByIdInvestment(INVE_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        #endregion

        #region Session Keys

        public bool SessionKey_Save(SessionKey Item, out LogError logError)
        {
            try
            {
                return DASessionKey.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool SessionKey_Modified(SessionKey Item, out LogError logError)
        {
            try
            {
                return DASessionKey.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool SessionKey_Delete(int SESS_ID)
        {
            try
            {
                return DASessionKey.Delete(SESS_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public SessionKey SessionKey_SelectById(int SESS_ID)
        {
            try
            {
                return DASessionKey.SelectById(SESS_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<SessionKey> SessionKey_SelectAll()
        {
            try
            {
                return DASessionKey.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        #endregion

        #region Types

        public bool Type_Save(Type Item, out LogError logError)
        {
            try
            {
                return DAType.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Type_Modified(Type Item, out LogError logError)
        {
            try
            {
                return DAType.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Type_Delete(string codTable, string codType)
        {
            try
            {
                return DAType.Delete(codTable, codType);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public Type Type_SelectById(string codTable, string codType)
        {
            try
            {
                return DAType.SelectById(codTable, codType);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<Type> Type_SelectAll()
        {
            try
            {
                return DAType.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        #endregion

        #region Users

        public bool Save(User Item, out LogError logError)
        {
            try
            {
                return DAUser.Insert(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Update(User Item, out LogError logError)
        {
            try
            {
                return DAUser.Update(Item, out logError);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public bool Delete(int USER_ID)
        {
            try
            {
                return DAUser.Delete(USER_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }

        public User SelectById(int USER_ID)
        {
            try
            {
                return DAUser.SelectById(USER_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<User> SelectAll()
        {
            try
            {
                return DAUser.SelectAll();
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        public List<User> SelectByIdPerson(int PERS_ID)
        {
            try
            {
                return DAUser.SelectByIdPerson(PERS_ID);
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occured. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceData>(myServiceData, ex.ToString());
            }
        }
        #endregion

    }
}
