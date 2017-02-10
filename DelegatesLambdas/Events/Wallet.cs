using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Wallet
    {
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
            }
        }

        public Wallet(string name)
        {
            Owner = name;
            Money = 0;
        }

    }
}
