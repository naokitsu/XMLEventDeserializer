using System;
using System.Collections.Generic;
using System.Xml.Serialization;

class XMLEventDeserializer
{
    static Log? Parse(Stream stream)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Log));
        return (Log?)serializer.Deserialize(stream);
    }
    
    
    static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Provide the path to the XML file as a command line argument");
            return 1;
        }

        string filePath = args[0];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return 1;
        }

        Log? log;

        using var fileStream = new FileStream(filePath, FileMode.Open);

        if ((log = Parse(fileStream)) is null)
        {
            Console.WriteLine("Unable to parse XML");
            return 1;
        }

        foreach (var logEvent in log.Events)
        {
            Console.WriteLine($"- Event");
            Console.WriteLine($"  - Date: {logEvent.Date}");
            Console.WriteLine($"  - Result: {logEvent.Result}");
            Console.WriteLine($"  - Ip From: {logEvent.IpFrom}");
            Console.WriteLine($"  - Method: {logEvent.Method}");
            Console.WriteLine($"  - URL To: {logEvent.UrlTo}");
            Console.WriteLine($"  - Response: {logEvent.Response}\n");
        }

        return 0;
    }
}
