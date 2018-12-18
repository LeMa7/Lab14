using lab14;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace Lab14
{
    class Program
    {
        static void BinarySerialize(object obj)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fileStream = new FileStream("candyObjBin.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                bin.Serialize(fileStream, obj);
            }
        }

        static void BinaryDeserialize()
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fileStream = File.OpenRead("candyObjBin.dat"))
            {
                Candy candyUsing = (Candy)bin.Deserialize(fileStream);
                Console.WriteLine(candyUsing.ToString());
            }
        }

        static void SoapSerialize(object obj)
        {
            SoapFormatter soap = new SoapFormatter();
            using(Stream fileStream = new FileStream("candyObjSoap.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soap.Serialize(fileStream, obj);
            }
        }

        static void SoapDeserialize()
        {
            SoapFormatter soap = new SoapFormatter();
            using (Stream fileStream = File.OpenRead("candyObjSoap.soap"))
            {
                Candy candyUsing = (Candy)soap.Deserialize(fileStream);
                Console.WriteLine(candyUsing.ToString());
            }
        }

        static void XmlSerialize(object obj)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Candy));
            using (Stream fileStream = new FileStream("candyObjXML.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xml.Serialize(fileStream, obj);
            }
        }

        static void XmlDeserialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Candy));
            using (Stream fileStream = File.OpenRead("candyObjXML.xml"))
            {
                Candy candyUsing = (Candy)xml.Deserialize(fileStream);
                Console.WriteLine(candyUsing.ToString());
            }
        }

        static void JsonSerialize(object obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Candy));
            using (Stream fileStream = new FileStream("candyObjJson.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                json.WriteObject(fileStream, obj);
            }
        }

        static void JsonDeserialize()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Candy));
            using (Stream fileStream = File.OpenRead("candyObjJson.json"))
            {
                Candy candyUsing = (Candy)json.ReadObject(fileStream);
                Console.WriteLine(candyUsing.ToString());
            }
        }

        static void BinaryArraySerialize(object[] obj)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fileStream = new FileStream("candyObjArrayBin.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                
                
                    bin.Serialize(fileStream, obj);
                
            }
        }

        static void BinaryArrayDeserialize()
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fileStream = File.OpenRead("candyObjArrayBin.dat"))
            {
               
                Candy[] candyArrayUsing = (Candy[])bin.Deserialize(fileStream);
                for(int i=0;i<candyArrayUsing.Length;i++)
                Console.WriteLine(candyArrayUsing[i].ToString());
                Console.WriteLine();
            }
        }

        static void XPath()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("oop2.xml");
            XmlElement xRoot = xmlDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("Faculty");
            foreach(XmlNode i in childnodes)
            {
                Console.WriteLine(i.SelectSingleNode("@name").Value);
            }
        }

        

        static void Main(string[] args)
        {
            Candy[] candies = new Candy[3];
            Candy candy = new Candy();
            Candy candy2 = new Candy();
            Candy candy3 = new Candy();
            candy.addInfo();
            candy2.addInfo();
            candy3.addInfo();
            candies[0] = candy;
            candies[1] = candy2;
            candies[2] = candy3;
            Console.WriteLine("Bin:");
            BinarySerialize(candy);
            BinaryDeserialize();
            Console.WriteLine();
            Console.WriteLine("Soap:");
            SoapSerialize(candy);
            SoapDeserialize();
            Console.WriteLine();
            Console.WriteLine("XML:");
            XmlSerialize(candy);
            XmlDeserialize();
            Console.WriteLine();
            Console.WriteLine("Json:");
            JsonSerialize(candy);
            JsonDeserialize();
            Console.WriteLine();
            Console.WriteLine("Array:");
            BinaryArraySerialize(candies);
            BinaryArrayDeserialize();
            XPath();
            XDocument xDoc = new XDocument(new XElement("Subjects",
                                            new XElement("OOP",
                                            new XElement("Labs",
                                            new XElement("Lab", "github"), new XElement("Lab", "Classes"))),
                                            new XElement("KSIS",
                                            new XElement("Labs",
                                            new XElement("Lab", "DHCP"), new XElement("Lab", "DNS")))));
            xDoc.Save("oop.xml");

            Console.WriteLine();

            var oopLabs = xDoc.Root.Elements("OOP").GroupBy(t => t.Element("Labs").Value);
            foreach (IGrouping<string, XElement> a in oopLabs)
                Console.WriteLine(a.Key+"\n");

            var ksisLabs = xDoc.Root.Elements("KSIS").GroupBy(t => t.Element("Labs").Value);
            foreach (IGrouping<string, XElement> a in ksisLabs)
                Console.WriteLine(a.Key + "\n");
        }
    }
}
