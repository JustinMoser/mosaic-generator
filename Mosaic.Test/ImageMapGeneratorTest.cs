using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mosaic.Business;

namespace Mosaic.Test
{
    [TestClass]
    public class ImageMapGeneratorTest
    {
        [TestMethod]
        public void CreateImageMapTest()
        {
            var sourceImageDirectory = "F:\\Work Projects\\baysick Design Projects\\mosaic-generator\\Resources\\TestLibrary\\SourceImage\\";
            ImageMapGenerator imageMapGenerator = new ImageMapGenerator(sourceImageDirectory);
            imageMapGenerator.CreateImageMap();
        }
    }
}
