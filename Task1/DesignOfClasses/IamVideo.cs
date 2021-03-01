using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
   public interface IamVideo
    {
        string UrlVideo { get; set; }
        string UrlPictureForVideo { get; set; }
        VideoFormat FormatVideo { get; set; }
    }
}
