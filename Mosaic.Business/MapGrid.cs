using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;

namespace Mosaic.Business
{
    [Serializable]
    public class MapGrid
    {
        public int CellWidth { get; set; }
        public int CellHeight { get; set; }
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
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
