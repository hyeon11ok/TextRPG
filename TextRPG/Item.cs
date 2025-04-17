using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Item
    {
        private string name;
        private string comment;
        private int gold;
        private int status;
        private ItemType type;

        public int Gold { get { return gold; } }
        public int Status { get { return status; } }
        public ItemType Type { get { return type; } }

        public Item(string name, string comment, int gold, ItemType type, int status)
        {
            this.name = name;
            this.comment = comment;
            this.gold = gold;
            this.status = status;
            this.type = type;
        }

        public string GetItemInfo()
        {
            string itemTypeStr;
            if(type == ItemType.WEAPON)
                itemTypeStr = "공격력";
            else
                itemTypeStr = "방어력";

            return $"{name} / {itemTypeStr} +{status} / {comment}";
        }
    }
}
