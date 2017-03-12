using BeanSeed.FairyThings;
using BeanSeed.MainHeroes;
using BeanSeed.OrderInformation;
using System;

namespace BeanSeed.Behaviour
{
    public interface ICustomer
    {
        // object for previous hero
        FairyObject ProducedObject { get; }
        // object which hero is needed to have to produce his product
        FairyObject NeededObject { get; }

        // To inform deliver about new order
        event EventHandler<OrderEventArgs> OrderFairyObject;
        event EventHandler<OrderEventArgs> ReceiveOrderBack;
    }
}
