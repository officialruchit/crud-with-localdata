using System;

namespace App
{
    public static class PrinterUtility
    {
        public enum PrintStatus
        {
            NotReady,
            PaperLow,
            PrinterReady,
            Error
        }
        public static PrintStatus CheckStatusForPrinter(int paperCount)
        {
            if (paperCount == 0)
            {
                return PrintStatus.NotReady;
            }
            if (paperCount > 0 && paperCount < 10)
            {
                return PrintStatus.PaperLow;
            }
            if (paperCount >= 10)
            {
                return PrintStatus.PrinterReady;
            }
            return PrintStatus.Error;
        }

        public static string GetStatusMessage(PrintStatus status)
        {
            switch (status)
            {
                case PrintStatus.NotReady:
                    return $"{Environment.NewLine}  \"not ready\"";
                case PrintStatus.PrinterReady:
                    return $"{Environment.NewLine}  \"printer is ready\"";
                case PrintStatus.PaperLow:
                    return $"{Environment.NewLine}  \"paper is low\"";
                case PrintStatus.Error:
                    return $"{Environment.NewLine}  \"Printer Status: [Error] Entered Paper count is invalid.\"";
                default:
                    return $"{Environment.NewLine}  \"Printer Status: [Error] Entered Paper count is invalid.\"";
            }
        }

       

       
    }
} 