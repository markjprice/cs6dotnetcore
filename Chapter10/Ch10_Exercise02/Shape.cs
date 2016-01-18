using System.Xml.Serialization;

namespace Ch10_Exercise02
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class Shape
    {
        public string Colour { get; set; }
        public abstract double Area { get; }
    }
}
