using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestJobForCITApp
{
	[XmlRoot(ElementName = "Field")]
    public class Field
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ListFields")]
    public class ListFields
    {
        public ListFields()
        {
            Field = new List<Field>();
        }
        [XmlElement(ElementName = "Field")]
        public List<Field> Field { get; set; }
    }
}