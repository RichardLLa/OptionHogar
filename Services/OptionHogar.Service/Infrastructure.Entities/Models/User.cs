using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class User
    {

        #region Variables
        private int _USER_ID;
        private int _PERS_ID;
        private string _USER_Email;
        private string _USER_Password;
        private bool _USER_Admin;
        private char _USER_Status;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;
        #endregion

        #region Properties
        public int USER_ID { get => _USER_ID; set => _USER_ID = value; }
        public int PERS_ID { get => _PERS_ID; set => _PERS_ID = value; }
        public string USER_Email { get => _USER_Email; set => _USER_Email = value; }
        public string USER_Password { get => _USER_Password; set => _USER_Password = value; }
        public bool USER_Admin { get => _USER_Admin; set => _USER_Admin = value; }
        public char USER_Status { get => _USER_Status; set => _USER_Status = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }


        #endregion
    }
}
