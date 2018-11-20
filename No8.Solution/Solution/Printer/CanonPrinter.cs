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
    /// Represents Canon printer
    /// </summary>
    public class CanonPrinter : BasePrinter
    {
        public CanonPrinter(string name, string model, ICustomLogger logger) : base(name, model, logger) { }
    }
}
