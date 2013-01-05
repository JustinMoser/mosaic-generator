using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mosaic.Business
{
    public class MosaicImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<TileImage> TileImages { get; set; }

        public MosaicImage(int width, int height, List<TileImage> tileImages)
        {
            Width = width;
            Height = height;
            TileImages = tileImages;
        }
    }
}
