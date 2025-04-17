﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class SceneManager
    {
        private Scene curScene;
        private Player player;
        private Inventory inventory;
        private Shop shop;

        public SceneManager()
        {
            curScene = Scene.START;
            player = new Player();
            inventory = new Inventory();
            shop = new Shop();
        }

        public void GameStart()
        {
            string name = InputName();
            string classStr = ChooseClass();

            player.CreateCharacter(name, classStr);
        }

        public void ShowScene()
        {
            bool isPlaying = true;

            GameStart();

            while(isPlaying)
            {
                switch(curScene)
                {
                    case Scene.START:
                        StartScene(ref isPlaying);
                        break;
                    case Scene.STATUS:
                        StatusScene();
                        break;
                    case Scene.INVENTORY:
                        InventoryScene();
                        break;
                    case Scene.SHOP:
                        ShopScene();
                        break;
                    case Scene.EQUIPMENT:
                        EquipmentScene();
                        break;
                    case Scene.BUY:
                        BuyScene();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("게임 종료");
        }

        int ChooseAction(int min, int max)
        {
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            string? action = Console.ReadLine();
            Console.Clear();

            int actionNum;
            bool isInt = int.TryParse(action, out actionNum);

            if(isInt && min <= actionNum && actionNum <= max)
            {
                return actionNum;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine();
                return -1;
            }
        }

        string InputName()
        {
            bool confirm = false;
            string? name;

            do
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.Write("이름을 알려주세요 : ");
                name = Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"이름이 {name}, 맞나요?");
                Console.WriteLine("1. 네");
                Console.WriteLine("2. 아니요");
                Console.WriteLine();

                int select = ChooseAction(1, 2);
                if(select == 1) confirm = true;
            } while(!confirm);

            return name;
        }

        string ChooseClass()
        {
            bool confirm = false;
            string classStr;

            do
            {
                Console.WriteLine($"직업을 선택해 주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine("3. 궁수");
                Console.WriteLine("4. 도적");
                Console.WriteLine();

                int select = ChooseAction(1, 4);
                switch((ClassType)select)
                {
                    case ClassType.WARRIOR:
                        classStr = "전사";
                        break;
                    case ClassType.WIZARD:
                        classStr = "마법사";
                        break;
                    case ClassType.ARCHER:
                        classStr = "궁수";
                        break;
                    case ClassType.THIEF:
                        classStr = "도적";
                        break;
                    default:
                        classStr = "";
                        break;
                }

                Console.WriteLine($"직업이 {classStr}, 맞나요?");
                Console.WriteLine("1. 네");
                Console.WriteLine("2. 아니요");
                Console.WriteLine();

                select = ChooseAction(1, 2);
                if(select == 1) confirm = true;
            } while(!confirm);

            return classStr;
        }

        void StartScene(ref bool isPlaying)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("0. 게임 종료");
            Console.WriteLine();

            int choice = ChooseAction(0, 3);
            switch(choice)
            {
                case 0:
                    isPlaying = false;
                    break;
                case 1:
                    curScene = Scene.STATUS;
                    break;
                case 2:
                    curScene = Scene.INVENTORY;
                    break;
                case 3:
                    curScene = Scene.SHOP;
                    break;
                default:
                    break;
            }
        }

        void StatusScene()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            player.PrintStatus();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int choice = ChooseAction(0, 0);
            switch(choice)
            {
                case 0:
                    curScene = Scene.START;
                    break;
                default:
                    break;
            }
        }

        void InventoryScene()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            inventory.ShowItems();
            Console.WriteLine();

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int choice = ChooseAction(0, 1);
            switch(choice)
            {
                case 0:
                    curScene = Scene.START;
                    break;
                case 1:
                    curScene = Scene.EQUIPMENT;
                    break;
                default:
                    break;
            }
        }

        void ShopScene()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            shop.ShowItems();
            Console.WriteLine();

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();


            int choice = ChooseAction(0, 1);
            switch(choice)
            {
                case 0:
                    curScene = Scene.START;
                    break;
                case 1:
                    curScene = Scene.BUY;
                    break;
                default:
                    break;
            }
        }

        void EquipmentScene()
        {
            int cnt = 0;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            inventory.ShowItems(ref cnt);
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int choice = ChooseAction(0, cnt);
            switch(choice)
            {
                case 0:
                    curScene = Scene.START;
                    break;
                case -1:
                    break;
                default:
                    inventory.ChangeEquipState(choice);
                    inventory.UpdateExtraStatus(player);
                    break;
            }
        }

        void BuyScene()
        {
            int cnt = 0;
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            shop.ShowItems(ref cnt);
            Console.WriteLine();

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int choice = ChooseAction(0, cnt);
            switch(choice)
            {
                case 0:
                    curScene = Scene.START;
                    break;
                case -1:
                    break;
                default:
                    shop.BuyItem(choice, player, inventory);
                    break;
            }
        }
    }
}
