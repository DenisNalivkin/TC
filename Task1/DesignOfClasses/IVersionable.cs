using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
  public interface IVersionable
    {
        byte[] Version { get; set; }
        void InstallVersion(string vers);
        void ReadVersion();    
    }
}
