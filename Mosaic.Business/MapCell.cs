using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;

namespace Mosaic.Business
{
    [Serializable]
    public class MapCell
    {
        public int CellPositionX { get; set; }
        public int CellPositionY { get; set; }
        [XmlIgnore]
        public Color AverageColor { get; set; }
        public string AverageColorAsString { get; set; }

        public MapCell()
        {

        }

        public MapCell(int cellPositionX, int cellPositionY, string averageColorAsString, Color averageColor)
        {
            CellPositionX = cellPositionX;
            CellPositionY = cellPositionY;
            AverageColor = averageColor;
            AverageColorAsString = averageColorAsString;
        }
    }
}
