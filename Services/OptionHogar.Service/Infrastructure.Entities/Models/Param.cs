using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Param
    {
        #region Variables
        private int _PARA_ID;
        private string _PARA_Key;
        private string _PARA_Value;
        private string _PARA_Description;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;
        #endregion
        #region Properties
        public int PARA_ID { get => _PARA_ID; set => _PARA_ID = value; }
        public string PARA_Key { get => _PARA_Key; set => _PARA_Key = value; }
        public string PARA_Value { get => _PARA_Value; set => _PARA_Value = value; }
        public string PARA_Description { get => _PARA_Description; set => _PARA_Description = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }
        #endregion
    }
}
