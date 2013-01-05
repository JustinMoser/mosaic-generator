using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mosaic.Business
{
    public class TileImage
    {
        public LibraryImage Image { get; set; }
        public string FilePath { get; set; }
        public MosaicTile Tile { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public TileImage(LibraryImage image, MosaicTile tile)
        {
            Image = image;
            FilePath = System.Configuration.ConfigurationManager.AppSettings["ProcessedImageLibraryDirectory"] + image.FileName;
            Tile = tile;
            PosX = tile.PosX;
            PosY = tile.PosY;
            TileWidth = tile.TileHeight;
            TileHeight = tile.TileHeight;
        }
    }
}
