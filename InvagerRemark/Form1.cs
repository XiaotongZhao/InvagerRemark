using Domain.Service;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InvagerRemark
{
    public partial class Form1 : Form
    {
        Bitmap[,] images;
        private int animationCell = 0;
        private int frame = 0;
        private IGameService IGameService;
        public void Animate()
        {
            frame++;
            if (frame >= 6)
                frame = 0;
            switch (frame)
            {
                case 0:
                    animationCell = 0;
                    break;
                case 1:
                    animationCell = 1;
                    break;
                case 2:
                    animationCell = 2;
                    break;
                case 3:
                    animationCell = 3;
                    break;
                case 4:
                    animationCell = 2;
                    break;
                case 5:
                    animationCell = 1;
                    break;
                default:
                    animationCell = 0;
                    break;
            }
            this.Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
            this.InitializeImage();
        }

        public void InitializeImage()
        {
            this.images = new Bitmap[7, 4];
            this.images[0, 0] = ResizeImage(Properties.Resources.bug1, 50, 50);
            this.images[0, 1] = ResizeImage(Properties.Resources.bug2, 50, 50);
            this.images[0, 2] = ResizeImage(Properties.Resources.bug3, 50, 50);
            this.images[0, 3] = ResizeImage(Properties.Resources.bug4, 50, 50);
            this.images[1, 0] = ResizeImage(Properties.Resources.flyingsaucer1, 50, 50);
            this.images[1, 1] = ResizeImage(Properties.Resources.flyingsaucer2, 50, 50);
            this.images[1, 2] = ResizeImage(Properties.Resources.flyingsaucer3, 50, 50);
            this.images[1, 3] = ResizeImage(Properties.Resources.flyingsaucer4, 50, 50);
            this.images[2, 0] = ResizeImage(Properties.Resources.satellite1, 50, 50);
            this.images[2, 1] = ResizeImage(Properties.Resources.satellite2, 50, 50);
            this.images[2, 2] = ResizeImage(Properties.Resources.satellite3, 50, 50);
            this.images[2, 3] = ResizeImage(Properties.Resources.satellite4, 50, 50);
            this.images[3, 0] = ResizeImage(Properties.Resources.spaceship1, 50, 50);
            this.images[3, 1] = ResizeImage(Properties.Resources.spaceship2, 50, 50);
            this.images[3, 2] = ResizeImage(Properties.Resources.spaceship3, 50, 50);
            this.images[3, 3] = ResizeImage(Properties.Resources.spaceship4, 50, 50);
            this.images[4, 0] = ResizeImage(Properties.Resources.star1, 50, 50);
            this.images[4, 1] = ResizeImage(Properties.Resources.star2, 50, 50);
            this.images[4, 2] = ResizeImage(Properties.Resources.star3, 50, 50);
            this.images[4, 3] = ResizeImage(Properties.Resources.star4, 50, 50);
            this.images[5, 0] = ResizeImage(Properties.Resources.watchit1, 50, 50);
            this.images[5, 1] = ResizeImage(Properties.Resources.watchit2, 50, 50);
            this.images[5, 2] = ResizeImage(Properties.Resources.watchit3, 50, 50);
            this.images[5, 3] = ResizeImage(Properties.Resources.watchit4, 50, 50);
            this.images[6, 0] = ResizeImage(Properties.Resources.player, 50, 50);
            this.IGameService = new GameService(this.images);
        }


        public Bitmap ResizeImage(Image imageToResize, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(imageToResize, 0, 0, width, height);
            }
            return bitmap;
        }


        private void Refresh(object sender, EventArgs e)
        {
            Animate();
            this.IGameService.GoService();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.IGameService.DrawService(g, animationCell);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }
    }
}
