using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Inventory :IManagingItems
    {
        private Dictionary<Item, bool> items = new Dictionary<Item, bool>();

        public void ShowItems()
        {
            foreach(KeyValuePair<Item, bool> item in items)
            {
                Console.WriteLine($"- {item.Key.GetItemInfo()}");
            }
        }

        public void ShowItems(ref int idx)
        {
            foreach(KeyValuePair<Item, bool> item in items)
            {
                string equipTxt = "";
                if(item.Value)
                {
                    equipTxt = "[E]";
                }

                Console.WriteLine($"- {++idx}. {equipTxt}{item.Key.GetItemInfo()}");
            }
        }

        public void SetItem(Item item)
        {
            items.Add(item, false);
        }

        public void ChangeEquipState(int idx)
        {
            int curIdx = 1;
            foreach(KeyValuePair<Item, bool> item in items)
            {
                if(curIdx == idx)
                {
                    items[item.Key] = !items[item.Key];
                    break;
                }
                else
                {
                    curIdx++;
                }
            }
        }

        // 프로그래머적 단어보다 게임오브젝트 중심의 단어로 메서드 이름 지정
        // Equipment
        public void UpdateExtraStatus(Player player)
        {
            int e_atk = 0;
            int e_def = 0;
            foreach(KeyValuePair<Item, bool> item in items)
            {
                if(item.Value)
                { // 장착중인 아이템
                    if(item.Key.Type == ItemType.WEAPON)
                    {
                        e_atk += item.Key.Status;
                    }
                    else
                    {
                        e_def += item.Key.Status;
                    }
                }
            }

            player.SetExtraStatus(e_atk, e_def);
        }
    }
}
