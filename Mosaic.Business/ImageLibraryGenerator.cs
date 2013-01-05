using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;

namespace Mosaic.Business
{
    public class ImageLibraryGenerator
    {
        private string OriginalFileDirectoryPath;
        private string ProcessedFileDirectoryPath;

        public ImageLibraryGenerator(string originalFileDirectoryPath, string processedFileDirectoryPath)
        {
            OriginalFileDirectoryPath = originalFileDirectoryPath;
            if (!Directory.Exists(originalFileDirectoryPath))
            {
                throw new Exception("Error resolving original image directory path");
            }

            ProcessedFileDirectoryPath = processedFileDirectoryPath;
            if (!Directory.Exists(processedFileDirectoryPath))
            {
                throw new Exception("Error resolving outuput image directory path");
            }
        }

        public static string[] GetProcessedFiles()
        {
            try
            {
                return Directory.GetFiles(System.Configuration.ConfigurationManager.AppSettings["ProcessedImageLibraryDirectory"]);
            }
            catch (Exception e)
            {
                throw new Exception("Error accessing output image directory: " + e.Message);
            }
        }

        public void CreateXmlImageLibrary()
        {
            ResizeAllImages(OriginalFileDirectoryPath, ProcessedFileDirectoryPath, 10);
            var images = GetImages();
            var xml = SerializeImageLibraryToXml(images);
            WriteXmlToFile(xml);
        }

        public static List<LibraryImage> GetImages()
        {
            List<LibraryImage> imageList = new List<LibraryImage>();
            foreach (string filePath in GetProcessedFiles())
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                LibraryImage image = new LibraryImage(fileName, GetAverageColor(filePath), GetAverageColor(filePath).ToString());
                imageList.Add(image);
            }

            return imageList;
        }

        public void ResizeAllImages(string sourceFolder, string destinationFolder, int newImageSize)
        {
            if (!Directory.Exists(sourceFolder))
            {
                throw new Exception("Source Folder cannot be found");
            }

            if (!Directory.Exists(destinationFolder))
            {
                throw new Exception("Destination Folder cannot be found");
            }

            DirectoryInfo imageDirectory = new DirectoryInfo(sourceFolder);
            ArrayList allImages = new ArrayList();

            allImages.AddRange(imageDirectory.GetFiles("*.gif"));
            allImages.AddRange(imageDirectory.GetFiles("*.jpg"));
            allImages.AddRange(imageDirectory.GetFiles("*.bmp"));
            allImages.AddRange(imageDirectory.GetFiles("*.png"));


            foreach (FileInfo image in allImages)
            {
                ResizeImage(image, newImageSize, sourceFolder, destinationFolder);
            }
        }

        public void ResizeImage(FileInfo image, int newImageSize, string sourceFolder, string destinationFolder)
        {            
            Image originalImage;
            float originalHeight;
            float originalWidth;
            int newHeight;
            int newWidth;
            Bitmap resizedBitmap;
            Graphics resizedImage;

            originalImage = Image.FromFile(image.FullName);
            originalHeight = originalImage.Height;
            originalWidth = originalImage.Width;

            if (originalHeight > originalWidth)
            {
                newHeight = newImageSize;
                newWidth = (int)((originalWidth / originalHeight) * (float)newImageSize);
            }
            else
            {
                newWidth = newImageSize;
                newHeight = (int)((originalHeight / originalWidth) * (float)newImageSize);
            }

            resizedBitmap = new Bitmap(newWidth, newHeight);
            resizedImage = Graphics.FromImage(resizedBitmap);

            resizedImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
            resizedImage.CompositingQuality = CompositingQuality.HighQuality;
            resizedImage.SmoothingMode = SmoothingMode.HighQuality;

            resizedImage.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            resizedBitmap.Save(destinationFolder + image.Name);

            originalImage.Dispose();
            resizedBitmap.Dispose();
            resizedImage.Dispose();
        }

        public static Color GetAverageColor(string filePath)
        {
            Bitmap originalBitmap = new Bitmap(filePath);
            return GetAverageColorFromBitmap(originalBitmap);
        }

        public static Color GetAverageColorFromBitmap(Bitmap bitmap)
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            Color color = System.Drawing.Color.White;

            for (int i = 1; i < bitmap.Width; i++)
            {
                for (int j = 1; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    red += color.R;
                    green += color.G;
                    blue += color.B;
                }
            }

            red = (red / (bitmap.Height * bitmap.Width));
            green = (green / (bitmap.Height * bitmap.Width));
            blue = (blue / (bitmap.Height * bitmap.Width));


            return System.Drawing.Color.FromArgb(red, green, blue);
        }

        public string SerializeImageLibraryToXml(List<LibraryImage> imageList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<LibraryImage>));
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            serializer.Serialize(stringWriter, imageList);
            stringWriter.Close();

            return sb.ToString();
        }

        public void WriteXmlToFile(string xmlString)
        {
            using (TextWriter textWriter = new StreamWriter(ConfigurationManager.AppSettings["ImageLibraryXmlOutputPath"]))
            {
                textWriter.Write(xmlString);
            }
        }
    }
}
