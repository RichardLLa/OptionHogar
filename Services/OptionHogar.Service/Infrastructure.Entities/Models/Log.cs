using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Log
    {


        #region Variables
        private int _LOG_ID;
        private DateTime _LOG_Date;
        private string _TYPE_TabAUD;
        private string _TYPE_CodAUD;
        private string _LOG_Object;
        private string _LOG_Text;
        #endregion

        #region Properties
        public int LOG_ID { get => _LOG_ID; set => _LOG_ID = value; }
        public DateTime LOG_Date { get => _LOG_Date; set => _LOG_Date = value; }
        public string TYPE_TabAUD { get => _TYPE_TabAUD; set => _TYPE_TabAUD = value; }
        public string TYPE_CodAUD { get => _TYPE_CodAUD; set => _TYPE_CodAUD = value; }
        public string LOG_Object { get => _LOG_Object; set => _LOG_Object = value; }
        public string LOG_Text { get => _LOG_Text; set => _LOG_Text = value; }
        #endregion

    }
}
