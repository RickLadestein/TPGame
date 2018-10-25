using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritetoFile
{
    class Program
    {
        static void Main(string[] args)
        {
            String UserDomainName = Environment.UserDomainName;
            String machineName = Environment.MachineName;
            String Username = Environment.UserName;
            String CurrentDir = Environment.CurrentDirectory;

            String path = @"d:\Avans hogeschool jaar 2\Fileproperties.txt";

            List<String> SystemList = new List<string>
            {
                UserDomainName,
                machineName,
                Username,
                CurrentDir
            };

            // if (!File.Exists(path))
            // {
            //     File.WriteAllLines(path, SystemList);
            // }

            if (!File.Exists(path))
            {
                File.WriteAllText(path, string.Join(" ", SystemList));
            }

            //string[] readText = File.ReadAllLines(path);

            //foreach (string s in readText)
            // {
            //     Console.WriteLine(s);
            //}

            string readText2 = File.ReadAllText(path);
        }
    }
}
