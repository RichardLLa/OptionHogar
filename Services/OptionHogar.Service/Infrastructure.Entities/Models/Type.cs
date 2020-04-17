using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Type
    {
        #region Variables

        private string _TYPE_CodTable;
        private string _TYPE_CodType;
        private string _TYPE_Desc1;
        private string _TYPE_Desc2;
        private int _TYPE_Num1;
        private int _TYPE_Num2;
        private char _TYPE_Status;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;

        #endregion

        #region Properties
        public string TYPE_CodTable { get => _TYPE_CodTable; set => _TYPE_CodTable = value; }
        public string TYPE_CodType { get => _TYPE_CodType; set => _TYPE_CodType = value; }
        public string TYPE_Desc1 { get => _TYPE_Desc1; set => _TYPE_Desc1 = value; }
        public string TYPE_Desc2 { get => _TYPE_Desc2; set => _TYPE_Desc2 = value; }
        public int TYPE_Num1 { get => _TYPE_Num1; set => _TYPE_Num1 = value; }
        public int TYPE_Num2 { get => _TYPE_Num2; set => _TYPE_Num2 = value; }
        public char TYPE_Status { get => _TYPE_Status; set => _TYPE_Status = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }


        #endregion
    }
}
