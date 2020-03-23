using Domain.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Domain.Entity
{
    class Game
    {
        private int score;
        private int livesLeft;
        private int wave;
        private int framesSkipped;
        private Bitmap[,] bitmaps;
        public Game(Bitmap[,] bitmaps)
        {
            score = 0;
            livesLeft = 2;
            wave = 0;
            framesSkipped = 0;
            this.bitmaps = bitmaps;
            this.CreateInvaders();
        }


        private Random random;
        private Rectangle boundaries;

        private Direction invaderDirection;
        private List<Invader> invaders;

        private void CreateInvaders()
        {
            this.invaders = new List<Invader>();
            for (int i = 0; i < 6; i++)
            {
                HpShipType hpShipType = HpShipType.Bug;
                ShipType shipType = (ShipType)i;
                switch (shipType)
                {
                    case ShipType.Bug:
                        hpShipType = HpShipType.Bug;
                        break;
                    case ShipType.FlyingSaucer:
                        hpShipType = HpShipType.FlyingSaucer;
                        break;
                    case ShipType.SateLlite:
                        hpShipType = HpShipType.SateLlite;
                        break;
                    case ShipType.SpaceShip:
                        hpShipType = HpShipType.SpaceShip;
                        break;
                    case ShipType.Star:
                        hpShipType = HpShipType.Star;
                        break;
                    case ShipType.Watchit:
                        hpShipType = HpShipType.Watchit;
                        break;
                }
                for (int j = 0; j < 5; j++)
                {
                    this.invaders.Add(new Invader(shipType, new Point(100 * (i + 1), 100 + (j + 1) * 70), (int)hpShipType, this.bitmaps[(int)shipType, 0]));
                }
            }
        }


        public void MoveInvader()
        {
            var invaderNearLeftBoundary = invaders.First();
            if (invaderNearLeftBoundary.Direction == Direction.Left)
            {
                foreach (var invader in invaders)
                {
                    invader.Move(Direction.Left);
                    if (invaderNearLeftBoundary.Location.X == 10)
                        invader.Move(Direction.Down);
                }
            }

            if (invaderNearLeftBoundary.Direction == Direction.Down)
            {
                foreach (var invader in invaders)
                {
                    invader.Move(Direction.Right);
                }
            }

            if (invaderNearLeftBoundary.Direction == Direction.Right)
            {
                foreach (var invader in invaders)
                {
                    invader.Move(Direction.Right);
                    if (invaderNearLeftBoundary.Location.X == 800)
                        invader.Move(Direction.Up);
                }
            }

            if (invaderNearLeftBoundary.Direction == Direction.Up)
            {
                foreach (var invader in invaders)
                {
                    invader.Move(Direction.Left);
                }
            }
        }



        public void Draw(Graphics g, int animationCell)
        {
            foreach (var invader in this.invaders)
            {
                invader.Image = this.bitmaps[(int)invader.InvaderType, animationCell];
                invader.Draw(g);
            }
        }

        public void Twinkle()
        {
        }

        public void MovePlayer()
        { }

        public void FireShot()
        { }

        public void Go()
        {
            MoveInvader();
        }


    }
}
