using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyTests.Attributes;

namespace TechnologyTests.Linq;

[ClassIndex(Index = 2)]
public class ReflectionStudy
{
    public ReflectionStudy()
    {
        ExecuteTests();
    }

    private void ExecuteTests()
    {
        var objectList = new List<object>() { new SampleModel_01(), new SampleModel_02(), new SampleModel_03() };

        objectList.ForEach(GenericLog);
    }

    private void GenericLog(object obj)
    {
        var type = obj.GetType();

        var logText = new StringBuilder();

        logText.AppendLine("Log date: " + DateTimeOffset.Now);

        type.GetProperties().ToList().ForEach(p =>
        {
            logText.AppendLine($"{p.Name}: {p.GetValue(obj)}");
        });

        Console.WriteLine(logText.ToString());
    }

    private class SampleModel_01
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Name";
        public string Description { get; set; } = "This is me!";
    }

    private class SampleModel_02
    {
        public int Id { get; set; } = 2;
        public string Name { get; set; } = "Troll";
        public float attack { get; set; } = 100.5f;
        public float defense { get; set; } = 50;
    }

    private class SampleModel_03
    {
        public int Id { get; set; } = 3;
        public string Model { get; set; } = "Delux";
        public string SerialNumber { get; set; } = "0bedc3a4-9aaf-40f0-acee-ff111986ebd4";
        public decimal Price { get; set; } = 250.50m;
    }
}