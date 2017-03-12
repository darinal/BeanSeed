using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanSeed.MainHeroes
{
    public class Rooster : FairyHero
    {
        private bool IsChoked;

        public Rooster(string name)
            : base(name)
        {
            Console.Write("Жил-был {0}. Он любил петь и вечно куда-то торопился. ", this);
        }

        public void Choke()
        {
            IsChoked = true;
            Console.WriteLine("И вот однажды так торопился, что подавился бобовым зёрнышком! Стал задыхаться:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- Маасл.. кху-кха-ре- маааслаа - ку-кхе-кхе...");
            Console.ResetColor();
        }

    }
}
