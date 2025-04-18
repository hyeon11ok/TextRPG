using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class DungeonData
    {
        private DungeonDifficulty difficulty;
        private int suggestDef;
        private int reward;
        private string name;

        public DungeonDifficulty DungeonDifficulty { get { return difficulty; } }
        public int SuggestDef { get {  return suggestDef; } }
        public int Reward { get {  return reward; } }
        public string Name { get { return name; } }

        public void Setting(DungeonDifficulty difficulty, int suggest, int reward, string name)
        {
            this.difficulty = difficulty;
            this.suggestDef = suggest;
            this.reward = reward;
            this.name = name;
        }

        public bool ClearCheck(int def)
        {
            if(def < suggestDef)
            {
                Random random = new Random();
                int randomInt = random.Next(0, 100);
                if(randomInt <= 40)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public int GetDamage(bool isClear, int def)
        {
            if (isClear)
            {
                int minDmg = 20 + (def - suggestDef);
                int maxDmg = 35 + (def - suggestDef);
                Random random = new Random();

                return random.Next(minDmg, maxDmg);
            }
            else
            {
                return 50;
            }
        }

        public int GetReward(bool isClear, int atk)
        {
            if (isClear)
            {
                int minBonus = atk;
                int maxBonus = atk * 2;
                Random random = new Random();
                int bonus = reward * random.Next(minBonus, maxBonus) / 100;

                return reward + bonus;
            }
            else
            {
                return 0;
            }
        }
    }

    internal class Dungeon
    {
        private DungeonData[] dungeons;

        public int DungeonCnt { get { return dungeons.Length; } }

        public Dungeon() 
        {
            dungeons = new DungeonData[3];
            dungeons[(int)DungeonDifficulty.EASY].Setting(DungeonDifficulty.EASY, 5, 1000, "쉬운 던전");
            dungeons[(int)DungeonDifficulty.NORMAL].Setting(DungeonDifficulty.NORMAL, 11, 1700, "일반 던전");
            dungeons[(int)DungeonDifficulty.HARD].Setting(DungeonDifficulty.HARD, 17, 2500, "어려운 던전");
        }

        public void ShowDungeonList()
        {
            for (int i = 0; i < dungeons.Length; i++)
            {
                Console.WriteLine($"{i}. {dungeons[i].Name} | 방어력 {dungeons[i].SuggestDef} 이상 권장");
            }
        }

        public void EnterDungeon(int idx, Player player)
        {
            bool isClear = dungeons[idx].ClearCheck(player.Def);
            int damage = dungeons[idx].GetDamage(isClear, player.Def);
            int reward = dungeons[idx].GetReward(isClear, player.Atk);

            player.HpChange(damage);
            player.UseGold(-reward);
        }
    }
}
