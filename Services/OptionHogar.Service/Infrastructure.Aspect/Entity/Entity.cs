using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aspect.Entity
{
    [DataContract()]
    public enum InstanceEntity
    {
        [EnumMember()]
        Unchanged = 0,
        [EnumMember()]
        Added = 1,
        [EnumMember()]
        Modified = 2,
        [EnumMember()]
        Deleted = 3
    }

    [DataContract]
    //[Serializable()]
    public class Entity : INotifyPropertyChanged, ICloneable
    {
        public InstanceEntity m_instance;

        [DataMember]
        public InstanceEntity Instance
        {
            get { return m_instance; }
            set { m_instance = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName="")
        {
            if (m_instance != InstanceEntity.Added && m_instance != InstanceEntity.Deleted)
            { m_instance = InstanceEntity.Modified; }

            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        public object Clone()
        {
            InstanceEntity nuevo = (InstanceEntity)this.MemberwiseClone();
            return nuevo;
        }
    }
}
