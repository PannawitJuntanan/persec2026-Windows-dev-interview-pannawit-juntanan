using System;
using System.Collections.Generic;

namespace App01
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== โปรแกรมตรวจสอบเครื่องหมายเปิด-ปิด (Balanced Brackets) ===");
            Console.WriteLine("พิมพ์เครื่องหมายที่ต้องการตรวจสอบ (เช่น ([]{}), ([{) ) หรือพิมพ์ 'exit' เพื่อออก:");

            while (true)
            {
                Console.Write("\nระบุข้อมูล: ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "exit") break;

                bool result = IsBalanced(input);
                
                // แสดงผลลัพธ์
                if (result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"คำตอบ: {result} (มีการเปิดปิดครบคู่)");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"คำตอบ: {result} (เปิดปิดไม่ครบหรือลำดับผิด)");
                }
                Console.ResetColor();
            }
        }

        /// <summary>
        /// ฟังก์ชันตรวจสอบความสมดุลของเครื่องหมาย
        /// </summary>
        public static bool IsBalanced(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;

            Stack<char> stack = new Stack<char>();
            
            // กำหนดคู่สัญลักษณ์
            Dictionary<char, char> bracketsMatch = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char c in input)
            {
                // ถ้าเจอตัวเปิด ( ( [ { ) ให้เอาลง Stack
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // ถ้าเจอตัวปิด ( ) ] } )
                else if (bracketsMatch.ContainsKey(c))
                {
                    // 1. ถ้าเจอตัวปิดแต่ไม่มีตัวเปิดใน Stack เลย (Stack ว่าง)
                    // 2. หรือตัวเปิดล่าสุดใน Stack ไม่ตรงคู่กับตัวปิดนี้
                    if (stack.Count == 0 || stack.Pop() != bracketsMatch[c])
                    {
                        return false;
                    }
                }
            }

            // ถ้าเช็กจนจบแล้ว Stack ต้องว่างพอดีถึงจะถือว่า Complete
            return stack.Count == 0;
        }
    }
}