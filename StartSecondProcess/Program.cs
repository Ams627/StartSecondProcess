using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartSecondProcess
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var currentPaths = Environment.GetEnvironmentVariable("PATH").Split(';');
            var newPath = currentPaths[0] + ";" + currentPaths.Skip(2).Aggregate((a, b) => a + ";" + b);
            var newPath2 = "c:\\bin";

            Console.WriteLine();
            try
            {
                var processInfo = new ProcessStartInfo();
                var vars = processInfo.EnvironmentVariables;
                vars["PATH"] = newPath2;
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
