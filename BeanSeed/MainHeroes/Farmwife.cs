using BeanSeed.Behaviour;
using BeanSeed.FairyThings;
using BeanSeed.OrderInformation;
using System;

namespace BeanSeed.MainHeroes
{
    public class Farmwife : Human
    {
        #region Fairy objects which here is connected to
        private FairyObject producedObject;
        public FairyObject ProducedObject { get { return producedObject; } }

        private FairyObject neededObject;
        public FairyObject NeededObject { get { return neededObject; } }
        #endregion

        #region Indicators for deliver
        public event EventHandler<OrderEventArgs> ReceiveOrder;
        public event EventHandler<OrderEventArgs> DeliverOrder;
        #endregion

        public Farmwife(string name, Sex sex, Profession profession)
            : base(name, sex, profession)
        {
            this.producedObject = new FairyObject("масло");
            this.neededObject = null;
        }
        /// <summary>
        /// Listen to carrier and direct to another person
        /// </summary>
        /// <param name="sender">previous hero</param>
        /// <param name="args">order params</param>
        public void ListenRequest(object sender, OrderEventArgs args)
        {
            IDeliver carrier = args.Carrier;

            this.ReceiveOrder += carrier.ReceiveOrder;
            
            Cow cow = new Cow("Корова");
            this.ReceiveOrder += cow.ListenRequest;
            this.DeliverOrder += ((Hen)sender).HeplHusband;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- Ой, а у меня закончилось {2}! Возле дома в хлеву стоит {0}. Попроси у неё {1}, из него сделаю тебе {2}.", cow, cow.ProducedObject, this.ProducedObject);
            Console.ResetColor();

            if (NeededObject == null)
                if (ReceiveOrder != null)
                    ReceiveOrder(this, new OrderEventArgs(carrier, cow, cow.ProducedObject));
                else
                    throw new HeroException();
            else
                if (DeliverOrder != null)
                    DeliverOrder(this, new OrderEventArgs(carrier, this, ProducedObject));
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
            Console.Write("{0}, получив {1}, сделала из него {2}. ", this, this.neededObject, this.producedObject);
            if (DeliverOrder != null)
                DeliverOrder(this, new OrderEventArgs(args.Carrier, this, producedObject));
        }
    }
}
