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

        public int Price { get { return price; } }
        public int HealAmount { get { return healAmount; } }

        public Rest()
        {
            this.price = 500;
            this.healAmount = 30;
        }

        public void Resting(Player player)
        {
            if(player.CurHp == player.Hp)
            {
                Console.WriteLine("회복이 필요하지 않습니다.");
            }
            else
            {
                if(player.Gold < price)
                {
                    Console.WriteLine("돈이 부족합니다.");
                }
                else
                {
                    player.UseGold(price);
                    player.HpChange(healAmount);
                    Console.WriteLine("회복되었습니다.");
                }
            }
            Console.WriteLine();
        }
    }
}
