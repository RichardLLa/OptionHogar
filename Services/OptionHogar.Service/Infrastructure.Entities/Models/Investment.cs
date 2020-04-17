using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Investment
    {

        #region Variables
        private int _INVE_ID;
        private int _USER_ID;
        private decimal _INVE_Amount;
        private DateTime _INVE_Date;
        private string _INVE_Observation;
        private int _INVE_CostEffectiveness;
        private char _INVE_State;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;
        #endregion

        public int INVE_ID { get => _INVE_ID; set => _INVE_ID = value; }
        public int USER_ID { get => _USER_ID; set => _USER_ID = value; }
        public decimal INVE_Amount { get => _INVE_Amount; set => _INVE_Amount = value; }
        public DateTime INVE_Date { get => _INVE_Date; set => _INVE_Date = value; }
        public string INVE_Observation { get => _INVE_Observation; set => _INVE_Observation = value; }
        public int INVE_CostEffectiveness { get => _INVE_CostEffectiveness; set => _INVE_CostEffectiveness = value; }
        public char INVE_State { get => _INVE_State; set => _INVE_State = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }

        #region Properties

        #endregion

    }
}
