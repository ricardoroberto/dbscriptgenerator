using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGenerator
{
    public class SQLObjects
    {
        public SQLObjects()
        {
            this.Items = new List<SQLItem>();
            this.OneFilePerObject = false;
        }

        public string Server { get; set; }
        public string DataBaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool OneFilePerObject { get; set; }
        public string Filename { get; set; }
        public List<SQLItem> Items { get; set; }

        public void Save(string fileName)
        {
            string json = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(fileName, json);
        }
        public void Read(string fileName)
        {
            SQLObjects obj = JsonConvert.DeserializeObject<SQLObjects>(System.IO.File.ReadAllText(fileName));
            this.DataBaseName = obj.DataBaseName;
            this.Items = obj.Items;
            this.Password = obj.Password;
            this.Username = obj.Username;
            this.Server = obj.Server;
            this.Filename = obj.Filename;
            this.OneFilePerObject = obj.OneFilePerObject;
        }
    }
}
