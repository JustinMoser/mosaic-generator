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
            var sourceImageDirectory = "D:\\(A) MyData\\Projects\\LBI.Mosiac\\Resources\\TestLibrary\\SourceImage\\";
            ImageMapGenerator imageMapGenerator = new ImageMapGenerator(sourceImageDirectory);
            imageMapGenerator.CreateImageMap();
        }
    }
}
