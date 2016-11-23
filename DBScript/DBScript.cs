using DBGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace DBScript
{
    // Declare the class as a cmdlet and specify and 
    // appropriate verb and noun for the cmdlet name.
    [Cmdlet(VerbsCommunications.Send, "Greeting")]
    public class DBScriptCommand : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public string FileJson { get; set; }

        [Parameter(Mandatory = false)]
        public string ServerName { get; set; }

        [Parameter(Mandatory = false)]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false)]
        public string Username { get; set; }

        [Parameter(Mandatory = false)]
        public string Password { get; set; }


        // Overide the ProcessRecord method to process
        // the supplied user name and write out a 
        // greeting to the user by calling the WriteObject
        // method.
        protected override void ProcessRecord()
        {
            IMessage mess = new MessageCmdLet(this);

            if (String.IsNullOrEmpty(this.FileJson) && (
                                                           String.IsNullOrEmpty(this.ServerName) && String.IsNullOrEmpty(this.ServerName) 
                                                        && String.IsNullOrEmpty(this.ServerName) && String.IsNullOrEmpty(this.ServerName)
                                                       )
               )
            {
                mess.ShowParameterError();
                return;
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = Path.Combine(path, this.FileJson);

            if (!File.Exists(fileName))
            {
                mess.ShowParameterError();
                return;
            }

            SQLObjects dbGen = new SQLObjects();
            dbGen.Read(fileName);

            SQLGererator gen = new SQLGererator(mess);

            this.WriteVerbose(gen.ScriptDatabase(dbGen));
        }
    }
}
