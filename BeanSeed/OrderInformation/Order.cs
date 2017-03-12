using BeanSeed.FairyThings;
using BeanSeed.MainHeroes;

namespace BeanSeed.OrderInformation
{
    public class Order
    {
        public FairyHero Supplier { get; private set; }
        public FairyObject OrderedObject { get; private set; }
        public Order(FairyHero supplier, FairyObject obj)
        {
            Supplier = supplier;
            OrderedObject = obj;
        }
    }
}
