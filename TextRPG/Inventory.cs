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
        private Item? weapon;
        private Item? armor;

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

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void ChangeEquipState(int idx)
        {
            int curIdx = 1;
            foreach(KeyValuePair<Item, bool> item in items)
            {
                if(curIdx == idx)
                {
                    switch(item.Key.Type)
                    {
                        case ItemType.WEAPON:
                            if(weapon == null)
                            {
                                weapon = item.Key;
                                items[item.Key] = true;
                            }
                            else
                            {
                                items[weapon] = false;
                                weapon = item.Key;
                                items[item.Key] = true;
                            }
                            break;
                        case ItemType.ARMOR:
                            if(armor == null)
                            {
                                armor = item.Key;
                                items[item.Key] = true;
                            }
                            else
                            {
                                items[armor] = false;
                                armor = item.Key;
                                items[item.Key] = true;
                            }
                            break;
                    }

                    
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

            if(weapon != null) e_atk += weapon.Status;
            if(armor != null) e_def += armor.Status;

            player.SetExtraStatus(e_atk, e_def);
        }
    }
}
