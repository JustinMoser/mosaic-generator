using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;

namespace Mosaic.Business
{
    [Serializable]
    public class MapGrid
    {
        [DataMember]
        public int CellWidth { get; set; }
        [DataMember]
        public int CellHeight { get; set; }
        [DataMember]
        public int ColumnCount { get; set; }
        [DataMember]
        public int RowCount { get; set; }
        [DataMember]
        public List<MapCell> Cells;

        public MapGrid()
        {
            Cells = new List<MapCell>();
        }

        public void AddCell(MapCell cell)
        {
            Cells.Add(cell);
        }

        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MapGrid));
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            serializer.Serialize(stringWriter, this);
            stringWriter.Close();

            return sb.ToString();
        }
    }
}
