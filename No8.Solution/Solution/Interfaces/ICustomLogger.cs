using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Solution.Interfaces
{
    /// <summary>
    /// Interface that provide base methods what can be do logger
    /// </summary>
    public interface ICustomLogger
    {
        void Warning(string message);
        void Error(string message);
        void Info(string message);
        void Debug(string message);
    }
}
