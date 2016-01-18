using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02_SpecialTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88; // storing a double in an object
            object name = "Amir"; // storing a string in an object
            int length1 = name.Length; // gives compile error!
            int length2 = ((string)name).Length; // cast to access members

            dynamic anotherName = "Ahmed"; // storing a string in a dynamic object
            int length = anotherName.Length; // this compiles but might throw an exception at run-time!

        }
    }
}
