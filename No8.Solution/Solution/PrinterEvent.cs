using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Solution
{
    /// <summary>
    /// Represents event start and end printed
    /// </summary>
    public class PrinterEvent
    {
        private int seconds;
        private int minute;
        private int hour;

        public PrinterEvent()
        {
            seconds = DateTime.Now.Second;
            minute = DateTime.Now.Minute;
            hour = DateTime.Now.Hour;
        }
    }
}
