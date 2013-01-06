using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Mosaic.Business;

namespace Mosaic.Service
{
    public class MosaicService : IMosaicService
    {
        public MapGrid GenerateMap(string imageUrl, string width, string height)
        {
            var imageMapGenerator = new ImageMapGenerator(imageUrl);
            return imageMapGenerator.CreateImageMap(width, height);
        }
    }
}
