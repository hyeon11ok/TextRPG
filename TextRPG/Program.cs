using static System.Formats.Asn1.AsnWriter;

namespace TextRPG
{
    public enum Scene
    {
        START = 0,
        STATUS,
        INVENTORY,
        SHOP,
        EQUIPMENT,
        BUY,
        REST,
        SELL,
        DUNGEON
    }

    public enum ItemType
    {
        WEAPON = 0,
        ARMOR
    }

    public enum ClassType
    {
        WARRIOR = 1,
        WIZARD,
        ARCHER,
        THIEF
    }

    public enum DungeonDifficulty
    {
        EASY,
        NORMAL,
        HARD
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager();

            sceneManager.ShowScene();
        }
    }
}