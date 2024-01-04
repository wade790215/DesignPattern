using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern
{
    internal class MementoPattern
    {
        internal void Main()
        {
            ////存檔
            //var player = new Player();
            //var gameSaveManagement = new GameSaveManagement();
            //gameSaveManagement.Memento = player.SaveState();
            //player.ShowState(); 

            ////打Boss
            //player.AttackBoss();

            ////讀檔
            //player.RestoreState(gameSaveManagement.Memento);

            History history = new History();
            TextEditor textEditor = new TextEditor();
            textEditor.SetText("Hello World");
            var hello = textEditor.CreateState();
            history.Push(hello); 

            textEditor.SetText("Test");
            var test = textEditor.CreateState();
            history.Push(test);

            textEditor.SetText("Test2");
            var test2 = textEditor.CreateState();
            history.Push(test2);

            Console.WriteLine(history.Pop().GetText());
            Console.WriteLine(history.Pop().GetText());
            Console.WriteLine(history.Pop().GetText());
            Console.ReadLine(); 
        }
    }

    #region Pratice2

    public class TextEditor
    {
        private string text;

        public void SetText(string text)
        {
            this.text = text;
        }
        public string GetText()
        {
            return text;
        }

        public EditorState CreateState()
        {
            return new EditorState(text);
        }

        public void RestoreState(EditorState state)
        {
            text = state.GetText();
        }
    }

    public class EditorState
    {
        private string text;

        public EditorState(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return text;
        }
    }

    public class History
    {
        private Stack<EditorState> states = new Stack<EditorState>();

        public void Push(EditorState state)
        {
            states.Push(state);
        }

        public EditorState Pop()
        {
            if (states.Count > 0)
            {
                return states.Pop();
            }
            return null;
        }
    }

    #endregion

    #region Practice1
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
    #endregion
}