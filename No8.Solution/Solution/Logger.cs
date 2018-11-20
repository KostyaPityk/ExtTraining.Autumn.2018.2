using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Solution.Interfaces;
using NLog;

namespace No8.Solution.Solution
{
    /// <summary>
    /// Represents printer ligger
    /// </summary>
    public class PrinterLogger : ICustomLogger
    {
        Logger logger;

        public PrinterLogger(string loggerName)
        {
            logger = LogManager.GetLogger(loggerName);
        }

        /// <summary>
        /// Write Debug message
        /// </summary>
        /// <param name="message">Message</param>
        public void Debug(string message) => logger.Debug(message);

        /// <summary>
        /// Write Error message
        /// </summary>
        /// <param name="message">Message</param>
        public void Error(string message) => logger.Error(message);

        /// <summary>
        /// Write Info message
        /// </summary>
        /// <param name="message">Message</param>
        public void Info(string message) => logger.Info(message);

        /// <summary>
        /// Write Warning message
        /// </summary>
        /// <param name="message">Message</param>
        public void Warning(string message) => logger.Warn(message);
    }
}
