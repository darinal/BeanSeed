using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanSeed.FairyThings
{
    public class FairyObject
    {
        string name;

        public FairyObject(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
