using BeanSeed.MainHeroes;
using System;

namespace BeanSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Rooster rooster = new Rooster("Петушок");
            rooster.Choke();

            Hen hen = new Hen("Курочка");
            hen.AskForHelp();
            Console.ReadLine();
        }
    }
}
