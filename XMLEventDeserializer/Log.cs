
using System.Xml.Serialization;

[XmlRoot("log")]
public class Log
{
    [XmlElement("event")]
    public List<Event> Events { get; set; }
}