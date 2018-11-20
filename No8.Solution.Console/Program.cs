using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Solution;
using No8.Solution.Solution.Interfaces;
using No8.Solution.Solution.Printer;
using System.IO;


namespace No8.Solution.Console
{
    class Program
    {
        static PrinterService servise;

        [STAThread]
        static void Main(string[] args)
        {
            ICustomLogger logger = new PrinterLogger("PrinterLogger");
            servise = new PrinterService(logger);

            Menu();
        }

        private static void Menu()
        {
            while (true)
            {
                System.Console.WriteLine("Select your choice:");
                System.Console.WriteLine("1:Add new printer");
                System.Console.WriteLine("2:Show all printer");
                System.Console.WriteLine("3:Print");

                int choose = int.Parse(System.Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Add();
                        break;

                    case 2:
                        Show();
                        break;
                    case 3:
                        Print();
                        break;
                }
            }
        }

        private static void Add()
        {
            System.Console.WriteLine("1:Canon");
            System.Console.WriteLine("2:Epson");

            int choose = int.Parse(System.Console.ReadLine());
            PrinterFactory factory = null;

            if (choose == 1)
            {
                factory = new CanonPrinterFactory();
            }
            else if (choose == 2)
            {
                factory = new EpsonPrinterFactory();
            }

            System.Console.WriteLine("Name: ");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Model: ");
            string model = System.Console.ReadLine();

            servise.Add(name, model, factory);
        }
        private static void Show()
        {
            int index = 1;

            foreach (var printer in servise)
            {
                System.Console.WriteLine($"Index {index}: Name: {printer.Name}, Model: {printer.Model}");
                index++;
            }

            System.Console.WriteLine();
        }

        private static void Print()
        {
            System.Console.WriteLine("Choose printer: ");

            Show();

            int index = int.Parse(System.Console.ReadLine()) - 1;

            try
            {
                servise.Print(index);
                System.Console.WriteLine("File was printed");
            }
            catch (FileNotFoundException)
            {
                System.Console.WriteLine("Check your file path");
            }
        }
    }
}
