
using System;
using System.IO;
using System.Xml.Serialization;

namespace TestJobForCITApp
{
    [XmlRoot(ElementName = "File")]
    public class FileToXml
    {
        [XmlText]
        public string Text { get; set; }

        public FileToXml ConvertFile(string filePath)
        {
            Text = Environment.NewLine+
                   @"       <htmlx xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""ru"" lang=""ru"">"
                                  + Environment.NewLine;
            Text += @"        <body>" + Environment.NewLine;
            Text += $@"              <a href=""{filePath}"" download="""">{Path.GetFileName(filePath)}</a>"
                      + Environment.NewLine;
            Text += @"       </body>" + Environment.NewLine;
            Text += @"      </htmlx>";
            return this;
        }
    }
}
