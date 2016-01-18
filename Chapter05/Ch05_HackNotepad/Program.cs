using static System.Console;
using static System.Diagnostics.Process;
using System.Runtime.InteropServices;
using System;

namespace Ch05_HackNotepad
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, string lpString);

        static void Main(string[] args)
        {
            Write("Enter a message: ");
            string message = ReadLine();
            WriteLine("Press any key to start Notepad.");
            ReadKey();
            Start("notepad.exe").WaitForInputIdle();
            // use a Win32 API call to get reference to Notepad
            IntPtr notepad = FindWindow("Notepad", null);
            if (notepad != IntPtr.Zero)
            {
                // if it is running, set it's window text with a message
                SetWindowText(notepad, "Notepad has been hacked! " + message);
            }
            else
            {
                WriteLine("Notepad is not running!");
            }

        }
    }
}
