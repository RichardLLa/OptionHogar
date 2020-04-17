using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Infrastructure.Entities.Models;
using Infrastructure.Entities.Util;
using Type = Infrastructure.Entities.Models.Type;

namespace OptionHogar.Service
{
    [ServiceContract]
    interface IAuthService
    {



        #region Events

        [OperationContract]
        bool Event_Save(Event eventModel, out LogError logError);
        [OperationContract]
        bool Event_Modified(Event eventModel, out LogError logError);
        [OperationContract]
        bool Event_Delete(int INVE_ID);
        [OperationContract]
        Event Event_SelectById(int id);
        [OperationContract]
        List<Event> Event_SelectAll();
        [OperationContract]
        List<Event> Event_SelectByProjectId(int project_id);
        #endregion

        #region Investments
        bool Investment_Save(Investment investment, out LogError logError);
        bool Investment_Modified(Investment investment, out LogError logError);
        bool Investment_Delete(int INVE_ID);
        Investment Investment_SelectById(int INVE_ID);
        List<Investment> Investment_SelectAll();
        List<Investment> Investment_SelectByUserId(int userId);
        #endregion



        #region Logs

        [OperationContract]
        bool Log_Save(Log Item, out LogError logError);
        [OperationContract]
        bool Log_Modified(Log Item, out LogError logError);
        [OperationContract]
        bool Log_Delete(int LOG_ID);
        [OperationContract]
        Log Log_SelectById(int id);
        [OperationContract]
        List<Log> Log_SelectAll();
        #endregion

        #region Media

        [OperationContract]
        bool Media_Save(Media Item, out LogError logError);
        [OperationContract]
        bool Media_Modified(Media Item, out LogError logError);
        [OperationContract]
        bool Media_Delete(int LOG_ID);
        [OperationContract]
        Media Media_SelectById(int id);
        [OperationContract]
        List<Media> Media_SelectAll();
        [OperationContract]
        List<Media> Media_SelectByIdEvent(int idEvent);
        [OperationContract]
        List<Media> Media_SelectByIdProject(int idProject);
        [OperationContract]
        List<Media> Media_SelectByIdTypeMED(string tabMED, string codMED);
        #endregion

        #region Params

        [OperationContract]
        bool Param_Save(Param Item, out LogError logError);
        [OperationContract]
        bool Param_Modified(Param Item, out LogError logError);
        [OperationContract]
        bool Param_Delete(int PARA_ID);
        [OperationContract]
        Param Param_SelectById(int PARA_ID);
        [OperationContract]
        List<Param> Param_SelectAll();

        #endregion

        #region Persons

        [OperationContract]
        bool Person_Save(Person Item, out LogError logError);
        [OperationContract]
        bool Person_Modified(Person Item, out LogError logError);
        [OperationContract]
        bool Person_Delete(int PERS_ID);
        [OperationContract]
        Person Person_SelectById(int PERS_ID);
        [OperationContract]
        List<Person> Person_SelectAll();
        [OperationContract]
        List<Person> Person_SelectByIdTypeDOC(string tabDOC, string codDOC);
        [OperationContract]
        List<Person> Person_SelectByIdTypeGEN(string tabGEN, string codGEN);

        #endregion

        #region Projects

        [OperationContract]
        bool Project_Save(Project Item, out LogError logError);
        [OperationContract]
        bool Project_Modified(Project Item, out LogError logError);
        [OperationContract]
        bool Project_Delete(int PROJ_ID);
        [OperationContract]
        Project Project_SelectById(int PROJ_ID);
        [OperationContract]
        List<Project> Project_SelectAll();
        [OperationContract]
        List<Project> Project_SelectByIdInvestment(int INVE_ID);
        #endregion

        #region Session Keys

        [OperationContract]
        bool SessionKey_Save(SessionKey Item, out LogError logError);
        [OperationContract]
        bool SessionKey_Modified(SessionKey Item, out LogError logError);
        [OperationContract]
        bool SessionKey_Delete(int SESS_ID);
        [OperationContract]
        SessionKey SessionKey_SelectById(int SESS_ID);
        [OperationContract]
        List<SessionKey> SessionKey_SelectAll();

        #endregion

        #region Types

        [OperationContract]
        bool Type_Save(Type Item, out LogError logError);
        [OperationContract]
        bool Type_Modified(Type Item, out LogError logError);
        [OperationContract]
        bool Type_Delete(string codTable, string codType);
        [OperationContract]
        Type Type_SelectById(string codTable, string codType);
        [OperationContract]
        List<Type> Type_SelectAll();
        #endregion

        #region Users

        [OperationContract]
        bool Save(User Item, out LogError logError);
        [OperationContract]
        bool Update(User Item, out LogError logError);
        [OperationContract]
        bool Delete(int USER_ID);
        [OperationContract]
        User SelectById(int USER_ID);
        [OperationContract]
        List<User> SelectAll();
        [OperationContract]
        List<User> SelectByIdPerson(int PERS_ID);
        #endregion

    }

    [DataContract]
    public class ServiceData
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string ErrorDetails { get; set; }
    }

}
