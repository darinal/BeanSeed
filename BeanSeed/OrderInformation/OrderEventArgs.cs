using BeanSeed.Behaviour;
using BeanSeed.FairyThings;
using BeanSeed.MainHeroes;

namespace BeanSeed.OrderInformation
{
    public class OrderEventArgs
    {
        public IDeliver Carrier { get; private set; }
        public FairyHero Supplier { get; private set; }
        public FairyObject FairyObject { get; private set; }
        public OrderEventArgs(IDeliver carrier, FairyHero supplier, FairyObject fairyObject)
        {
            Carrier = carrier;
            Supplier = supplier;
            FairyObject = fairyObject;
        }
    }
}
