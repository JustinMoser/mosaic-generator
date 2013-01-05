using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mosaic.Business
{
    [Serializable]
    public class MosaicTile
    {
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Color AverageColor { get; set; }

        public MosaicTile()
        {

        }

        public MosaicTile(int tileWidth, int tileHeight, int posX, int posY, Color averageColor)
        {
            TileWidth = TileWidth;
            TileHeight = tileHeight;
            PosX = posX;
            PosY = posY;
            AverageColor = averageColor;
        }
    }
}
