using BeanSeed.Behaviour;
using BeanSeed.FairyThings;
using BeanSeed.OrderInformation;
using System;

namespace BeanSeed.MainHeroes
{
    public class IronForger : Human, ICustomer
    {
        #region Fairy objects which here is connected to
        // Object to give to hen
        private FairyObject producedObject;
        public FairyObject ProducedObject { get { return producedObject; } }

        // object which hero needs to produce what hen wants
        private FairyObject neededObject;
        public FairyObject NeededObject { get { return neededObject; } }
        #endregion

        public IronForger(string name, Sex sex, Profession profession)
            : base(name, sex, profession)
        {
            this.producedObject = new FairyObject("косу");
            this.neededObject = new FairyObject("чаёк");
        }
        #region Indicators for deliver
        public event EventHandler<OrderEventArgs> OrderFairyObject;
        public event EventHandler<OrderEventArgs> ReceiveOrderBack;
        #endregion

        /// <summary>
        /// Listen to carrier and direct to another person
        /// </summary>
        /// <param name="sender">previous hero</param>
        /// <param name="args">order params</param>
        public void ListenRequest(object sender, OrderEventArgs args)
        {
            IDeliver carrier = args.Carrier; 

            this.ReceiveOrderBack += carrier.DeliverOrder;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- Держи, {0}.", args.Carrier);
            Console.ResetColor();

            this.ReceiveOrderBack += ((Farmer)sender).ReceiveFairyObject;

            if (NeededObject == null)
                throw new HeroException();
            else
                if (ReceiveOrderBack != null)
                    ReceiveOrderBack(this, new OrderEventArgs(carrier, this, ProducedObject));
                else
                    throw new HeroException();
        }

        /// <summary>
        /// Doesn't use becuse of finish-chain hero
        /// </summary>
        public void ReceiveFairyObject(object sender, OrderEventArgs args)
        {
            // не нужно ничего кузнецу, чтобы помочь курочке
        }
    }
}
