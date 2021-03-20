using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logger
{
    [TrackingEntityAttribute()]
  public class Number
    {
       [TrackingPropertyAttribute()]
      public int _Number { get;set; }

        public Number (int number)
        {
            _Number = number;
        }
    }
}
