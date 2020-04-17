using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Person
    {
        #region Variables
        private int _PERS_ID;
        private string _PERS_Names;
        private string _PERS_LastName;
        private string _PERS_MotherLastName;
        private DateTime _PERS_BirthDate;
        private string _TYPE_TabGEN;
        private string _TYPE_CodGEN;
        private string _TYPE_TabDOC;
        private string _TYPE_CodDOC;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;
        #endregion

        #region Properties
        public int PERS_ID { get => _PERS_ID; set => _PERS_ID = value; }
        public string PERS_Names { get => _PERS_Names; set => _PERS_Names = value; }
        public string PERS_LastName { get => _PERS_LastName; set => _PERS_LastName = value; }
        public string PERS_MotherLastName { get => _PERS_MotherLastName; set => _PERS_MotherLastName = value; }
        public DateTime PERS_BirthDate { get => _PERS_BirthDate; set => _PERS_BirthDate = value; }
        public string TYPE_TabGEN { get => _TYPE_TabGEN; set => _TYPE_TabGEN = value; }
        public string TYPE_CodGEN { get => _TYPE_CodGEN; set => _TYPE_CodGEN = value; }
        public string TYPE_TabDOC { get => _TYPE_TabDOC; set => _TYPE_TabDOC = value; }
        public string TYPE_CodDOC { get => _TYPE_CodDOC; set => _TYPE_CodDOC = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }




        #endregion
    }
}
