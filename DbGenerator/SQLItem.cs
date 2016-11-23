using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGenerator
{
    public enum SQLItemTypeEnum
    {
        Table = 0,
        Procedure = 1
    }

    public class SQLItem
    {
        public string Nome { get; set; }
        public SQLItemTypeEnum Tipo { get; set; }
        public bool ScriptData { get; set; }
    }
}
