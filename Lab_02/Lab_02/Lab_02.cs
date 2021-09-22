using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_02
{
    class Program
    {
        private static (int, int, int, char) LocalFunc()
        {
            int[] arrVar = new int[] { 5, 3, 12, 42, -23 };
            string strVar = "ABCD";
            int maxArrayElement = arrVar.Max();
            int minArrayElement = arrVar.Min();
            int arrayElementsSum = arrVar.Sum();
            char firstStringChar = strVar[0];
            return (maxArrayElement, minArrayElement, arrayElementsSum, firstStringChar);
        }
        private static void FunctionWithChecked()
        {
            checked
            {
                int intVar = int.MaxValue;
                intVar++;
                Console.WriteLine(intVar);
            }
        }

        private static void FunctionWithUnchecked()
        {
            unchecked
            {
                int intVar = int.MaxValue;
                intVar++;
                Console.WriteLine(intVar);
            }
        }
        static void Main(string[] args)
        {
            //1a
            bool tr = true;
            short sh = 1;
            byte b = 2;
            long l = 3;
            int i1 = 10;
            float f1 = -1;
            double d1 = 1.5;
            char c1 = 'z';
            string s1 = "zzzz";
            Console.WriteLine($"tr = {tr}\nsh = {sh}\nb = {b}\nl = {l}\ni1 = {i1}\nf1 = {f1}\nd1 = {d1}\nc1 = {c1}\ns1 = {s1}");
            //1b
            long l2 = i1, l3 = i1, l4 = sh; 
            int i2 = sh, i3 = sh;
            i1 = (int)f1; i2 = (int)d1; f1 = (float)d1;
            d1 = (double)f1; f1 = (float)d1;
            //1c
            int x = 5;
            object o = x; int x2 = (int)o;
            //1d
            var v1 = 5; var v2 = 'e';
            Console.WriteLine(v1.GetType());
            Console.WriteLine(v2.GetType());
            //1e
            int? ii = null;
            if(ii.HasValue)
            {
                x2 = (int)ii;
                int? x3 = ii;
            }
            //1f
            var m = 8; m = 'h'; //нет ошибки!?
            //2a
            string stringFirst = "aa";
            string stringSecond = "bbbb", stringThird = "cc";
            Console.WriteLine($"{stringFirst == stringSecond}");
            //2b
            Console.WriteLine(string.Concat(stringFirst, stringSecond, stringThird));
            Console.WriteLine(string.Copy(stringSecond));
            Console.WriteLine("stringSecond".Substring(0, 5));
            char[] delims = ".,;:!?\n\xD\xA\"".ToCharArray();
            string[] words = "This is a text. New string".Split(delims,StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
                Console.WriteLine(word);
            Console.WriteLine($"\nInsert:{stringFirst.Insert(2, stringSecond)}");
            Console.WriteLine($"Remove:{"stringFirst".Remove(0, 4)}");
            Console.WriteLine($"{stringFirst}");
            //2c
            string str1 = "", str2 = null;
            Console.WriteLine($"{ string.IsNullOrEmpty(str1)}, { string.IsNullOrEmpty(str2)}");
            Console.WriteLine(string.Concat("string", str1));
            //2d
            var str3 = new StringBuilder(" 2 3 4");
            str3.Append(" 5 ");
            str3.Insert(0, "1");
            str3.Remove(1, 4);
            Console.WriteLine(str3);
            //3a
            var arr = new int[2, 2]
            {
                {1, 2},
                {5, 6}
            };
            Console.WriteLine("double array: ");
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++) Console.Write($"{arr[i, j]}  ");
                Console.WriteLine();
            }
            //3b
            var strArr = new[] { "aaa", "bbb", "ccc" };
            foreach (string item in strArr) Console.Write($"{item} | ");
            Console.WriteLine($"\n Length of strArr - {strArr.Length}");
            Console.Write("Input number elem for replace: ");
            int number = int.Parse(Console.ReadLine());
            if (number >= strArr.Length)
                throw new ArgumentOutOfRangeException();
            Console.Write("Input new elem of array: ");
            string newElem = Console.ReadLine();
            for (var i = 0; i < strArr.Length; i++)
                if (i == number)
                    strArr[i] = newElem;
            foreach (string item in strArr) Console.Write($"{item} | ");
            Console.WriteLine();
            //3с
            int[][] arr2 = new int[3][];
            arr2[0] = new int[2];
            arr2[1] = new int[3];
            arr2[2] = new int[4];
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    arr2[i][j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.Write($"{arr2[i][j]} ");
                }
                Console.WriteLine();
            }
            //3d
            var intArrr = new int[] { 1, 2, 3, 4 };
            var stringArr = "absc";
            //4a
            (int, string, char, string, ulong) tupleFirstVar = (-7, "BBBB", 't', "AAAA", 66666);
            //4b
            Console.WriteLine(tupleFirstVar);
            Console.WriteLine(tupleFirstVar.Item1);
            Console.WriteLine(tupleFirstVar.Item3);
            Console.WriteLine(tupleFirstVar.Item4);
            //4c
            int intT = tupleFirstVar.Item1;
            string stringFirstT = tupleFirstVar.Item2;
            char charT = tupleFirstVar.Item3;
            string stringSecondT = tupleFirstVar.Item4;
            ulong ulongT = tupleFirstVar.Item5;
            (intT, stringFirstT, charT, stringSecondT, ulongT) = tupleFirstVar;
            //4d
            Console.WriteLine($"{tupleFirstVar == tupleFirstVar}");
            //5
            Console.WriteLine(LocalFunc());
            //6
            FunctionWithChecked();
            FunctionWithUnchecked();
        }
    }
}
