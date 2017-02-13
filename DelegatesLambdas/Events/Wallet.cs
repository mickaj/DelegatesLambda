using System;

namespace Events
{
    public class Wallet
    {
        //declaring delegate signature that will be used for event handler
        public delegate void GotSomeMoney(object sender, EventArgs e);

        //declaring an event
        public event GotSomeMoney OnGotSomeMoney;

        //booleans used to help with firing events
        private bool reached100, reached500, reached1000, reached2000 = false;
        private string owner;
        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        private int money;
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
                //creating circumstances in which the event will be fired
                if((money >= 2000)&&(!reached2000))
                {
                    FireEvent(2000);
                    reached2000 = true;
                }
                else
                {
                    if((money >= 1000)&&(!reached1000))
                    {
                        FireEvent(1000);
                        reached1000 = true;
                    }
                    else
                    {
                        if((money >= 500)&&(!reached500))
                        {
                            FireEvent(500);
                            reached500 = true;
                        }
                        else
                        {
                            if((money >= 100)&&(!reached100))
                            {
                                FireEvent(100);
                                reached100 = true;
                            }
                        }
                    }
                }
            }       
        }

        public Wallet()
        {
            Owner = "";
            Money = 0;
        }
   
        //declaring a private method which will be used to fire the event
        //it creates an instance of event arguments class (in this case MoneyEventArgs)
        //it checks if there are any subscriptions to the event before firing it 
        private void FireEvent(int valueCrossed)
        {
            MoneyEventArgs e = new MoneyEventArgs();
            e.Money = Money;
            e.ValueCrossed = valueCrossed;
            if(OnGotSomeMoney != null) //checking if there are subscriptions
            {
                OnGotSomeMoney(this, e); //if there are the event will be fired with 'this' object and e EventArgs as arguments
            }
            //no action if there are no subscriptions
        }

    }

    //declaring class for event arguments. This class must be derived form EventArgs class
    //more on EventArgs: https://msdn.microsoft.com/en-us/library/system.eventargs(v=vs.110).aspx
    public class MoneyEventArgs :EventArgs
    {
        public int Money
        {
            get;
            set;
        }

        public int ValueCrossed
        {
            get;
            set;
        }
    }
}
