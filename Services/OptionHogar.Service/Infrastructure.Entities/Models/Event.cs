using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Event
    {
        #region Variables
        private int _EVEN_ID;
        private int _PROJ_ID;
        private DateTime _EVEN_StartDate;
        private DateTime _EVEN_EndingDate;
        private char _EVEN_State;
        private string _EVEN_Title;
        private string _EVEN_Description;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;
        #endregion

        #region Properties
        public int EVEN_ID { get => _EVEN_ID; set => _EVEN_ID = value; }
        public int PROJ_ID { get => _PROJ_ID; set => _PROJ_ID = value; }
        public DateTime EVEN_StartDate { get => _EVEN_StartDate; set => _EVEN_StartDate = value; }
        public DateTime EVEN_EndingDate { get => _EVEN_EndingDate; set => _EVEN_EndingDate = value; }
        public char EVEN_State { get => _EVEN_State; set => _EVEN_State = value; }
        public string EVEN_Title { get => _EVEN_Title; set => _EVEN_Title = value; }
        public string EVEN_Description { get => _EVEN_Description; set => _EVEN_Description = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }



        #endregion
    }
}
