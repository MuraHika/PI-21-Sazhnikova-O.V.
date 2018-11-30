using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public abstract class Vehicle : ITransport
    {
        protected float _startPosX;
        protected float _startPosY;
        protected int _screenWidth;
        protected int _screenHeight;
        public int MaxSpeed { protected set; get; }
        public float Weight { protected set; get; }
        public Color MainColor { protected set; get; }

        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _screenWidth = width;
            _screenHeight = height;
        }
        public void SetMainColor(Color color)
        {
            MainColor = color;
        }
        public abstract void DrawTractor(Graphics g);
        public abstract void MoveTransport(Direction direction);
    }
}
