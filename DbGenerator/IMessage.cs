using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGenerator
{
    public interface IMessage
    {
        void ShowMessage(string message);
        void ShowParameterError();
    }
}
