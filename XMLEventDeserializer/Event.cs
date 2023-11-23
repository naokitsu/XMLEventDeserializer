
using System.Xml.Serialization;

public class Event
{
    [XmlAttribute("date")]
    public string Date { get; set; }

    [XmlAttribute("result")]
    public string Result { get; set; }

    [XmlElement("ip-from")]
    public string IpFrom { get; set; }

    [XmlElement("method")]
    public string Method { get; set; }

    [XmlElement("url-to")]
    public string UrlTo { get; set; }

    [XmlElement("response")]
    public int Response { get; set; }
}
