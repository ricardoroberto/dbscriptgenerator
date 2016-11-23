using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGenerator
{
    public class MessageConsole : IMessage
    {
        public void ShowParameterError()
        {
            Console.WriteLine("Informe o nome do arquivo json.");
            Console.WriteLine("Exemplo: DBGenerator dbconfig.json");
            Console.WriteLine("Exemplo de dados:");
            Console.WriteLine("{");
            Console.WriteLine("\"Server\": \"192.168.20.11\",");
            Console.WriteLine("  \"DataBaseName\": \"brasilriskDB\",");
            Console.WriteLine("  \"Username\": \"brasilriskSQL\",");
            Console.WriteLine("  \"Password\": \"Cristiano67108\",");
            Console.WriteLine("  \"Items\": [");
            Console.WriteLine("    {");
            Console.WriteLine("      \"Nome\": \"AlertaDiretriz\",");
            Console.WriteLine("      \"Tipo\": 0");
            Console.WriteLine("    }");
            Console.WriteLine("  ]");
            Console.WriteLine("}");
            Console.WriteLine("");
        }
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}
