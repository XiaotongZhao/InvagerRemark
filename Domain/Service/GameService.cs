using Domain.Entity;
using System;
using System.Drawing;

namespace Domain.Service
{
    public class GameService : IGameService
    {
        private Game game { get; set; }

        public GameService(Bitmap[,] bitmaps)
        {
            game = new Game(bitmaps);
        }

        public void DrawService(Graphics g, int animationCell)
        {
            game.Draw(g, animationCell);
        }

        public void GoService()
        {
            game.Go();
        }
    }
}
