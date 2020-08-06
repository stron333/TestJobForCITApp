using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestJobForCITApp
{/*
    [Serializable]
    public class TableForXML
    {
        public TableForXML()
        {
            TRows = new List<TRow>();
        }
        public List<TRow> TRows { get; set; }


        public TableForXML ConvertDataTAble(DataTable dataTable)
        {
            TRow rowHead = new TRow();
            foreach (DataColumn columnTable in dataTable.Columns)
            {
                rowHead.TCells.Add(columnTable.ColumnName);
            }
            TRows.Add(rowHead);

            foreach (DataRow rowTable in dataTable.Rows)
            {
                TRow row = new TRow();
                var cells = rowTable.ItemArray;
                foreach (object cell in cells)
                    row.TCells.Add(cell.ToString());
                TRows.Add(row);
            }

            return this;
        }
    }
    [Serializable]
    public class TRow
    {
        public TRow()
        {
            TCells = new List<string>();
        }
        public List<string> TCells { get; set; }
    }*/



    

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
        public TableForXML()
        {
            TRow = new List<TRow>();
        }

        [XmlElement(ElementName = "TRow")]
        public List<TRow> TRow { get; set; }


        public TableForXML ConvertDataTAble(DataTable dataTable)
        {
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
