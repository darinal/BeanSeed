using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanSeed.OrderInformation
{
    public class OrderException : Exception
    {
        public override string Message
        {
            get
            {
                return "Order doesn't exist";
            }
        }
    }
}
