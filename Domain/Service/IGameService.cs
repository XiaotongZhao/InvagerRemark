using System.Drawing;

namespace Domain.Service
{
    public interface IGameService
    {
        void DrawService(Graphics g, int animationCell);
        void GoService();
    }
}
