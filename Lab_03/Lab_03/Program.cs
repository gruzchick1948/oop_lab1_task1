using System;

namespace Lab_03
{
    class program
    {
        static void Main(string[] args)
        {
            try
            {
                phone[] phone1 = new phone[6];
                phone1[0] = new phone("Илья", "Раченок", "Александрович", 2076, 200, 300, 4, 0);
                phone1[1] = new phone("Андрей", "Бердяев", "Максимович", 3215, 523, 98, 5, 0);
                phone1[2] = new phone("Александр", "Хлебников", "Васильевич", 4015, 768, 89, 5, 4);
                phone1[3] = new phone("Глеб", "Крученых", "Александрович", 1235, 100, 456, 12, 8);
                phone1[4] = new phone("Владислав", "Терентьев", "Андреевич", 1189, 267, 300, 11, 8);
                phone1[5] = new phone("Софья", "Бурлюк", "Сергеевна", 4328, 678, 454, 5, 5);

                Console.WriteLine("сведения об абонентах, у которых время внутригородских разговоров превышает 10:");
                for (int i = 0; i < 6; i++)
                {
                    if (phone1[i].Intown > 10)
                        Console.WriteLine($"ФИО:{phone1[i].Name} {phone1[i].Surname} {phone1[i].Patron}; Номер: {phone1[i].Number};");
                }
                Console.WriteLine("\n\nсведения об абонентах, которые пользовались междугородной связью:");
                for (int i = 0; i < 6; i++)
                {
                    if (phone1[i].Outtown > 0)
                        Console.WriteLine($"ФИО:{phone1[i].Name} {phone1[i].Surname} {phone1[i].Patron}; Номер: {phone1[i].Number};");
                }
                Console.WriteLine("\n\nБалансы номеров:");
                for (int i = 0; i < 6; i++)
                {
                    phone1[i].balance(phone1[i]);
                }

                phone gleb1 = new phone("Глеб");
                phone gleb = new phone("Глеб", 3469, "Пташков");
                phone vlad = new phone("Владислав", 1232, "Папко");
                phone vlad2 = new phone("Владислав", 1232, "Папко");
                phone maks = new phone("Максим", 1039, "Васильев");

                Console.WriteLine(gleb.ToString());
                Console.WriteLine("Сравнение объектов(true or false):");
                Console.WriteLine(vlad.Equals(vlad2));
                Console.WriteLine(maks.GetHashCode());
                int num = 1423, newnum;
                gleb.Changeaddr(ref num, out newnum);


                phone.PrintInfo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
