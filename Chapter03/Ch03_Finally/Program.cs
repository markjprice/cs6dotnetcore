using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Ch03_Finally
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = null;
            StreamWriter writer = null;
            try
            {
                file = File.OpenWrite(@"c:\Code\file.txt");
                writer = new StreamWriter(file);
                writer.WriteLine("Hello C#!");
            }
            catch (Exception ex)
            {
                // if the folder doesn't exist the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                    WriteLine("The writer's unmanaged resources have been disposed.");
                }
                if (file != null)
                {
                    file.Dispose();
                    WriteLine("The file's unmanaged resources have been disposed.");
                }
            }

            using (FileStream file2 = File.OpenWrite(@"c:\Code\file2.txt"))
            {
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    try
                    {
                        writer2.WriteLine("Hello C#!");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{ex.GetType()} says {ex.Message}");
                    }
                }
            }

        }
    }
}
