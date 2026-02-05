namespace App06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Tribonacci Generator (Expert Edition) ===");
            Console.WriteLine("Format example for Signature: [1, 1, 1] OR 1, 1, 1");
            Console.WriteLine("Type 'exit' to quit.");
            Console.WriteLine("---------------------------------------------");

            while (true)
            {
                try
                {
                    // --- รับค่า array ---
                    Console.Write("\nEnter Array (e.g., [1, 1, 1]): ");
                    string? inputSig = Console.ReadLine()?.Trim();

                    if (string.Equals(inputSig, "exit", StringComparison.OrdinalIgnoreCase)) break;

                    int[] signature = ParseSignature(inputSig);

                    // --- รับค่า N ---
                    Console.Write("Enter N (count): ");
                    string? inputN = Console.ReadLine()?.Trim();

                    if (string.Equals(inputN, "exit", StringComparison.OrdinalIgnoreCase)) break;

                    if (!int.TryParse(inputN, out int n) || n < 0)
                    {
                        Console.WriteLine("Error: N must be a non-negative integer.");
                        continue;
                    }

                    // คำนวณและแสดง
                    int[] result = Tribonacci(signature, n);
                    Console.WriteLine($"Result: [{string.Join(", ", result)}]");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
                Console.WriteLine("Type 'exit' to quit.");
            }
        }
        private static int[] ParseSignature(string? input)
        {
            if (string.IsNullOrWhiteSpace(input) || input == "[]")
            {
                return Array.Empty<int>();
            }

            // ลบเครื่องหมาย [ และ ] ออก
            input = input.Replace("[", "").Replace("]", "");

            if (string.IsNullOrWhiteSpace(input)) return Array.Empty<int>();

            // Split และ Convert เป็น int[]
            return input.Split(',')
                        .Select(x => int.Parse(x.Trim()))
                        .ToArray();
        }
        public static int[] Tribonacci(int[] arr, int n)
        {
            if (n <= 0) return [];

            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                // มีค่าใน List อยู่แล้วให้ดึงค่ามาใข้เลย
                if (i < arr.Length)
                {
                    result[i] = arr[i];
                }
                else
                {
                    // สูตร: T(n) = T(n-1) + T(n-2) + T(n-3)
                    // ถ้า Index ติดลบ ให้ถือว่าเป็น 0 
                    int val1 = result[i - 1]; 
                    // เช็คว่ามีตัวก่อนหน้า 2 ตำแหน่งไหม ถ้าไม่มีคือ 0
                    int val2 = (i - 2 >= 0) ? result[i - 2] : 0;
                    // เช็คว่ามีตัวก่อนหน้า 3 ตำแหน่งไหม ถ้าไม่มีคือ 0
                    int val3 = (i - 3 >= 0) ? result[i - 3] : 0;
                    result[i] = val1 + val2 + val3;
                }
            }
            return result;
        }
    }

}