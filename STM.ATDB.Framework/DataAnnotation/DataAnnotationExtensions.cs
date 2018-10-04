using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Framework.DataAnnotation
{
    public static class DataAnnotationExtensions
    {
        public static Dictionary<string, StringLengthAttribute> GetColumnsStringLength(this Type objectType, params string[] names)
        {
            var results = new Dictionary<string, StringLengthAttribute>();
            foreach (var name in names)
            {
                var attrs = objectType.GetCustomAttributes(typeof(StringLengthAttribute), true) as StringLengthAttribute[];
                if (attrs == null || attrs.Length == 0) { return results; }
                results.Add(name, attrs[0]);
            }
            return results;
        }
    }
}
