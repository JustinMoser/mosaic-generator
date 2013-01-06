using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Mosaic.Service
{
    public class MosaicService : IMosaicService
    {
        public string GetData(string url)
        {
            return url;
        }
    }
}
