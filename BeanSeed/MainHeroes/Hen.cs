using BeanSeed.Behaviour;
using BeanSeed.FairyThings;
using BeanSeed.OrderInformation;
using System;
using System.Collections.Generic;

namespace BeanSeed.MainHeroes
{
    public class Hen : FairyHero, IDeliver
    {

        Stack<Order> orders;
        public Hen(string name)
            : base(name)
        {
            orders = new Stack<Order>();
        }

        /// <summary>
        /// Hen thinks how she can find butter for her husband and go for help
        /// </summary>
        public void AskForHelp()
        {
            Farmwife farmwife = new Farmwife("Хозяйка", Sex.Female, Profession.Farmer);
            this.AskForFairyObject = farmwife.ListenRequest;
            Console.WriteLine("{0} задумалась, у кого же есть масло? О! {1}! {0} побежала к ней.", this, farmwife);
            
            // hen needs to remember all her orders
            SaveOrder(new Order(farmwife, farmwife.ProducedObject));

            if(orders.Count != 0)
            {
                //ifdorm farmwife about visitor
                if(AskForFairyObject!= null)
                    AskForFairyObject(this, new OrderEventArgs(this, farmwife, farmwife.ProducedObject));
                else
                    throw new HeroException();
            }
        }

        /// <summary>
        /// Finalize trip and help to swallow seed
        /// </summary>
        /// <param name="sender">fairyHero</param>
        /// <param name="args">order  info</param>
        public void HeplHusband(object sender, OrderEventArgs args)
        {
            Order order = GetOrder();
            Console.WriteLine("{0} взяла {1} и смазала ним Петушку горлышко и он снова запел!", this, order.OrderedObject);
        }

        /// <summary>
        /// Save order to list so hen won't forget it
        /// </summary>
        /// <param name="order">order - supplier and fairyObject</param>
        private void SaveOrder(Order order)
        {
            orders.Push(order);
        }

        /// <summary>
        /// Delete from order list 
        /// </summary>
        /// <returns></returns>
        private Order GetOrder()
        {
            if (orders.Count != 0)
                return orders.Pop();
            else 
                throw new OrderException();
        }

        #region Events on which other heroes react
        public event EventHandler<OrderEventArgs> AskForFairyObject;
        public event EventHandler<OrderEventArgs> DeliverFairyObject;
        #endregion

        /// <summary>
        /// Save information about next hero to vizit and his fairyObjects
        /// </summary>
        /// <param name="sender">fairyHero who send to another one</param>
        /// <param name="args">order parameters</param>
        public void ReceiveOrder(object sender, OrderEventArgs args)
        {
            Order order = new Order(args.Supplier, args.FairyObject);
            Console.WriteLine("{0} прибежав, попросила:", this);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("- {0}, дай, пожалуйста, {1}.", args.Supplier, order.OrderedObject);
            Console.ResetColor();
            SaveOrder(order);
        }

        /// <summary>
        /// Get object and deliver it to hero
        /// </summary>
        /// <param name="sender">from whom</param>
        /// <param name="args">info about order</param>
        public void DeliverOrder(object sender, OrderEventArgs args)
        {
            Order order = GetOrder();
            Console.Write("{0} взяла {1} и побежала отдавать.\n", this, order.OrderedObject);
            if (DeliverFairyObject != null)
            {
                DeliverFairyObject(this, new OrderEventArgs(this, order.Supplier, order.OrderedObject));
            }
        }


    }
}
