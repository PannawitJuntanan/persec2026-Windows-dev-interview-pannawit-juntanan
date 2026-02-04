using System;
using System.Collections.Generic;

namespace App03
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("=== Autocomplete System (Search Priority) ===");

         
            Console.Write("Enter search term (e.g., 'th'): ");
            string search = Console.ReadLine()?.Trim();

    
            Console.WriteLine("Enter items (comma separated, e.g., 'Mother, Think, Worthy, Apple, Android'): ");
            string itemsInput = Console.ReadLine();
            string[] items = string.IsNullOrWhiteSpace(itemsInput) 
                ? Array.Empty<string>() 
                : itemsInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

 
            for (int i = 0; i < items.Length; i++) items[i] = items[i].Trim();

  
            Console.Write("Enter max results: ");
            if (!int.TryParse(Console.ReadLine(), out int maxResult))
            {
                maxResult = 10; // Default ถ้าใส่เลขไม่ถูกต้อง
            }

 
            Console.WriteLine("\n--- Processing ---");
            string[] result = Autocomplete(search, items, maxResult);


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Result: [{string.Join(", ", result)}]");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        public static string[] Autocomplete(string search, string[] items, int maxResult)
        {
            if (string.IsNullOrEmpty(search) || items == null) return Array.Empty<string>();

            List<string> startsWith = new List<string>();
            List<string> contains = new List<string>();
            List<string> endsWith = new List<string>();

            string searchLower = search.ToLower();

            foreach (var item in items)
            {
                string itemLower = item.ToLower();

                if (itemLower.Contains(searchLower))
                {
                    if (itemLower.StartsWith(searchLower))
                        startsWith.Add(item);
                    else if (itemLower.EndsWith(searchLower))
                        endsWith.Add(item);
                    else
                        contains.Add(item);
                }
            }

            startsWith.Sort(StringComparer.OrdinalIgnoreCase);
            contains.Sort(StringComparer.OrdinalIgnoreCase);
            endsWith.Sort(StringComparer.OrdinalIgnoreCase);

            List<string> finalResult = new List<string>();
            finalResult.AddRange(startsWith);
            finalResult.AddRange(contains);
            finalResult.AddRange(endsWith);

            int count = Math.Min(finalResult.Count, maxResult);
            string[] output = new string[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = finalResult[i];
            }

            return output;
        }
    }
}