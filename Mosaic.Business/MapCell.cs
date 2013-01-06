using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;

namespace Mosaic.Business
{
    [Serializable]
    public class MapCell
    {
        [DataMember]
        public int CellPositionX { get; set; }
        [DataMember]
        public int CellPositionY { get; set; }
        [DataMember]
        public Color AverageColor { get; set; }
        [DataMember]
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
