using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Solution.Printer;
using No8.Solution.Solution.Interfaces;

namespace No8.Solution.Solution
{
    /// <summary>
    /// Base class to create printer
    /// </summary>
    public abstract class PrinterFactory
    {
        public abstract BasePrinter Create(string name, string model, ICustomLogger logger);
    }

    /// <summary>
    /// Class create Canon printer
    /// </summary>
    public class CanonPrinterFactory : PrinterFactory
    {
        public override BasePrinter Create(string name, string model, ICustomLogger logger) => new CanonPrinter(name, model, logger);
    }

    /// <summary>
    /// Class create Epson printer
    /// </summary>
    public class EpsonPrinterFactory : PrinterFactory
    {
        public override BasePrinter Create(string name, string model, ICustomLogger logger) => new EpsonPrinter(name, model, logger);
    }
}
