using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DBGenerator
{
    class Program
    {
        static int Main(string[] args)
        {
            IMessage message = new MessageConsole();
            if (args.Length==0)
            {
                message.ShowParameterError();
                return 1;
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = Path.Combine(path, args[0]);

            if (!File.Exists(fileName))
            {
                message.ShowParameterError();
                return 2;
            }

            SQLObjects dbGen = new SQLObjects();
            dbGen.Read(fileName);

            SQLGererator gen = new SQLGererator(message);
            Console.WriteLine(gen.ScriptDatabase(dbGen));
            return 0;
        }
    }
}

