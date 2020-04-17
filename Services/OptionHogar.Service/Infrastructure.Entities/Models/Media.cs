using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Models
{
    public class Media
    {
        #region Variables

        private int _MEDI_ID;
        private int _PROJ_ID;
        private int _EVEN_ID;
        private bool _MEDI_Event;
        private string _MEDI_Title;
        private string _MEDI_Description;
        private string _MEDI_Url;
        private string _TYPE_TabMED;
        private string _TYPE_CodMED;
        private string _AUDI_UserCrea;
        private DateTime _AUDI_FechCrea;
        private string _AUDI_UserModi;
        private DateTime? _AUDI_FechModi;


        #endregion
        #region Properties

        public int MEDI_ID { get => _MEDI_ID; set => _MEDI_ID = value; }
        public int PROJ_ID { get => _PROJ_ID; set => _PROJ_ID = value; }
        public int EVEN_ID { get => _EVEN_ID; set => _EVEN_ID = value; }
        public bool MEDI_Event { get => _MEDI_Event; set => _MEDI_Event = value; }
        public string MEDI_Title { get => _MEDI_Title; set => _MEDI_Title = value; }
        public string MEDI_Description { get => _MEDI_Description; set => _MEDI_Description = value; }
        public string MEDI_Url { get => _MEDI_Url; set => _MEDI_Url = value; }
        public string TYPE_TabMED { get => _TYPE_TabMED; set => _TYPE_TabMED = value; }
        public string TYPE_CodMED { get => _TYPE_CodMED; set => _TYPE_CodMED = value; }
        public string AUDI_UserCrea { get => _AUDI_UserCrea; set => _AUDI_UserCrea = value; }
        public DateTime AUDI_FechCrea { get => _AUDI_FechCrea; set => _AUDI_FechCrea = value; }
        public string AUDI_UserModi { get => _AUDI_UserModi; set => _AUDI_UserModi = value; }
        public DateTime? AUDI_FechModi { get => _AUDI_FechModi; set => _AUDI_FechModi = value; }
        #endregion

    }
}
