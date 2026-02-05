using System;
using System.Collections.Generic;
using System.Text;

namespace App04
{
    public class Program
    {
        private static readonly List<(int Value, string Symbol)> _numberToRomanMap = new()
    {
        (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
        (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
        (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
    };
        private static readonly Dictionary<char, int> _romanCharMap = new()
    {
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
        {'C', 100}, {'D', 500}, {'M', 1000}
    };
        public static void Main(string[] args)
        {

           Console.WriteLine("=== Roman Converter  ===");
            Console.WriteLine("Enter a number (e.g., 1990) OR a Roman numeral (e.g., MCMXC).");
            Console.WriteLine("Type 'exit' to close.");
            Console.WriteLine("------------------------------------------------");
            while (true)
            {
                Console.Write("\nInput: ");
                string input = Console.ReadLine()?.Trim();

                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                try
                {
                    string result = ConvertRomanOrNumber(input);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    // Error Handling 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
                Console.WriteLine("Type 'exit' to close.");
            }
        }
        public static string ConvertRomanOrNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be empty.");

            input = input.Trim().ToUpper();

            if (int.TryParse(input, out int number))
            {
                if (number <= 0) throw new ArgumentOutOfRangeException("Roman numerals must be greater than 0.");
                return ValueToRoman(number);
            }
            return RomanToValue(input).ToString();
        }
        private static int RomanToValue(string roman)
        {
            int total = 0;
            int prevValue = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                char c = roman[i];

                if (!_romanCharMap.TryGetValue(c, out int currentValue))
                {
                    throw new ArgumentException($"Invalid Roman character: {c}");
                }

                if (currentValue < prevValue)
                {
                    total -= currentValue;
                }
                else
                {
                    total += currentValue;
                }

                prevValue = currentValue;
            }

            return total;

        }
        private static string ValueToRoman(int number)
        {
            var sb = new StringBuilder();

            foreach (var item in _numberToRomanMap)
            {
                while (number >= item.Value)
                {
                    sb.Append(item.Symbol);
                    number -= item.Value;
                }
            }

            return sb.ToString();
        }
    }
}