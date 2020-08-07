using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestJobForCITApp
{
    [XmlRoot(ElementName = "TRow")]
    public class TRow
    {
        public TRow()
        {
            THead = new List<string>();
            TCell = new List<string>();
        }
        [XmlElement(ElementName = "THead")]
        public List<string> THead { get; set; }
        [XmlElement(ElementName = "TCell")]
        public List<string> TCell { get; set; }
    }

    [XmlRoot(ElementName = "TableForXML")]
    public class TableForXML
    {
        [XmlElement(ElementName = "NameTable")]
        public string NameTable { get; set; }
        [XmlElement(ElementName = "TRow")]
        public List<TRow> TRow { get; set; }

        public TableForXML()
        {
            TRow = new List<TRow>();
        }

       public TableForXML ConvertDataTAble(DataTable dataTable)
       {
           NameTable = dataTable.TableName;
            TRow rowHead = new TRow();
            foreach (DataColumn columnTable in dataTable.Columns)
            {
                rowHead.THead.Add(columnTable.ColumnName);
            }

            TRow.Add(rowHead);

            foreach (DataRow rowTable in dataTable.Rows)
            {
                TRow row = new TRow();
                var cells = rowTable.ItemArray;
                foreach (object cell in cells)
                    row.TCell.Add(cell.ToString());
                TRow.Add(row);
            }

            return this;
        }
    }









}
