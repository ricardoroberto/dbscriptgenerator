using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace DBGenerator
{
    public class MessageCmdLet : IMessage
    {
        Cmdlet _cmd = null;
        public MessageCmdLet(Cmdlet cmd)
        {
            _cmd = cmd;
        }
        public void ShowParameterError()
        {
            _cmd.WriteVerbose("Informe o nome do arquivo json.");
            _cmd.WriteVerbose("Exemplo: DBGenerator dbconfig.json");
            _cmd.WriteVerbose("Exemplo de dados:");
            _cmd.WriteVerbose("{");
            _cmd.WriteVerbose("\"Server\": \"192.168.20.11\",");
            _cmd.WriteVerbose("  \"DataBaseName\": \"brasilriskDB\",");
            _cmd.WriteVerbose("  \"Username\": \"brasilriskSQL\",");
            _cmd.WriteVerbose("  \"Password\": \"Cristiano67108\",");
            _cmd.WriteVerbose("  \"Items\": [");
            _cmd.WriteVerbose("    {");
            _cmd.WriteVerbose("      \"Nome\": \"AlertaDiretriz\",");
            _cmd.WriteVerbose("      \"Tipo\": 0");
            _cmd.WriteVerbose("    }");
            _cmd.WriteVerbose("  ]");
            _cmd.WriteVerbose("}");
            _cmd.WriteVerbose("");
        }
        public void ShowMessage(string message)
        {
            _cmd.WriteVerbose(message);
        }

    }
}
