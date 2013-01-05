using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;

namespace Mosaic.Business
{
    [Serializable]
    public class LibraryImage
    {
        public string FileName { get; set; }
        [XmlIgnore]
        public Color AverageColor { get; set; }
        public string AverageColorAsString { get; set; }

        public LibraryImage()
        {
        }

        public LibraryImage(string fileName, Color averageColor, string averageColourAsString)
        {
            FileName = fileName;
            AverageColor = averageColor;
            AverageColorAsString = averageColourAsString;
        }
    }
}
