using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace T9Spelling
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += ExceptionsCatcher;

            if (args.Length < 1) throw new ArgumentException("File name missing");
            var fileName = args[0];
            if(!File.Exists(fileName))
                throw new FileNotFoundException("Can't find input file, please check parameters");

            var fileData = File.ReadAllLines(fileName);
            InputChecker.CheckData(fileData);

            for (int i = 1; i < fileData.Length; i++)
            {
                var digits = T9.EncodeString(fileData[i]);
                Console.WriteLine(String.Format("Case #{0}: {1}", i, digits));
            }
        }

        static void ExceptionsCatcher(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(((Exception)e.ExceptionObject).Message);
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
