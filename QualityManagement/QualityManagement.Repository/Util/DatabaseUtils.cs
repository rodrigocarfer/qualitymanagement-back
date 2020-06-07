using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QualityManagement.Repository.Util
{
    public static class DatabaseUtils
    {
        public static IEnumerable<T> TrimStrings<T>(IEnumerable<T> objects)
        {
            var stringProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType == typeof(string) && x.CanRead && x.CanWrite);
            foreach (var prop in stringProps)
            {
                foreach (var obj in objects)
                {
                    string valor = (string)prop.GetValue(obj);
                    string valorTrim = SafeTrim(valor);
                    prop.SetValue(obj, valorTrim);
                }
            }
            return objects;
        }

        public static string SafeTrim(string original) => original?.Trim();
    }
}
