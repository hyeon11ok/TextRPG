using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop :IManagingItems
    {
        private Dictionary<Item, bool> items = new Dictionary<Item, bool>();

        public Shop()
        {
            items.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1000, ItemType.ARMOR, 5), false);
            items.Add(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 1500, ItemType.ARMOR, 9), false);
            items.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, ItemType.ARMOR, 15), false);
            items.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 600, ItemType.WEAPON, 2), false);
            items.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 1500, ItemType.WEAPON, 5), false);
            items.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3500, ItemType.WEAPON, 7), false);

        }

        public void PrintItems()
        {
            foreach(KeyValuePair<Item, bool> item in items)
            {
                string goldStr = "구매완료";
                if(!item.Value)
                {
                    goldStr = item.Key.Gold.ToString() + " G";
                }
                Console.WriteLine($"- {item.Key.GetItemInfo()} / {goldStr}");
            }
        }

        public void PrintItems(ref int idx)
        {
            foreach(KeyValuePair<Item, bool> item in items)
            {
                string goldStr = "구매완료";
                if(!item.Value)
                {
                    goldStr = item.Key.Gold.ToString() + " G";
                }
                Console.WriteLine($"- {++idx}. {item.Key.GetItemInfo()} / {goldStr}");
            }
        }

        public void BuyItem(int idx, Player player, Inventory inventory)
        {
            int curIdx = 1;
            foreach(KeyValuePair<Item, bool> item in items)
            {
                if(curIdx == idx)
                {
                    if(!item.Value)
                    { // 아직 구매하지 않은 경우
                        if(player.Gold >= item.Key.Gold)
                        { // 보유 금액이 부족하지 않은 경우
                            items[item.Key] = true;
                            player.UseGold(item.Key.Gold);
                            inventory.SetItem(item.Key);
                        }
                        else
                        { // 돈이 부족한 경우
                            Console.WriteLine("돈이 부족합니다.");
                            Console.WriteLine();
                        }
                    }
                    else
                    { // 이미 구매한 경우
                        Console.WriteLine("이미 구매한 상품입니다.");
                        Console.WriteLine();
                    }

                    break;
                }
                else
                {
                    curIdx++;
                }
            }
        }
    }
}
