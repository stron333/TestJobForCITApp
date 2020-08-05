using System;
using System.Collections.Generic;
using System.Data;


namespace TestJobForCITApp
{
    [Serializable]
    public class ClassForPrinting
    {
        public ClassForPrinting()
        {
            ListFields = new ListFields();
        }

        public ListFields ListFields { get; set; }
        public List<DataTable> ListTables { get; set; }
        public List<string> ListFiles { get; set; }
    }

    [Serializable]
    public class ListFields
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
    }
}
