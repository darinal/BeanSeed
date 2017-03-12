
namespace BeanSeed.MainHeroes
{
    public abstract class Human : FairyHero
    {
        private Sex sex;
        private Profession profession;

        public Human(string name, Sex sex, Profession profession) :
            base(name)
        {
            this.sex = sex;
            this.profession = profession;
        }
    }
}
