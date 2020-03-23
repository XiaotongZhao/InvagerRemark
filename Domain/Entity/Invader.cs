using Domain.Share;
using System.Drawing;

namespace Domain.Entity
{
    class Invader
    {
        private const int horizontalInterval = 10;
        private const int vericalInterval = 40;
        private Bitmap image;
        private Direction direction;
        public Point Location;
        public int Score { get; private set; }
        public ShipType InvaderType { get; private set; }
        public Direction Direction { get { return direction; } }
        public Rectangle Area
        {
            get
            {
                return new Rectangle(Location, image.Size);
            }
        }
        public Bitmap Image { set { this.image = value; } }

        public Invader(ShipType invaderType, Point location, int score, Bitmap image)
        {
            this.InvaderType = invaderType;
            this.Location = location;
            this.Score = score;
            this.image = image;
            this.direction = Direction.Left;
        }

        public void Move(Direction direction)
        {
            this.direction = direction;
            int y = this.Location.Y;
            int x = this.Location.X;
            switch (this.direction)
            {
                case Direction.Up:
                    y -= vericalInterval;
                    break;
                case Direction.Down:
                    y += vericalInterval;
                    break;
                case Direction.Left:
                    x -= horizontalInterval;
                    break;
                case Direction.Right:
                    x += horizontalInterval;
                    break;
            }
            this.Location.X = x;
            this.Location.Y = y;
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(this.image, this.Location);
        }

        public void ReturnFire()
        { }
    }
}
