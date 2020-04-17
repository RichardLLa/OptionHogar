using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class SessionKey
    {

        #region Variables

        private int _SESS_ID;
        private DateTime _SESS_Date;
        private string _SESS_PrivateKeyXML;
        private string _SESS_PublicKeyXML;
        private string _SESS_PrivateKeyPEM;
        private string _SESS_PublicKeyPEM;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;

        #endregion

        #region Properties

        public int SESS_ID { get => _SESS_ID; set => _SESS_ID = value; }
        public DateTime SESS_Date { get => _SESS_Date; set => _SESS_Date = value; }
        public string SESS_PrivateKeyXML { get => _SESS_PrivateKeyXML; set => _SESS_PrivateKeyXML = value; }
        public string SESS_PublicKeyXML { get => _SESS_PublicKeyXML; set => _SESS_PublicKeyXML = value; }
        public string SESS_PrivateKeyPEM { get => _SESS_PrivateKeyPEM; set => _SESS_PrivateKeyPEM = value; }
        public string SESS_PublicKeyPEM { get => _SESS_PublicKeyPEM; set => _SESS_PublicKeyPEM = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }


        #endregion
    }
}
