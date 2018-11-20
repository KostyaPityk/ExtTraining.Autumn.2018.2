using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Solution.Interfaces;
using No8.Solution.Solution.Printer;
using System.IO;
using System.Collections;
using System.Windows.Forms;


namespace No8.Solution.Solution
{
    /// <summary>
    /// Represent printer servise
    /// </summary>
    public class PrinterService : IEnumerable<BasePrinter>
    {
        private readonly List<BasePrinter> printers;
        private  ICustomLogger logger;

        public PrinterService(ICustomLogger logger)
        {
            this.printers = new List<BasePrinter>();
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.Info("Create printer service");
        }

        /// <summary>
        /// Added printer from the printers
        /// </summary>
        /// <param name="name">Name printer</param>
        /// <param name="model">Model printer</param>
        /// <param name="factory">Type printer</param>
        /// <exception cref="ArgumentException">
        /// Throw if printer alredy exists
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throw if factory is empty
        /// </exception>
        public void Add(string name, string model, PrinterFactory factory)
        {
            if (factory == null)
            {
                logger.Warning("Factory is empty");
                throw new ArgumentNullException(nameof(factory));
            }

            BasePrinter printer = factory.Create(name, model, logger);

            if (printers.Contains(printer))
            {
                logger.Warning("Printer alredy exists");
                throw new ArgumentException(nameof(printer), "alredy exists");
            }

            printers.Add(printer);
            logger.Info($"{printer} added in printers");
        }

        public IEnumerator<BasePrinter> GetEnumerator()
        {
            return printers.GetEnumerator();
        }

        /// <summary>
        /// Print file from printer
        /// </summary>
        /// <param name="index">Index printer</param>
        public void Print(int index)
        {
            BasePrinter printer = printers[index];
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            printer.Print(fileDialog.FileName);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return printers.GetEnumerator();
        }
    }
}
