using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder.Helpers
{
    public static class StringEx
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
