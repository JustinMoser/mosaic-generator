using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mosaic.Business
{
    public class MosaicManager
    {
        private string OriginalFileDirectoryPath;
        private string ProcessedFileDirectoryPath;

        private string SourceImageDirectory;
        private string SourceImageFilePath;

        private string TiledImageOutputDirectory;
        private string TiledImageOutputFilePath;

        private string MosaicImageOutputPath;

        public MosaicManager()
        {
            OriginalFileDirectoryPath = System.Configuration.ConfigurationManager.AppSettings["StockImageLibraryDirectory"];
            ProcessedFileDirectoryPath = System.Configuration.ConfigurationManager.AppSettings["ProcessedImageLibraryDirectory"];
            SourceImageDirectory = System.Configuration.ConfigurationManager.AppSettings["SourceImageDirectory"];
            SourceImageFilePath = Directory.GetFiles(SourceImageDirectory).FirstOrDefault();


            TiledImageOutputDirectory = System.Configuration.ConfigurationManager.AppSettings["TiledImageOutputDirectory"];
            TiledImageOutputFilePath = System.Configuration.ConfigurationManager.AppSettings["TiledImageOutputPath"];

            MosaicImageOutputPath = System.Configuration.ConfigurationManager.AppSettings["MosaicImageOutputPath"];
        }

        public void ProcessImageLibrary()
        {
            ImageLibraryGenerator imageLibraryGenerator = new ImageLibraryGenerator(OriginalFileDirectoryPath, ProcessedFileDirectoryPath);
            imageLibraryGenerator.CreateXmlImageLibrary();
        }

        public void CreateMosaic()
        {
            ImageMapGenerator imageMapGenerator = new ImageMapGenerator(SourceImageDirectory);
            var map = imageMapGenerator.CreateImageMap();
            TiledImageGenerator tiledImageGenerator = new TiledImageGenerator(TiledImageOutputDirectory, TiledImageOutputFilePath);
            tiledImageGenerator.CreateTiledImage(map);
        }

        public void CreateMosaicImage()
        {
            MosaicGenerator mosaicGenerator = new MosaicGenerator(MosaicImageOutputPath);
            mosaicGenerator.CreateMosaic(SourceImageFilePath);

        }
    }
}
