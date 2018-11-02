using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_9
{
    public static class Strings
    {
        public static string Apply(this string s, Func<string, string> f)
        {
            return f.Invoke(s);
        }

        public static string Apply(this string s, Func<string, int, string> f, int p)
        {
            return f.Invoke(s, p);
        }
    }
}
