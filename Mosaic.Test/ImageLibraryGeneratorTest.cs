using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mosaic.Business;

namespace Mosaic.Test
{
    [TestClass]
    public class ImageLibraryGeneratorTest
    {

        [TestMethod]
        public void GetImagesTest()
        {
            //var sourceImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Stock\\";
            //var processedImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Processed\\";
            //ImageLibraryGenerator generator = new ImageLibraryGenerator(sourceImagesDirectory, processedImagesDirectory);
            Assert.IsFalse(String.IsNullOrEmpty(ImageLibraryGenerator.GetImages().ToString()));
        }

        [TestMethod]
        public void GetAverageColorTest()
        {
            //var sourceImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Stock\\";
            //var processedImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Processed\\";
            //ImageLibraryGenerator generator = new ImageLibraryGenerator(sourceImagesDirectory, processedImagesDirectory);
            string filePath = "C:\\Users\\moserju\\Desktop\\test.jpg";
            Assert.AreEqual("Color [A=255, R=0, G=0, B=0]", ImageLibraryGenerator.GetAverageColor(filePath).ToString());
        }

        [TestMethod]
        public void SerializeImageLibraryToXmlTest()
        {
            var sourceImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Stock\\";
            var processedImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Processed\\";
            ImageLibraryGenerator generator = new ImageLibraryGenerator(sourceImagesDirectory, processedImagesDirectory);
            List<LibraryImage> images = new List<LibraryImage>();
            Color color = new Color();
            images.Add(new LibraryImage("blah", color, "#000"));
            Assert.IsFalse(String.IsNullOrEmpty(generator.SerializeImageLibraryToXml(images)));
        }


        public void WriteXmlToFileTest()
        {
            var sourceImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Stock\\";
            var processedImagesDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\Processed\\";
            ImageLibraryGenerator generator = new ImageLibraryGenerator(sourceImagesDirectory, processedImagesDirectory);
            var xmlPath = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Output\\TestXml\\ImageLibrary\\ImageLibrary.xml";
            Assert.IsTrue(File.Exists(xmlPath));
        }
    }
}
