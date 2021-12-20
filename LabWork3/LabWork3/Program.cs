using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Soap;

namespace LabWork3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();
            for(int i = 1; i < 4; i++)
            {
                products.Add(new Product(i));
            }
            var binFormatter = new BinaryFormatter();
            using(var file = new FileStream("productsBin.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, products);
            }
            using (var file = new FileStream("productsBin.bin", FileMode.OpenOrCreate))
            {
                var newProducts = (List<Product>)binFormatter.Deserialize(file);
                if(newProducts != null)
                {
                    foreach(var prod in newProducts)
                    {
                        Console.WriteLine("Bin");
                        Console.WriteLine(prod.ProductName);
                        Console.WriteLine(prod.ProductCode);
                        Console.WriteLine(prod.ExpirationDate);
                        Console.WriteLine(prod.ProductDateOfManufacture);
                        Console.WriteLine(prod.EndDateOfConsumption());
                        Console.WriteLine(prod.WhetherFitForConsumption());
                        Console.WriteLine("_______________________________________\n");
                    }
                }
            }
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<Product>));
            using (var file = new FileStream("productsXml.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, products);
            }
            using (var file = new FileStream("productsXml.xml", FileMode.OpenOrCreate))
            {
                var newProducts = xmlFormatter.Deserialize(file) as List<Product>;
                if (newProducts != null)
                {
                    foreach (var prod in newProducts)
                    {
                        Console.WriteLine("Xml");
                        Console.WriteLine(prod.ProductName);
                        Console.WriteLine(prod.ProductCode);
                        Console.WriteLine(prod.ExpirationDate);
                        Console.WriteLine(prod.ProductDateOfManufacture);
                        Console.WriteLine(prod.EndDateOfConsumption());
                        Console.WriteLine(prod.WhetherFitForConsumption());
                        Console.WriteLine("_______________________________________\n");
                    }
                }
            }
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
            using (var file = new FileStream("productsJson.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, products);
            }
            using (var file = new FileStream("productsJson.json", FileMode.OpenOrCreate))
            {
                var newProducts = jsonFormatter.ReadObject(file) as List<Product>;
                if (newProducts != null)
                {
                    foreach (var prod in newProducts)
                    {
                        Console.WriteLine("Json");
                        Console.WriteLine(prod.ProductName);
                        Console.WriteLine(prod.ProductCode);
                        Console.WriteLine(prod.ExpirationDate);
                        Console.WriteLine(prod.ProductDateOfManufacture);
                        Console.WriteLine(prod.EndDateOfConsumption());
                        Console.WriteLine(prod.WhetherFitForConsumption());
                        Console.WriteLine("_______________________________________\n");
                    }
                }
            }
            var soapFormatter = new SoapFormatter();
            using (var file = new FileStream("productsSoap.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(file, products.ToArray());
            }
            using (var file = new FileStream("productsSoap.soap", FileMode.OpenOrCreate))
            {
                var newProducts = (Product[])soapFormatter.Deserialize(file);
                if (newProducts != null)
                {
                    foreach (var prod in newProducts)
                    {
                        Console.WriteLine("Soap");
                        Console.WriteLine(prod.ProductName);
                        Console.WriteLine(prod.ProductCode);
                        Console.WriteLine(prod.ExpirationDate);
                        Console.WriteLine(prod.ProductDateOfManufacture);
                        Console.WriteLine(prod.EndDateOfConsumption());
                        Console.WriteLine(prod.WhetherFitForConsumption());
                        Console.WriteLine("_______________________________________\n");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
