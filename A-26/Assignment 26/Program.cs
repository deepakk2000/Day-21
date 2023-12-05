using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Assignment_26
{
    public class Program
    {
        //Binary Serialization
        static void Main(string[] args)
        {
            Employee obj = new Employee()
            {
                Id = 1,
                FirstName = "Sam",
                LastName = "Jackson",
                Salary=99000

            };
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\.net\Day-21\A-26\employee.bin", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, obj); 
            stream.Close();
           
            stream = new FileStream(@"D:\.net\Day-21\A-26\employee.bin", FileMode.Open, FileAccess.Read);
            Employee objnew = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("Deserialized Data Binary Formatter:");
            Console.WriteLine(objnew.Id);
            Console.WriteLine(objnew.FirstName);
            Console.WriteLine(objnew.LastName);
            Console.WriteLine(objnew.Salary);
           

            //Xml Serialization

           
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter(@"D:\.net\Day-21\A-26\employee.xml"))
            {
                serializer.Serialize(writer, obj);
            }
            using (TextReader reader = new StreamReader(@"D:\.net\Day-21\A-26\employee.xml"))
            {
                Employee deserialization = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("Deserialized Data Xml Formatter:");
                Console.WriteLine($"ID: {deserialization.Id},FirstName: {deserialization.FirstName},LastName: {deserialization.LastName},Salary: {deserialization.Salary}");

            }
            Console.ReadKey();
        }
    }
}
