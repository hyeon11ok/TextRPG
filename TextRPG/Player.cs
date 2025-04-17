using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Player
    {
        private int level; // 레벨
        private string name; // 이름
        private string charClass; // 캐릭터 직업
        private int atk; // 공격력
        private int def; // 방어력
        private int hp; // 체력
        private int gold; // 골드
        private int extraAtk;
        private int extraDef;

        public int Gold { get { return gold; } }

        public Player()
        {
            level = 1;
            name = "김봉방";
            charClass = "전사";
            atk = 10;
            def = 4;
            hp = 100;
            gold = 5000;
            extraAtk = 0;
            extraDef = 0;
        }

        public void CreateCharacter(string name, string charClass)
        {
            this.name = name;
            this.charClass = charClass;
        }

        // ShowStatus로 변경
        public void PrintStatus()
        {
            string e_atk = "";
            string e_def = "";
            if(extraAtk > 0)
            {
                e_atk = $"+ {extraAtk}";
            }
            if(extraDef > 0)
            {
                e_def = $"+ {extraDef}";
            }

            Console.WriteLine($"Lv. {level:00}");
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"직업 : ( {charClass} )");
            Console.WriteLine($"공격력 : {atk} {e_atk}");
            Console.WriteLine($"방어력 : {def} {e_def}");
            Console.WriteLine($"체력 : {hp}");
            Console.WriteLine($"골드 : {gold} G");
            Console.WriteLine();
        }

        public void UseGold(int pay)
        {
            gold -= pay;
        }

        public void SetExtraStatus(int e_atk, int e_def)
        {
            extraAtk = e_atk;
            extraDef = e_def;
        }

        public void Rest()
        {

        }
    }
}
