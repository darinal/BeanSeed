using BeanSeed.Behaviour;
using BeanSeed.FairyThings;
using BeanSeed.OrderInformation;
using System;

namespace BeanSeed.MainHeroes
{
    public class Cow : FairyHero, ICustomer
    {
        #region Fairy objects which here is connected to
        // Object to give to hen
        private FairyObject producedObject;
        public FairyObject ProducedObject { get { return producedObject; } }
        #endregion

        // object which hero needs to produce what hen wants
        private FairyObject neededObject;
        public FairyObject NeededObject { get { return neededObject; } }

        /// <summary>
        /// Create cow-hero who can produce milk but need somethng to eat before
        /// </summary>
        /// <param name="name">hero name</param>
        public Cow(string name)
            : base(name)
        {
            this.producedObject = new FairyObject("молоко");
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

            // Create next hero, which can give needed component
            Farmer farmer = new Farmer("Фермер", Sex.Male, Profession.Farmer);
            this.OrderFairyObject += farmer.ListenRequest;
            this.ReceiveOrderBack += ((Farmwife)sender).ReceiveFairyObject;

            // Couple of words to describe situation
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("- {0} меня уже сутки не кормил! Принеси мне поесть {1} и я дам тебе {2}.", farmer, farmer.ProducedObject, this.ProducedObject);
            Console.ResetColor();

            // no needed object - no answer
            if (NeededObject == null)
                if (OrderFairyObject != null)
                    OrderFairyObject(this, new OrderEventArgs(carrier, farmer, farmer.ProducedObject));
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
            Console.Write("{0}, съев {1}, дала {2}. ", this, this.neededObject, this.producedObject, args.Carrier);
            if (ReceiveOrderBack != null)
                ReceiveOrderBack(this, new OrderEventArgs(args.Carrier, this, producedObject));
        }
    }
}
