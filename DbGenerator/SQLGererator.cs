using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGenerator
{
    public class SQLGererator
    {
        IMessage _message;
        public SQLGererator(IMessage message)
        {
            _message = message;
        }
        public string ScriptDatabase(SQLObjects dbGen)
        {
            var sb = new StringBuilder();
            _message.ShowMessage("Conectando ao banco de dados...");
            var server = new Server(dbGen.Server);
            server.ConnectionContext.LoginSecure = false; // set to true for Windows Authentication  
            server.ConnectionContext.Login = dbGen.Username; // "brasilriskSQL";
            server.ConnectionContext.Password = dbGen.Password; // "Cristiano67108";
            var databse = server.Databases[dbGen.DataBaseName];

            var scripter = new Scripter(server);
            scripter.Options.ScriptDrops = false;
            scripter.Options.WithDependencies = true;
            scripter.Options.IncludeHeaders = true;
            _message.ShowMessage("Conectado");

            _message.ShowMessage("Gerando scripts das tabelas...");
            var smoObjects = new Urn[1];
            foreach (Table t in databse.Tables)
            {
                smoObjects[0] = t.Urn;
                if (t.IsSystemObject == false && dbGen.Items.Count(c => c.Nome == t.Name && c.Tipo == SQLItemTypeEnum.Table) > 0)
                {
                    var sbItem = new StringBuilder();
                    var item = dbGen.Items.First(f => f.Nome == t.Name && f.Tipo == SQLItemTypeEnum.Table);
                    scripter.Options.ScriptData = item.ScriptData;
                    //StringCollection sc = scripter.Script(smoObjects);
                    var sc = scripter.EnumScript(smoObjects);

                    foreach (var st in sc)
                    {
                        sb.Append(st + "\n");
                        sbItem.Append(st + "\n");
                    }

                    if (dbGen.OneFilePerObject)
                    {
                        var path = AppDomain.CurrentDomain.BaseDirectory;
                        var fileName = MakeUnique(Path.Combine(path, t.Name + ".sql"));
                        File.WriteAllText(fileName.FullName, sbItem.ToString());
                    }
                }
            }

            _message.ShowMessage("Gerando scripts das procedures...");
            foreach (StoredProcedure t in databse.StoredProcedures)
            {
                smoObjects[0] = t.Urn;
                if (t.IsSystemObject == false && dbGen.Items.Count(c => c.Nome == t.Name && c.Tipo == SQLItemTypeEnum.Table) > 0)
                {
                    var sbItem = new StringBuilder();
                    var item = dbGen.Items.First(f => f.Nome == t.Name && f.Tipo == SQLItemTypeEnum.Table);
                    StringCollection sc = scripter.Script(smoObjects);

                    foreach (var st in sc)
                    {
                        sb.Append(st);
                    }

                    if (dbGen.OneFilePerObject)
                    {
                        var path = AppDomain.CurrentDomain.BaseDirectory;
                        var fileName = MakeUnique(Path.Combine(path, t.Name + ".sql"));
                        File.WriteAllText(fileName.FullName, sbItem.ToString());
                    }
                }
            }
            _message.ShowMessage("Processo terminado.");
            if (!dbGen.OneFilePerObject)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;
                var fileName = MakeUnique(Path.Combine(path, dbGen.Filename));
                File.WriteAllText(fileName.FullName, sb.ToString());
            }


            return sb.ToString();
        }

        public FileInfo MakeUnique(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path))
                    return new FileInfo(path);

                path = Path.Combine(dir, fileName + " " + i + fileExt);
            }
        }
    }
}
