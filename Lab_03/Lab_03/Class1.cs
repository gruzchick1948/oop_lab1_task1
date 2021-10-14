using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_03
{
    partial class phone
    {
        static int id;
        private string name;
        private string surname;
        private string patron;
        static int addr;
        private int number;
        private int cred;
        private int deb;
        private int intown, outown;

        public phone(string n, string s, string p, int numb, int cred, int deb, int intt, int outt)
        {
            this.name = n;
            this.surname = s;
            this.patron = p;
            this.number = numb;
            this.cred = cred;
            this.deb = deb;
            this.intown = intt;
            this.outown = outt;
        }
        // get and set
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get{ return name; }
            set{ name = value; }
        }
        public string Surname
        {
            get{ return surname; }
            set{ surname = value; }
        }
        public string Patron
        {
            get
            {
                return patron;
            }
            set
            {
                patron = value;
            }
        }
        public int Addr
        {
            get
            {
                return addr;
            }
        }
        public int Number
        {
            get
            { return number; }
            set
            {
                if (value > 0){ number = value; }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
        public int Deb
        {
            get
            {
                return deb;
            }
            set
            {
                if (value > 0)
                {
                    deb = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
        public int Cred
        {
            get
            {
                return cred;
            }
            set
            {
                if (value > 0)
                {
                    cred = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
        public int Intown
        {
            get
            {
                return intown;
            }
            set
            {
                if (value > 0)
                {
                    intown = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
        public int Outtown
        {
            get
            {
                return outown;
            }
            set
            {
                if (value > 0)
                {
                    outown = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            } 
        }
        public void balance(phone phone1)
        {
            Console.WriteLine($"Баланс номера {phone1.number}: {phone1.deb - phone1.cred}");
        }


        //поля
        private readonly int ID;
        private const int MAX_ID = 99;


        //конструкторы
        public phone()
        {
            ID = GetHashCode();
        }
        public phone(string name, int number =1245,  string surname = "Раченок")
        {
            if (!string.IsNullOrEmpty(name) && id <= MAX_ID)
            {
                this.name = name;
                this.number = number;
                this.surname = surname;
                id++;
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }
        static phone()
        {
            addr = 267;
        }

        //// закрытый конструктор
        //private phone() { }


        public void Changeaddr(ref int newaddr, out int addr)
        {
            addr = newaddr;
            Console.WriteLine("Новаый адрес: " + addr);
        }

        public static void PrintInfo()
        {
            Console.WriteLine($"\nИнформация о классе:\nИмя класса: phone\nКоличество объектов: {id}\nМаксимальное количество: {MAX_ID}");
        }
    }
    partial class phone
    {
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("Объект null");
            }
            phone phone2 = obj as phone;
            return phone2.Name == Name && phone2.Number == Number && phone2.Surname == Surname;
        }

        public override int GetHashCode()
        {
            int hash = 269;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = (hash * 47) + number.GetHashCode();
            return hash;

        }

        public override string ToString()
        {
            return $"\nИмя: {Name}; Фамилия: {Surname}; Номер: {Number}; Адрес: {addr}";
        }
    }
}
