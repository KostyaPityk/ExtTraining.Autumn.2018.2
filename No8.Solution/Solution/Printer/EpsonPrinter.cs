using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Solution.Interfaces;
using System.IO;

namespace No8.Solution.Solution.Printer
{
    /// <summary>
    /// Represents Epson printer
    /// </summary>
    public class EpsonPrinter : BasePrinter
    {
        public EpsonPrinter(string name, string model, ICustomLogger logger) : base (name, model, logger) { }
    }
}
