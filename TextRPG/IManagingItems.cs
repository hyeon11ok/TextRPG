using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal interface IManagingItems
    {
        public void PrintItems();
        public void PrintItems(ref int idx);
    }
}
