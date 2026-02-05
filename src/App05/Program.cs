public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Descending Order Sorter ===");
        Console.WriteLine("Enter a positive integer (e.g., 42145). Type 'exit' to quit.");
        Console.WriteLine("--------------------------------------------------");

        while (true)
        {
            Console.Write("\nInput: ");

            string? input = Console.ReadLine()?.Trim();

            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            if (int.TryParse(input, out int number))
            {
                try
                {
                    int result = SortDigitsDescending(number);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid input! Please enter a valid integer number.");
                Console.ResetColor();
            }
        }
    }
    public static int SortDigitsDescending(int num)
    {
        if (num == 0) return 0;
        if (num < 0) throw new ArgumentException("Input must be a positive integer.");

        Span<int> digitCounts = stackalloc int[10];

        while (num > 0)
        {
            int digit = num % 10;
            digitCounts[digit]++;
            num /= 10;
        }
        int result = 0;

        for (int i = 9; i >= 0; i--)
        {

            while (digitCounts[i] > 0)
            {

                if (result > int.MaxValue / 10)
                    throw new OverflowException("Result exceeds integer limits.");

                result = (result * 10) + i;
                digitCounts[i]--;
            }
        }

        return result;
    }
}