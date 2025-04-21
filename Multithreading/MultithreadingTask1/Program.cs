using System.Numerics;
using MultithreadingModels;
using MultithreadingServices;

List<Phone> phones = DataGenerator.GeneratePhones(20);
List<Manufacturer> manufacturers = DataGenerator.GenerateManufacturers(20);

Thread thread1 = new(() =>
{
    XmlSerializerService.SaveToXml(phones.GetRange(0, 10), "phones_part1.xml");
    XmlSerializerService.SaveToXml(manufacturers.GetRange(0, 10), "manufacturers_part1.xml");
});

Thread thread2 = new(() =>
{
    XmlSerializerService.SaveToXml(phones.GetRange(10, 10), "phones_part2.xml");
    XmlSerializerService.SaveToXml(manufacturers.GetRange(10, 10), "manufacturers_part2.xml");
});

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

Console.WriteLine("Serialization completed.");