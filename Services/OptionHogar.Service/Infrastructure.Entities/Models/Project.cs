using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Project
    {
        #region Variables

        private int _PROJ_ID;
        private int _INVE_ID;
        private string _PROJ_Name;
        private int _PROJ_OverallProfitability;
        private int _PROJ_ExecutionTime;
        private decimal _PROJ_InvestmentCapital;
        private string _PROJ_Modality;
        private DateTime _PROJ_PromotionDate;
        private DateTime _PROJ_ExpirationDate;
        private int _PROJ_Progress;
        private string _PROJ_Description;
        private char _PROJ_State;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;


        #endregion
        #region Properties

        public int PROJ_ID { get => _PROJ_ID; set => _PROJ_ID = value; }
        public int INVE_ID { get => _INVE_ID; set => _INVE_ID = value; }
        public string PROJ_Name { get => _PROJ_Name; set => _PROJ_Name = value; }
        public int PROJ_OverallProfitability { get => _PROJ_OverallProfitability; set => _PROJ_OverallProfitability = value; }
        public int PROJ_ExecutionTime { get => _PROJ_ExecutionTime; set => _PROJ_ExecutionTime = value; }
        public decimal PROJ_InvestmentCapital { get => _PROJ_InvestmentCapital; set => _PROJ_InvestmentCapital = value; }
        public string PROJ_Modality { get => _PROJ_Modality; set => _PROJ_Modality = value; }
        public DateTime PROJ_PromotionDate { get => _PROJ_PromotionDate; set => _PROJ_PromotionDate = value; }
        public DateTime PROJ_ExpirationDate { get => _PROJ_ExpirationDate; set => _PROJ_ExpirationDate = value; }
        public int PROJ_Progress { get => _PROJ_Progress; set => _PROJ_Progress = value; }
        public string PROJ_Description { get => _PROJ_Description; set => _PROJ_Description = value; }
        public char PROJ_State { get => _PROJ_State; set => _PROJ_State = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }

        #endregion
    }
}
