using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("I am debugging.");
            Trace.WriteLine("I am tracing.");
#if CONFUSED
            Trace.WriteLine("I am tracing and confused!");
#endif
        }
    }
}
