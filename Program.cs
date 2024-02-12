using App;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("|===============================================|");
        Console.WriteLine("  Printer Status Check");
        Console.WriteLine("|===============================================|");
        int paperCount = GetValidatedCount();
        PrinterUtility.PrintStatus printMessage = PrinterUtility.CheckStatusForPrinter(paperCount);
        Console.WriteLine(PrinterUtility.GetStatusMessage(printMessage));
    }

    public static int GetValidatedCount()
    {
        while (true)
        {
            Console.Write($"{Environment.NewLine}  Enter the Paper Count [Range: 0 to 2147483647]: ");
            string count = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(count))
            {
                Console.WriteLine($"{Environment.NewLine}  Printer Status: [Error] Entered Paper count is invalid.");
                continue;
            }
            if (!int.TryParse(count, out int paperCount))
            {
                Console.WriteLine($"{Environment.NewLine}  Printer Status: [Error] Entered Paper count is invalid.");
                continue;
            }
            if (!IsValidCount(paperCount))
            {
                Console.WriteLine($"{Environment.NewLine}  Printer Status: [Error] Entered Paper count is invalid.");
                continue;
            }
            return paperCount;
        }
    }
    public static bool IsValidCount(int paperCount)
    {
        return paperCount >= 0 && paperCount <= 2147483647;
    }
}
