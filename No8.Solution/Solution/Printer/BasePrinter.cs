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
    /// Represents base class from Printer
    /// </summary>
    public abstract class BasePrinter
    {
        /// <summary>
        /// Event from start printed
        /// </summary>
        public EventHandler<PrinterEvent> PrinterStarted;

        /// <summary>
        /// Event from end printerd
        /// </summary>
        public EventHandler<PrinterEvent> PrinterEnded;

        /// <summary>
        /// Name printer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Model printer
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Logger
        /// </summary>
        public ICustomLogger logger;

        /// <summary>
        /// Constuction
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="model">Model</param>
        /// <param name="logger">Logger</param>
        public BasePrinter(string name, string model, ICustomLogger logger)
        {
            Name = name;
            Model = model;
            this.logger = logger;
        }
        
        /// <summary>
        /// Print file from printer
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <exception cref="FileNotFoundException">
        /// Throw if file exists
        /// </exception>
        public void Print(string filePath)
        {
            OnPrinterEnded(new PrinterEvent());

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found, check your file path");
            }

            PrintFile(filePath);

            OnPrinterEnded(new PrinterEvent());
        }

        /// <summary>
        /// Print bytes of file
        /// </summary>
        /// <param name="fileName">File name</param>
        public void PrintFile(string fileName)
        {
            Console.WriteLine($"Printing {this.Model} {this.Name} printer");

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                for (int i = 0; i < fileStream.Length; i++)
                {
                    Console.WriteLine(fileStream.ReadByte());
                }
            }
        }

        /// <summary>
        /// Event, works then printer started printed
        /// </summary>
        /// <param name="args"></param>
        public void OnPrinterStarted(PrinterEvent args)
        {
            PrinterStarted?.Invoke(this, args);
            logger.Info("Printer started to print");
        }

        /// <summary>
        /// Event, works then printer ended printed
        /// </summary>
        /// <param name="args"></param>
        public void OnPrinterEnded(PrinterEvent args)
        {
            PrinterEnded?.Invoke(this, args);
            logger.Info("Printer  ended to print");
        }
    }
}
