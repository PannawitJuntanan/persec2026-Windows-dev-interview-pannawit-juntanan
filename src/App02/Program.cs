using System.Runtime.Serialization;

namespace App01
{
    public static class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hint: พิมพ์ข้อมูลทีละตัวแล้วกด Enter (พิมพ์ 'done' เพื่อเริ่มเรียงลำดับ)");

            List<string> userInput = new List<string>();

            // Exit when use input 'done'
            while (true)
            {
                Console.Write($"Input [{userInput.Count + 1}]: ");
                string input = Console.ReadLine()?.Trim();

                if (string.Equals(input, "done", StringComparison.OrdinalIgnoreCase))
                    break;

                if (!string.IsNullOrEmpty(input))
                {
                    userInput.Add(input);
                }
            }
            if (userInput.Count == 1)
            {
                string[] dataArray = userInput.ToArray();
                Console.WriteLine("\n--- Sorting Result ---");
                Console.WriteLine("Sorted: [" + string.Join(", ", dataArray) + "]");
                Console.ResetColor();
            }
            else if (userInput.Count > 1)
            {
                string[] dataArray = userInput.ToArray();

                Console.WriteLine("\n--- Sorting Result ---");
                string[] sortedResult = Sorting(dataArray);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sorted: [" + string.Join(", ", sortedResult) + "]");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("ไม่มีข้อมูลในการประมวลผล");
            }

            Console.WriteLine("\nกดปุ่มใดก็ได้เพื่อจบการทำงาน...");
            Console.ReadKey();
        }

        public static string[] Sorting(string[] input)
        {
            if (input == null || input.Length == 0) return input;
            string[] result = (string[])input.Clone();

            Array.Sort(result, (x, y) =>
            {
                if (x == y) return 0;
                int ix = 0, iy = 0;

                while (ix < x.Length && iy < y.Length)
                {
                    if (char.IsDigit(x[ix]) && char.IsDigit(y[iy]))
                    {
                        long nx = 0, ny = 0;
                        while (ix < x.Length && char.IsDigit(x[ix]))
                            nx = nx * 10 + (x[ix++] - '0');
                        while (iy < y.Length && char.IsDigit(y[iy]))
                            ny = ny * 10 + (y[iy++] - '0');

                        if (nx != ny) return nx.CompareTo(ny);
                    }
                    else
                    {
                        if (x[ix] != y[iy]) return x[ix].CompareTo(y[iy]);
                        ix++;
                        iy++;
                    }
                }
                return x.Length.CompareTo(y.Length);
            });

            return result;
        }

    }
}