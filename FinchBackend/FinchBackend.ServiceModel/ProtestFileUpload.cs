using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinchBackend.ServiceModel
{
    [Route("/protests/file")]
    public class ProtestFileUpload : BaseRequest
    {
        public string TextContents { get; set; }
    }
}
