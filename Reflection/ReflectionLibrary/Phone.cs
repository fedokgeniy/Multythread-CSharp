using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public enum PhoneType
    {
        Smartphone,
        FeaturePhone,
        FlipPhone,
        FoldablePhone,
        GamingPhone,
        BudgetPhone
    }

    public class Phone
    {
        private int ID { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public PhoneType Type { get; set; }

        public static Phone Create(int id, string model, string serialNumber, PhoneType phoneType)
        {
            return new Phone { ID = id, Model = model, SerialNumber = serialNumber, Type = phoneType };
        }

        public void PrintObject()
        {
            Console.WriteLine($"Phone: ID=HIDDEN, Model={Model}, SerialNumber={SerialNumber}, PhoneType={Type}");
        }
    }
}
