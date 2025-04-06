using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public class Phone
    {
        private int ID { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string PhoneType { get; set; }

        public static Phone Create(int id, string model, string serialNumber, string phoneType)
        {
            return new Phone { ID = id, Model = model, SerialNumber = serialNumber, PhoneType = phoneType };
        }

        public void PrintObject()
        {
            Console.WriteLine($"Phone: ID=HIDDEN, Model={Model}, SerialNumber={SerialNumber}, PhoneType={PhoneType}");
        }
    }
}
