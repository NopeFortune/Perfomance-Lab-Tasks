using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLtask3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу \"tests.json\": ");
            string testspath = Console.ReadLine();
            Console.Write("Введите путь к файлу \"values.json\": ");
            string valuespath = Console.ReadLine();

            Console.WriteLine();

            JsonTask(testspath, valuespath);
            Console.ReadLine();
        }

        public static void JsonTask(string testpath, string valuespath)
        {
            string jsontest = File.ReadAllText(testpath);
            string jsonvalue = File.ReadAllText(valuespath);

            var testsmodel = JsonConvert.DeserializeObject<TestRoot>(jsontest);
            var valuesmodel = JsonConvert.DeserializeObject<RootValue>(jsonvalue);

            for (int i = 0; i < testsmodel.tests.Count; i++)
            {
                Console.WriteLine($"id: {testsmodel.tests[i].id} title: {testsmodel.tests[i].title}");
            }

            Console.WriteLine();

            for (int i = 0; i < valuesmodel.values.Count; i++)
            {
                Console.WriteLine($"id: {valuesmodel.values[i].id} values: {valuesmodel.values[i].value}");
            }
        }
    }

    public class Value
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<Value> values { get; set; }
    }

    public class RootValue
    {
        public List<Value> values { get; set; }
    }

    public class Test
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<Value> values { get; set; }
    }

    public class TestRoot
    {
        public List<Test> tests { get; set; }
    }
}
