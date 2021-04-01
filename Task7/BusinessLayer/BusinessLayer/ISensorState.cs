using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  interface ISensorState
    {
        void ChangeState(Sensor measuringSensor);
        void Work(object obj);
    }
}
