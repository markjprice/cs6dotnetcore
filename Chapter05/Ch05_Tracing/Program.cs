using System.Diagnostics;
using static System.Console;

namespace Ch05_Tracing
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Debug says Hello C#!");
            Trace.WriteLine("Trace says Hello C#!");

            var ts = new TraceSwitch("PacktSwitch", "");
            Trace.WriteLineIf(ts.TraceError, "TraceError");
            Trace.WriteLineIf(ts.TraceWarning, "TraceWarning");
            Trace.WriteLineIf(ts.TraceInfo, "TraceInfo");
            Trace.WriteLineIf(ts.TraceVerbose, "TraceVerbose");
            Trace.Close(); // release any file or database listeners

            WriteLine("Press ENTER to close.");
            ReadLine();
        }
    }
}
