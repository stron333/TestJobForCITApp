using System;
using System.Collections.Generic;


namespace TestJobForCITApp
{
    [Serializable]
    public class ClassForPrinting
    {
        public ClassForPrinting()
        {
            ListFields = new ListFields();
            ListTables = new List<TableForXML>();
            ListFiles = new List<FileToXml>();
        }

        public ListFields ListFields { get; set; }
        public List<TableForXML> ListTables { get; set; }
        public List<FileToXml> ListFiles { get; set; }
    }
    
    
}
