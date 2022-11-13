using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.MoreKeywords
{
    public class Dynamic
    {
        public static void Main()
        {
            //nullable type
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            int? i = null;
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            //the compiler infers the type of the variable from 
            //the expression on the right side of the initialization statement
            var v = GetSomeObject();
            //Console.WriteLine(v.Year);

            //dynamic types resolved at runtime 
            dynamic d = GetSomeObject();
            Console.WriteLine(d.Year);

            Console.ReadKey();
        }

        public static object GetSomeObject()
        {
            return DateTime.Now;
        }
    }

}
