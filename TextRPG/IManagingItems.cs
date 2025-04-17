using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal interface IManagingItems
    {
        public void ShowItems();
        public void ShowItems(ref int idx);
    }
}
