using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Rest
    {
        private int price;
        private int healAmount;

        public Rest(int price, int healAmount)
        {
            this.price = price;
            this.healAmount = healAmount;
        }
    }
}
