using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLtask3._2
{

    #region Описание задачи.
    /*
    На вход в качестве аргументов программы поступают два файла: tests.json и values.json (в
    приложении к заданию находятся примеры этих файлов)
    • values.json содержит результаты прохождения тестов с уникальными id
     tests.json содержит структуру для построения отчёта на основе прошедших тестов
    (вложенность может быть большей, чем в примере)
    Напишите программу, которая формирует файл report.json с заполненными полями value для
    структуры tests.json на основании values.json.

    Пример:
    Часть структуры tests.json:

    {"id": 122, "title": "Security test", "value": "", "values":
    [{"id": 5321, "title": "Confidentiality", "value": ""},
    {"id": 5322, "title": "Integrity", "value": ""}]}

    После заполнения в соответствии с values.json:
    
    {"values": [{"id": 122, "value": "failed"}, {"id": 5321,"value": "passed"}, {"id": 5322,"value": "failed"}]}

    Будет иметь следующий вид в файле report.json:
    
    {"id": 122, "title": "Security test", "value": "failed", "values":
    [{"id": 5321, "title": "Confidentiality", "value": "passed"},
    {"id": 5322, "title": "Integrity", "value": "failed"}]}
    */
    #endregion
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
