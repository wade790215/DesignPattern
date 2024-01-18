using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class DIP
    {
        public void Main()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetPlayer(new Spotify());
            musicPlayer.Play(); 
        }
    }

    public class MusicPlayer
    {
        private IGetPlayer player;

        public void SetPlayer(IGetPlayer player)
        {
            this.player = player;
        }

        public void Play()
        {
            Console.WriteLine(player.GetPlayer());
        }
    }

    public class KKBOX :　IGetPlayer
    {
        public string GetPlayer()
        {
            return $"正在使用{GetType().Name}撥放音樂";
        }
    }

    public class Spotify : IGetPlayer
    {
        public string GetPlayer()
        {
            return $"正在使用{GetType().Name}撥放音樂";
        }
    }

    public interface IGetPlayer
    {
        string GetPlayer();
    }
}
