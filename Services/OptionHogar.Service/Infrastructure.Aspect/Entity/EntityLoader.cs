using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infrastructure.Aspect.Entity
{
    public class EntityLoader<TEntity>
    {
        public Type Type;

        public EntityLoader()
        {
            Type = typeof(TEntity);
        }

        public void Load(IDataReader reader, object schema)
        {
            try
            {
                int _columns = reader.FieldCount - 1;
                for (int i = 0; i <= _columns; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        object _value = reader.GetValue(i);
                        string _name = reader.GetName(i);
                        PropertyInfo _propertyInfo = Type.GetProperty(_name);
                        if (!(_propertyInfo == null))
                        {
                            Type _type = _propertyInfo.PropertyType;
                            if (_propertyInfo.CanWrite)
                            {
                                SetType(ref _propertyInfo, _value, ref schema, _type.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetType(ref PropertyInfo propertyInfo, object value, ref object schema, string type)
        {
            switch (type)
            {
                case "System.String": SetValue<String>(ref propertyInfo, value, ref schema); break;
                case "System.Int16": SetValue<Int16>(ref propertyInfo, value, ref schema); break;
                case "System.Int32": SetValue<Int32>(ref propertyInfo, value, ref schema); break;
                case "System.Int64": SetValue<Int64>(ref propertyInfo, value, ref schema); break;
                case "System.Double": SetValue<Double>(ref propertyInfo, value, ref schema); break;
                case "System.DateTime": SetValue<DateTime>(ref propertyInfo, value, ref schema); break;
                case "System.Boolean": SetValue<Boolean>(ref propertyInfo, value, ref schema); break;
                case "System.Guid": SetValue<Guid>(ref propertyInfo, value, ref schema); break;
                case "System.TimeSpan": SetValue<TimeSpan>(ref propertyInfo, value, ref schema); break;
                case "System.Byte[]": SetValue<Byte[]>(ref propertyInfo, value, ref schema); break;
                case "System.Decimal": SetValue<Decimal>(ref propertyInfo, value, ref schema); break;
                case "System.Nullable`1[System.Int32]": SetValue<Int32>(ref propertyInfo, value, ref schema); break;
                case "System.Nullable`1[System.Double]": SetValue<Double>(ref propertyInfo, value, ref schema); break;
                case "System.Nullable`1[System.Decimal]": SetValue<Decimal>(ref propertyInfo, value, ref schema); break;
                case "System.Nullable`1[System.DateTime]": SetValue<DateTime>(ref propertyInfo, value, ref schema); break;
                case "System.Nullable`1[System.Boolean]": SetValue<Boolean>(ref propertyInfo, value, ref schema); break;
                case "System.Nullable`1[System.Guid]": SetValue<Guid>(ref propertyInfo, value, ref schema); break;
                case "System.Nullable`1[System.TimeSpan]": SetValue<TimeSpan>(ref propertyInfo, value, ref schema); break;
                case "System.Xml.XmlDocument":
                    try
                    {
                        XmlDocument _xml = new XmlDocument();
                        _xml.LoadXml(value.ToString());
                        propertyInfo.SetValue(schema, _xml, null);
                    }
                    catch (Exception) { }
                    break;
            }

        }

        private void SetValue<T>(ref PropertyInfo propertyInfo, object value, ref object schema)
        {
            if (value != null)
            {
                if (TryParse(value, out T result))
                {
                    propertyInfo.SetValue(schema, result, null);
                }
            }
        }

        private Boolean TryParse<T>(Object value, out T result)
        {
            result = default(T);
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter == null || !converter.IsValid(value))
            {
                return false;
            }
            result = (T)converter.ConvertFrom(value);
            return true;
        }
    }
}
