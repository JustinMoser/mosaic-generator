using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mosaic.Business
{
    public class Mosaic
    {
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public string Name { get; set; }
        public List<MosaicTile> Tiles { get; set; }

        public Mosaic()
        {
            Tiles = new List<MosaicTile>();
        }

        public void AddTile(MosaicTile tile)
        {
            Tiles.Add(tile);
        }
    }
}
