using System;

namespace Lab_04
{
    static class StatisticOperation
    {
        public static int FirstNumber(this string str)
        {
            string number = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 48 && str[i] <= 57)
                {
                    number += str[i];
                }
                if (i > 1 && (str[i] < 48 || str[i] > 57) && (str[i-1] >= 48 && str[i-1] <= 57))
                    break;
            }
            return Int32.Parse(number);
        }

        public static ESet DelPositiveElements(this ESet obj)
        {
            int[] arr = new int[obj.array.Length];
            int counter = 0;
            for (int i = 0; i < obj.array.Length; i++)
            {
                if (obj.array[i] <= 0)
                {
                    arr[counter] = obj.array[i];
                    ++counter;
                }
            }
            int[] resArr = new int[counter];
            for (int i = 0; i < counter; i++)
            {
                resArr[i] = arr[i];
            }
            return new ESet { array = resArr };
        }

        public static int MaxMinDiff(ESet obj)
        {
            int max = Int32.MinValue, min = Int32.MaxValue;
            for (int i = 0; i < obj.array.Length; i++)
            {
                if (obj.array[i] > max)
                    max = obj.array[i];
                if (obj.array[i] < min)
                    min = obj.array[i];
            }

            return max - min;
        }

        public static int ArrLength(ESet obj)
        {
            return obj.array.Length;
        }

        public static int ArrSumm(ESet obj)
        {
            int sum = 0;
            for (int i = 0; i < obj.array.Length; i++)
            {
                sum += obj.array[i];
            }

            return sum;
        }
    }
    class ESet
    {
        public class OwnerType
        {
            public string name;
            public int id;
            public string organization;

            public OwnerType(string name, string organization)
            {
                this.name = name;
                this.organization = organization;
                var rnd = new Random();
                id = rnd.Next();
            }
        }
        public class MyDate
        {
            public DateTime Moment;

            public MyDate()
            {
                Moment = DateTime.Now;
            }

            public override string ToString()
            {
                return Moment.ToString();
            }
        }

        public int[] array
        {
            get;
            set;
        }
        public OwnerType Owner;
        public MyDate DateOfCreate;

        public ESet(int[] arr, string name, string organization)
        {
            array = arr;
            Owner = new OwnerType(name, organization);
            DateOfCreate = new MyDate();
        }
        public ESet()
        {
            array = new int[] { };
            Owner = new OwnerType("", "");
            DateOfCreate = new MyDate();
        }

        public bool includes(int val)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == val)
                    return true;
            }

            return false;
        }

        public static bool operator >(ESet obj, ESet mainObj)
        {
            for (int i = 0; i < obj.array.Length; i++)
            {
                if (!mainObj.includes(obj.array[i]))
                    return false;
            }
            return true;
        }

        public static bool operator <(ESet mainObj, ESet obj)
        {
            return obj > mainObj;
        }

        public static ESet operator *(ESet obj1, ESet obj2)
        {
            int a = 0;
            for(int i = 0; i < obj1.array.Length; i++)
            {
                for(int u = 0; u < obj2.array.Length; u++)
                {
                    if (obj1.array[i] == obj2.array[u]) a++;
                }
            }
            int[] concatArr = new int[a];
            for (int i = 0, y = 0; i < obj1.array.Length; i++)
            {
                for (int u = 0; u < obj2.array.Length; u++)
                {
                    if (obj1.array[i] == obj2.array[u])
                    {
                        concatArr[y] = obj1.array[i];
                        y++;
                    }
                }
            }
            return new ESet { array = concatArr };
        }

        public static explicit operator DateTime(ESet obj)
        {
            return obj.DateOfCreate.Moment;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < this.array.Length - 1; i++)
            {
                str += this.array[i] + ", ";
            }

            str += this.array[this.array.Length - 1];
            return str;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var list1 = new ESet(new int[] { 1, 2, 3, 4, 5 }, "oleg", "josjo");
            var list2 = new ESet(new int[] { 2, 4, 5 }, "sanya", "josjo");

            var concatList = list1 * list2;
            Console.WriteLine(concatList.ToString());
            Console.WriteLine(list1 > list2);
            Console.WriteLine(list1 < list2);

            Console.WriteLine(StatisticOperation.ArrLength(concatList));
            Console.WriteLine(StatisticOperation.MaxMinDiff(list2));
            Console.WriteLine(StatisticOperation.ArrSumm(list2));

            string numStr = "aaaaaallo3243daas545jka 89 9ds sd";
            Console.WriteLine("First number -- " + numStr.FirstNumber());

            var arrTest = new ESet(new int[] { -1, 4, 54, -334, 0, -10, 77 }, "", "");
            Console.WriteLine("negative obj -- " + arrTest.DelPositiveElements().ToString());

            Console.WriteLine((DateTime)list2);
        }
    }
}