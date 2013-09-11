using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ShortcutThemes.Helpers
{
    class ReflectedStaticClass
    {
        private string _typeName = string.Empty;
        private Type _type = null;

        public ReflectedStaticClass(string typeName)
        {
            _typeName = typeName;
        }

        private Type Type
        {
            get
            {
                if (_type == null)
                    _type = Type.GetType(_typeName);
                return _type;
            }
        }

        protected FieldInfo GetFieldInfo(string fieldName)
        {
            return Type.GetField(fieldName);
        }

        protected object GetFieldValue(string fieldName)
        {
            return GetFieldInfo(fieldName).GetValue(null);
        }

        protected void SetFieldValue(string fieldName, object value)
        {
            GetFieldInfo(fieldName).SetValue(null, value);
        }

        protected PropertyInfo GetPropertyInfo(string propertyName)
        {
            return Type.GetProperty(propertyName);
        }

        protected object GetPropertyValue(string propertyName)
        {
            return GetPropertyInfo(propertyName).GetValue(null, null);
        }

        protected void SetPropertyValue(string propertyName, object value)
        {
            GetPropertyInfo(propertyName).SetValue(null, value, null);
        }

        protected MethodInfo GetMethodInfo(string methodName, Type[] parameterTypes=null)
        {
            parameterTypes = parameterTypes ?? Type.EmptyTypes;
            return Type.GetMethod(methodName, parameterTypes);
        }

        protected object InvokeMethod(string methodName, Type[] parameterTypes=null, object[] parameterValues=null)
        {
            return GetMethodInfo(methodName, parameterTypes).Invoke(null, parameterValues);
        }
    }
}
