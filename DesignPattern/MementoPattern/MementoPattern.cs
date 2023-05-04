using System;

namespace DesignPattern
{
    internal class MementoPattern
    {
        internal void Main()
        {
            //存檔
            var player = new Player();
            var gameSaveManagement = new GameSaveManagement();
            gameSaveManagement.Memento = player.SaveState();
            player.ShowState(); 

            //打Boss
            player.AttackBoss();

            //讀檔
            player.RestoreState(gameSaveManagement.Memento);
        }
    }

    internal class GameSaveManagement
    {
        private PlayerStateMemento memento;

        public PlayerStateMemento Memento { get => memento; set => memento = value; }
    }

    internal class PlayerStateMemento
    {
        private int atk;
        private int def;
        private int hp;

        public PlayerStateMemento(int atk, int def, int hp)
        {
            this.atk = atk;
            this.hp = hp;
            this.def = def;
        }

        public int Hp { get => hp; set => hp = value; }
        public int Def { get => def; set => def = value; }
        public int Atk { get => atk; set => atk = value; }
    }

    internal class Player
    {
        private int atk = 10;
        private int def = 5;
        private int hp = 100;

        public Player()
        {
        }

        internal PlayerStateMemento SaveState()
        {
            return new PlayerStateMemento(atk, def, hp);
        }

        internal void RestoreState(PlayerStateMemento playerStateMemento)
        {
            atk = playerStateMemento.Atk;
            def = playerStateMemento.Def;
            hp = playerStateMemento.Hp;
            Console.WriteLine($"覺得打得不好，決定讀檔重打");
            ShowState();
        }

        public void AttackBoss()
        {
            atk= 7;
            def= 3;
            hp = 50;
            Console.WriteLine($"打完Boss");
            ShowState();
        }

        public void ShowState()
        {
            Console.WriteLine($"目前攻擊力{atk}，防禦力{def}，血量{hp}");
        }
    }
}