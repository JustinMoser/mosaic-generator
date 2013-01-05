using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Mosaic.Business
{
    public class TiledImageGenerator
    {
        private string TiledImageOutputDirectory;
        private string TiledImageOutputFilePath;

        public TiledImageGenerator(string tiledImageOutputDirectory, string tiledImageOutputFilePath)
        {
            TiledImageOutputDirectory = tiledImageOutputDirectory;
            if (!Directory.Exists(TiledImageOutputDirectory))
            {
                throw new Exception("Error resolving tiled image output directory");
            }
            TiledImageOutputFilePath = tiledImageOutputFilePath;
        }

        public void CreateTiledImage(MapGrid map)
        {
            var mosaic = CreateMosaic(map);
            SaveTiledImageAsBitmap(TiledImageOutputFilePath, mosaic);
        }

        public static Mosaic CreateMosaic(MapGrid mapgrid)
        {
            Mosaic mosaic = new Mosaic();
            mosaic.TileWidth = mapgrid.CellWidth;
            mosaic.TileHeight = mapgrid.CellHeight;
            mosaic.ColumnCount = mapgrid.ColumnCount;
            mosaic.RowCount = mapgrid.RowCount;

            foreach (MapCell cell in mapgrid.Cells)
            {
                MosaicTile tile = new MosaicTile(mosaic.TileWidth, mosaic.TileHeight, cell.CellPositionX, cell.CellPositionY, cell.AverageColor);
                mosaic.AddTile(tile);
            }

            return mosaic;
        }

        public void SaveTiledImageAsBitmap(string destinationFolder, Mosaic mosaic)
        {
            int bitmapWidth = mosaic.ColumnCount * mosaic.TileWidth;
            int bitmapHeight = mosaic.RowCount * mosaic.TileHeight;
            Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight);

            using (Graphics graphicObject = Graphics.FromImage(bitmap))
            {
                Rectangle tileRectangle;

                foreach (MosaicTile tile in mosaic.Tiles)
                {
                    using (SolidBrush tileBrush = new SolidBrush(tile.AverageColor))
                    {
                        tileRectangle = new Rectangle(tile.PosX, tile.PosY, mosaic.TileWidth, mosaic.TileHeight);

                        graphicObject.FillRectangle(tileBrush, tileRectangle);
                    }
                }
            }

            bitmap.Save(destinationFolder, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
