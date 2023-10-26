using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;
using Newtonsoft.Json;

namespace _26_oct_task
{
    internal class Program
    {

        public static string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Files", "name.json");

        static void Main(string[] args)
        {      
            Add("Nigar");
            Add("Fidan");
            Console.WriteLine(Search("Nigar", x => x == "Nigar"));
            Delete("Nigar");
        }

        static List<string> DeserializeJson()
        {
            List<string> names;
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                names = JsonConvert.DeserializeObject<List<string>>(json);
            }
            return names;
        }

        static void SerializeJson(List<string> names)
        {
            string json = JsonConvert.SerializeObject(names);
            File.WriteAllText(path, json);
        }

        static void Add(string name)
        {
            List<string> names = DeserializeJson();
            names.Add(name);
            SerializeJson(names);
        }

        static bool Search(string name, Predicate<string> predicate)
        {
            List<string> names = DeserializeJson();
            return names.Exists(predicate);
        }

        static void Delete(string name)
        {
            List<string> names = DeserializeJson();
            names.Remove(name);
            SerializeJson(names);
        }
    }
    






}