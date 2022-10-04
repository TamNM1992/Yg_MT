using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Common.Extension
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return string.Concat(str[0].ToString().ToUpper(), str.AsSpan(1));
        }
    }
}
