using System;

namespace DesignPattern
{
    internal class StatePattern
    {
        internal void Main()
        {
            var player = new Player();
            player.SetState(new PlayState());
            player.PressPlay();
            player.PressPlay();
            player.PressPlay();
            player.PressPlay();
        }

        public interface IState
        {
            void PressPlay(Player player);
        }

        public class Player
        {
            private IState state;
            public void SetState(IState state)
            {
                this.state = state;
            }
            public void PressPlay()
            {
                state.PressPlay(this);
            }
        }

        public class PlayState : IState
        {
            public void PressPlay(Player player)
            {
                Console.WriteLine("Play music.");
                player.SetState(new PauseState());
            }
        }

        public class PauseState : IState
        {
            public void PressPlay(Player player)
            {
                Console.WriteLine("Pause music.");
                player.SetState(new PlayState());
            }
        }
    }
}