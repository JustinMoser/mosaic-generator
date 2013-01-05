using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mosaic.Business;

namespace Mosaic.Test
{
    [TestClass]
    public class MosaicManagerTest
    {
        [TestMethod]
        public void ProcessImageLibraryTest()
        {
            MosaicManager manager = new MosaicManager();
            manager.ProcessImageLibrary();
        }

        [TestMethod]
        public void CreateMosaicTest()
        {
            MosaicManager manager = new MosaicManager();
            manager.CreateMosaic();
        }

        [TestMethod]
        public void CreateMosaicImageTest()
        {
            MosaicManager manager = new MosaicManager();
            manager.CreateMosaicImage();
        }
    }
}
