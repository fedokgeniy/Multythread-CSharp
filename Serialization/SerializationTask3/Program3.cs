﻿using SerializationServices;
using SerializationModels;

namespace SerializationTask3
{
    class Program
    {
        static List<Phone> phones = new();
        static List<Manufacturer> manufacturers = new();
        static string phonesFile = "phones.xml";
        static string manufacturersFile = "manufacturers.xml";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1 - Создать 10 телефонов и вывести");
                Console.WriteLine("2 - Создать 10 производителей и вывести");
                Console.WriteLine("3 - Сериализовать телефоны");
                Console.WriteLine("4 - Сериализовать производителей");
                Console.WriteLine("5 - Показать телефоны из XML");
                Console.WriteLine("6 - Показать производителей из XML");
                Console.WriteLine("7 - Показать все Model через XDocument");
                Console.WriteLine("8 - Показать все Model через XmlDocument");
                Console.WriteLine("9 - Изменить значение элемента через XDocument");
                Console.WriteLine("10 - Изменить значение элемента через XmlDocument");
                Console.WriteLine("0 - Выход");

                Console.Write("Выбор: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        phones = DataGenerator.GeneratePhones(10);
                        phones.ForEach(p => p.Print());
                        break;

                    case "2":
                        manufacturers = DataGenerator.GenerateManufacturers(10);
                        manufacturers.ForEach(m => m.Print());
                        break;

                    case "3":
                        XmlSerializerService.SaveToXml(phones, phonesFile);
                        Console.WriteLine("Телефоны сериализованы.");
                        break;

                    case "4":
                        XmlSerializerService.SaveToXml(manufacturers, manufacturersFile);
                        Console.WriteLine("Производители сериализованы.");
                        break;

                    case "5":
                        var loadedPhones = XmlSerializerService.LoadFromXml<Phone>(phonesFile);
                        if (loadedPhones.Count == 0) Console.WriteLine("Файл пуст.");
                        else loadedPhones.ForEach(p => p.Print());
                        break;

                    case "6":
                        var loadedManufacturers = XmlSerializerService.LoadFromXml<Manufacturer>(manufacturersFile);
                        if (loadedManufacturers.Count == 0) Console.WriteLine("Файл пуст.");
                        else loadedManufacturers.ForEach(m => m.Print());
                        break;

                    case "7":
                        XmlReaderService.PrintModelsWithXDocument(phonesFile);
                        break;

                    case "8":
                        XmlReaderService.PrintModelsWithXmlDocument(phonesFile);
                        break;

                    case "9":
                        Console.Write("Введите имя элемента (например, Model): ");
                        string elemNameX = Console.ReadLine();
                        Console.Write("Введите индекс (начиная с 0): ");
                        int indexX = int.Parse(Console.ReadLine());
                        Console.Write("Введите новое значение: ");
                        string newValX = Console.ReadLine();
                        XmlPatcher.UpdateElementValueXDocument(phonesFile, elemNameX, indexX, newValX);
                        break;

                    case "10":
                        Console.Write("Введите имя элемента (например, Model): ");
                        string elemNameXml = Console.ReadLine();
                        Console.Write("Введите индекс (начиная с 0): ");
                        int indexXml = int.Parse(Console.ReadLine());
                        Console.Write("Введите новое значение: ");
                        string newValXml = Console.ReadLine();
                        XmlPatcher.UpdateElementValueXmlDocument(phonesFile, elemNameXml, indexXml, newValXml);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}