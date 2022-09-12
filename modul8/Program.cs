using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace modul8
{
    internal class Program
    {
        public static List<int> ListAdd(Random random, List<int> list) //метод добавления
        {

            for (int i = 1; i <= 100; i++)
            {
                int rand = random.Next(0, 100);
                list.Add(rand);
            }
            return list;
        }

        public static List<int> ListDelete(List<int> list) //метод удаления
        {
            list.RemoveAll(list => (list > 25 && list < 50));
            return list;
        }

        public static List<int> ListPrint(List<int> list) //метод печати в консоль
        {
            list.ForEach(Console.WriteLine);
            return list;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. Работа с листом");
            Random random = new Random();
            List<int> list = new List<int>();
            ListAdd(random, list);
            Console.WriteLine("Вывод полной коллекции чисел");
            ListPrint(list);
            ListDelete(list);
            Console.WriteLine("Вывод коллекции чисел, кроме тех,\nкоторые больше 25, но меньше 50");
            ListPrint(list);

            Console.WriteLine("Введите Enter для продолжения...");
            Console.ReadKey();

            Console.WriteLine("Задание 2. Телефонная книга");
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            string name;
            string phone = "";
            while (true)
            {
                Console.Write("Введите ФИО: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }

                Console.Write("Введите номер телефона: ");
                phone = Console.ReadLine();
                if (phone == null)
                {
                    break;
                }

                phoneBook.Add(phone, name);
                foreach (KeyValuePair<string, string> e in phoneBook) Console.WriteLine($"{e}");
            }

            Console.WriteLine("Выход из цикла ввода телефонной книги");

            Console.Write("Введите номер телефона для поиска владельца: ");

            if (phoneBook.TryGetValue(Console.ReadLine(), out name))
            {
                Console.WriteLine("ФИО владельца данного номера: {0}.", name);
            }
            else
            {
                Console.WriteLine("Владельца по такому номеру не зарегистрировано");
            }

            Console.WriteLine("Введите Enter для продолжения...");
            Console.ReadKey();

            Console.WriteLine("Задание 3. Проверка повторов");
            HashSet<int> set = new HashSet<int>(new int[] { });

            while (true)
            {
                Console.Write("Введите число: ");

                int num = Convert.ToInt32(Console.ReadLine());
                bool flag = set.Contains(num);
                if (flag == true)
                {
                    Console.WriteLine("Число уже вводилось ранее!");
                }
                if (flag == false)
                {
                    Console.WriteLine("Число успешно сохранено");
                }
                set.Add(num);

                Console.Write("Коллекция HashSet: ");
                foreach (var e in set) { Console.Write($"{e} "); }

                Console.Write("\nНажмите 1 - чтобы продолжить ввод, 2 - чтобы выйти из цикла: ");
                int exit = Convert.ToInt32(Console.ReadLine());

                if (exit == 2)
                {
                    break;
                }
            }

            Console.WriteLine("Задание 4. Записная книжка");

            Console.Write("Введите ФИО: ");
            string person = Console.ReadLine();

            Console.Write("Введите название улицы: ");
            string street = Console.ReadLine();

            Console.Write("Введите номер дома: ");
            int houseNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите номер квартиры: ");
            int flatNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите номер мобильного телефона: ");
            string mobilePhone = Console.ReadLine();

            Console.Write("Введите номер домашнего телефона: ");
            string flatPhone = Console.ReadLine();

            XElement Person = new XElement("Person");
            XElement Address = new XElement("Address");
            XElement Street = new XElement("Street");
            XElement HouseNumber = new XElement("HouseNumber");
            XElement FlatNumber = new XElement("FlatNumber");
            XElement Phones = new XElement("Phones");
            XElement MobilePhone = new XElement("MobilePhone");
            XElement FlatPhone = new XElement("FlatPhone");

            XAttribute xAttrPerson = new XAttribute("name", person);

            Person.Add(xAttrPerson);
            Person.Add(Address, Phones);

            Street.Add(street);
            HouseNumber.Add(houseNumber);
            FlatNumber.Add(flatNumber);
            Address.Add(Street, HouseNumber, FlatNumber);

            Phones.Add(MobilePhone, FlatPhone);
            MobilePhone.Add(mobilePhone);
            FlatPhone.Add(flatPhone);

            Person.Save("_notebook.xml");

            Console.Write("Сохранен файл _notebook.xml в папке с программной");

            Console.ReadKey();
        }
    }
}
