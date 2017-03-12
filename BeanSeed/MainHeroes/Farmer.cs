using BeanSeed.Behaviour;
using BeanSeed.FairyThings;
using BeanSeed.OrderInformation;
using System;

namespace BeanSeed.MainHeroes
{
    class Farmer : Human, ICustomer
    {
        #region Fairy objects which here is connected to

        // Object to give to hen
        private FairyObject producedObject;
        public FairyObject ProducedObject { get { return producedObject; } }

        // object which hero needs to produce what hen wants
        private FairyObject neededObject;
        public FairyObject NeededObject { get { return neededObject; } }
        #endregion

        /// <summary>
        /// Create farmer hero who have his own features and can produce grass
        /// </summary>
        /// <param name="name">hero name</param>
        /// <param name="sex">hero sex</param>
        /// <param name="profession">hero profession</param>
        public Farmer(string name, Sex sex, Profession profession)
            : base(name, sex, profession)
        {
            this.producedObject = new FairyObject("травy");
            this.neededObject = null;
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

            this.OrderFairyObject += carrier.ReceiveOrder;
            this.ReceiveOrderBack += carrier.DeliverOrder;

            IronForger ironForger = new IronForger("Кузнец", Sex.Male, Profession.IronForger);
            this.OrderFairyObject += ironForger.ListenRequest;
            this.ReceiveOrderBack += ((Cow)sender).ReceiveFairyObject;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- Знаешь где живёт {0}? Возьми у него {1}, принеси и нею я скошу тебе {2}", ironForger, ironForger.ProducedObject, this.ProducedObject, this);
            Console.ResetColor();
            if (NeededObject == null)
                if (OrderFairyObject != null)
                    OrderFairyObject(this, new OrderEventArgs(carrier, ironForger, ironForger.ProducedObject));
                else
                    throw new HeroException();
            else
                if (ReceiveOrderBack != null)
                    ReceiveOrderBack(this, new OrderEventArgs(carrier, this, ProducedObject));
                else
                    throw new HeroException();
        }

        /// <summary>
        /// Get order and produce what hen wants
        /// </summary>
        /// <param name="sender">next hero</param>
        /// <param name="args">order params</param>
        public void ReceiveFairyObject(object sender, OrderEventArgs args)
        {
            neededObject = args.FairyObject;
            Console.Write("{0}, получив {1}, быстро накосил {2}. ", this, this.neededObject, this.producedObject);
            if (ReceiveOrderBack != null)
                ReceiveOrderBack(this, new OrderEventArgs(args.Carrier, this, this.producedObject));
        }
    }
}
