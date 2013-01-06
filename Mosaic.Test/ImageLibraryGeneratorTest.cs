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
            string filePath = "F:\\Work Projects\\baysick Design Projects\\mosaic-generator\\Mosaic.Test\\img\\test.jpg";
            Assert.AreEqual("Color [A=255, R=0, G=0, B=0]", ImageLibraryGenerator.GetAverageColor(filePath).ToString());
        }

        [TestMethod]
        public void SerializeImageLibraryToXmlTest()
        {
            var sourceImagesDirectory = "F:\\Work Projects\\baysick Design Projects\\mosaic-generator\\Resources\\TestLibrary\\Stock\\";
            var processedImagesDirectory = "F:\\Work Projects\\baysick Design Projects\\mosaic-generator\\Resources\\TestLibrary\\Processed\\";
            ImageLibraryGenerator generator = new ImageLibraryGenerator(sourceImagesDirectory, processedImagesDirectory);
            List<LibraryImage> images = new List<LibraryImage>();
            Color color = new Color();
            images.Add(new LibraryImage("blah", color, "#000"));
            Assert.IsFalse(String.IsNullOrEmpty(generator.SerializeImageLibraryToXml(images)));
        }


        public void WriteXmlToFileTest()
        {
            var sourceImagesDirectory = "F:\\Work Projects\\baysick Design Projects\\mosaic-generator\\Resources\\TestLibrary\\Stock\\";
            var processedImagesDirectory = "F:\\Work Projects\\baysick Design Projects\\mosaic-generator\\Resources\\TestLibrary\\Processed\\";
            ImageLibraryGenerator generator = new ImageLibraryGenerator(sourceImagesDirectory, processedImagesDirectory);
            var xmlPath = "F:\\Work Projects\\baysick Design Projects\\mosaic-generator\\Output\\TestXml\\ImageLibrary\\ImageLibrary.xml";
            Assert.IsTrue(File.Exists(xmlPath));
        }
    }
}
