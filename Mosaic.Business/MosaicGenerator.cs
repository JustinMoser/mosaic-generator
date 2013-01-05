using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Mosaic.Business
{
    public class MosaicGenerator
    {
        private string MosaicImageOutputPath;

        public void CreateMosaic(string filePath)
        {
            var mosaic = TiledImageGenerator.CreateMosaic(ImageMapGenerator.GenerateMap(filePath, 5, 5));
            var tileImages = CreateTileImageList(mosaic, ImageLibraryGenerator.GetImages());
            var mosaicObject = CreateMosaicImage(mosaic, tileImages);
            SaveMosaicImageAsBitmap(MosaicImageOutputPath, mosaicObject);
        }

        public MosaicGenerator(string mosaicImageOutputPath)
        {
            MosaicImageOutputPath = mosaicImageOutputPath;
        }

        public List<TileImage> CreateTileImageList(Mosaic mosaic, List<LibraryImage> libraryImages)
        {
            List<TileImage> tileImages = new List<TileImage>();

            foreach(MosaicTile tile in mosaic.Tiles)
            {
                tileImages.Add(CreateTileImage(tile, libraryImages));
            }

            return tileImages;
        }

        public TileImage CreateTileImage(MosaicTile tile, List<LibraryImage> libraryImages)
        {
            // Get the closest image
            LibraryImage closestImage = new LibraryImage();
            double closestDelta = double.MaxValue;

            foreach (var libraryImage in libraryImages)
            {
                double delta = ComputeColorDifference(tile.AverageColor, libraryImage.AverageColor);
                if (delta < closestDelta)
                {
                    closestDelta = delta;
                    closestImage = libraryImage;
                }
            }

            return new TileImage(closestImage, tile);
        }

        public double ComputeColorDifference(Color color1, Color color2)
        {
            return Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2));
        }

        public MosaicImage CreateMosaicImage(Mosaic mosaic, List<TileImage> tileImages)
        {
            return new MosaicImage(mosaic.TileWidth * mosaic.ColumnCount, mosaic.TileHeight * mosaic.RowCount, tileImages);
        }

        public void SaveMosaicImageAsBitmap(string destinationFolder, MosaicImage mosaicImage)
        {
            Bitmap mosaicBitmap = new Bitmap(mosaicImage.Width, mosaicImage.Height);

            using (Graphics graphicObject = Graphics.FromImage(mosaicBitmap))
            {
                Rectangle tileRectangle;

                foreach (TileImage tileImage in mosaicImage.TileImages)
                {
                    Bitmap tileBitmap = new Bitmap(tileImage.FilePath);

                    using (TextureBrush tileBrush = new TextureBrush(tileBitmap))
                    {
                        tileRectangle = new Rectangle(tileImage.PosX, tileImage.PosY, tileImage.TileWidth, tileImage.TileHeight);

                        graphicObject.FillRectangle(tileBrush, tileRectangle);
                    }
                }
            }

            mosaicBitmap.Save(destinationFolder, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
