using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanSeed.MainHeroes
{
    public class HeroException : Exception
    {
        public override string Message
        {
            get
            {
                return "Wrong heroe's parameters";
            }
        }
    }
}
