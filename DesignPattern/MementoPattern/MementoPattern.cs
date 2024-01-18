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
            Console.WriteLine(textEditor.GetText());
            textEditor.SetText("Test");
            var test = textEditor.CreateState();
            history.Push(test);
            Console.WriteLine(textEditor.GetText());
            textEditor.SetText("Test2");
            var test2 = textEditor.CreateState();
            history.Push(test2);
            Console.WriteLine(textEditor.GetText());

            textEditor.RestoreState(history.Pop());  
            textEditor.RestoreState(history.Pop());  
            textEditor.RestoreState(history.Pop());
            Console.WriteLine(textEditor.GetText());
            Console.ReadLine(); 
        }
    }

    #region Pratice2

    //管理者不與發起者直接溝通，避免發起者直接存取管理者

    //發起者(Originator) 負責儲存狀態
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

    //備忘錄(Memento) 負責儲存狀態，僅提供給發起者存取
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

    //管理者(Caretaker) 只負責管理狀態並提供狀態恢復功能
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