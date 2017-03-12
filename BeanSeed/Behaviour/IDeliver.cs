using BeanSeed.OrderInformation;
using System;
using System.Collections.Generic;

namespace BeanSeed.Behaviour
{
    public interface IDeliver
    {
        // Reaction on new order
        void ReceiveOrder(object sender, OrderEventArgs args);
        void DeliverOrder(object sender, OrderEventArgs args);


        event EventHandler<OrderEventArgs> AskForFairyObject;
        event EventHandler<OrderEventArgs> DeliverFairyObject;

    }
}
