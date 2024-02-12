using System;

namespace App
{
    public static class FileTransferUtility
    {
        public static TimeSpan CalculateTransferTime(double fileSize, string fileUnit)
        {
            int transmissionRate = 960; // bytes/sec
            double fileSizeInBytes = ConvertToBytes(fileSize, fileUnit);
            double transferTimeInSeconds = fileSizeInBytes / transmissionRate;
            return TimeSpan.FromSeconds(transferTimeInSeconds);
        }

        public static double ConvertToBytes(double fileSize, string fileUnit)
        {
            switch (fileUnit.ToUpper())
            {
                case "B":
                    return fileSize;
                case "KB":
                    return fileSize * 1024;
                case "MB":
                    return fileSize * 1024 * 1024;
                default:
                    throw new ArgumentException("Invalid file unit provided.");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("|======================================================|");
            Console.WriteLine("  FILE TRANSFER TIME CALCULATION ");
            Console.WriteLine("  Transmission Rate:960 bytes/sec");
            Console.WriteLine("|======================================================|");

            double fileSize = ValidateFileSize();
            string fileUnit = ValidateFileUnit();
            TimeSpan transferTime = FileTransferUtility.CalculateTransferTime(fileSize, fileUnit);

            DisplayResult(transferTime);
        }

        public static double ValidateFileSize()
        {
            while (true)
            {
                Console.Write("  Enter the file size [range: 0 to 2147483647]: ");
                if (double.TryParse(Console.ReadLine(), out double fileSize) && fileSize >= 0 && fileSize <= 2147483647)
                {
                    return fileSize;
                }
                Console.WriteLine("  Invalid file size entered.");
            }
        }

        public static string ValidateFileUnit()
        {
            while (true)
            {
                Console.Write("  Enter the file size unit [B or KB or MB]: ");
                string fileUnit = Console.ReadLine()?.Trim().ToUpper();
                if (fileUnit == "B" || fileUnit == "KB" || fileUnit == "MB")
                {
                    return fileUnit;
                }
                Console.WriteLine("  Invalid file unit entered.");
            }
        }

        static void DisplayResult(TimeSpan transferTime)
        {
            Console.WriteLine("|======================================================9===========|");
            Console.WriteLine("\tCALCULATION RESULT");
            Console.WriteLine("|=================================================================|");
            Console.WriteLine("  File transfer time calculation operation completed successfully.");
            Console.WriteLine($"  Total time required to transfer file: ");
            Console.WriteLine($"\tDays:\t\t{transferTime.Days}");
            Console.WriteLine($"\tHours:\t\t{transferTime.Hours}");
            Console.WriteLine($"\tMinutes:\t{transferTime.Minutes}");
            Console.WriteLine($"\tSeconds:\t{transferTime.Seconds}");
            Console.WriteLine($"\tMilliseconds:\t{transferTime.Milliseconds}");
            Console.WriteLine();
        }
    }
}
