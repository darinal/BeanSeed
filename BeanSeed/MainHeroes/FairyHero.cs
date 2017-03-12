using BeanSeed.FairyThings;
using System;

namespace BeanSeed.MainHeroes
{
    public abstract class FairyHero
    {
        private string name;
        public FairyHero(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return this.name;
        }
    }
}
