using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get current directory
            string curDir = Environment.CurrentDirectory;
            //Write text to file
            File.WriteAllText("MyFile.txt", "Volvo;240GLT" + Environment.NewLine);
            File.AppendAllText("MyFile.txt", "Saab;900T" + Environment.NewLine);
            //Read text from file
            string reading = File.ReadAllText("MyFile.txt");

            List<string> fileData = File.ReadLines("MyFile.txt").ToList();

            //Write text to file with StreamWriter
            using (StreamWriter sw = File.CreateText("MyFile2.txt"))
            {
                //sw.WriteLine("Volvo;240GLT");
                //sw.WriteLine("Saab;900T");
                fileData.ForEach(str => sw.WriteLine(str));
            }

            List<Car> streamCars = new List<Car>();

            //Read text from file with StreamWriter
            using (StreamReader sr = File.OpenText("MyFile2.txt"))
            {
                string s;
                while((s = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(s);
                    string[] carArray = s.Split(";");
                    Car car = new Car(carArray[0], carArray[1]);
                    streamCars.Add(car);
                }
            }

            Console.WriteLine("My cars");
            foreach(Car car in streamCars)
            {
                Console.WriteLine(car.Brand + " " + car.Model);
            }

            Console.WriteLine("My cars");
            streamCars.ForEach(car => Console.WriteLine(car.Brand + " " + car.Model));

            Console.ReadLine();
        }
    }

    class Car
    {
        public Car(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
