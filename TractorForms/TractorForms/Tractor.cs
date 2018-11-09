using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class Tractor : Vehicle
    {
        protected const int tractorWidth = 60;
        protected const int tractorHeight = 200;

        public Tractor(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _screenWidth - tractorWidth / 2)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > tractorWidth / 2)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > tractorHeight / 2)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _screenHeight - tractorHeight / 2)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override void DrawTractor(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush Kuzov = new SolidBrush(MainColor);
            Brush Wheels = new SolidBrush(Color.Black);
            Brush Glass = new SolidBrush(Color.Blue);

            //Кран
            g.DrawRectangle(pen, _startPosX - 50, _startPosY - 50, 5, 50);
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY - 50, 5, 50);
            g.DrawRectangle(pen, _startPosX - 45, _startPosY - 50, 60, 5);
            g.FillRectangle(Kuzov, _startPosX - 45, _startPosY - 50, 60, 5);
            g.DrawRectangle(pen, _startPosX + 15, _startPosY - 50, 5, 20);
            g.FillRectangle(Kuzov, _startPosX + 15, _startPosY - 50, 5, 20);
            //Крюк
            g.DrawRectangle(pen, _startPosX + 17, _startPosY - 30, 1, 5);
            g.DrawRectangle(pen, _startPosX + 11, _startPosY - 25, 7, 1);
            g.DrawRectangle(pen, _startPosX + 11, _startPosY - 30, 1, 5);

            //Кузов
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY - 30, 50, 30);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY - 30, 50, 30);
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY, 75, 40);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY, 75, 40);
            //Стекло
            g.FillRectangle(Glass, _startPosX - 25, _startPosY - 25, 20, 25);
            g.DrawRectangle(pen, _startPosX - 25, _startPosY - 25, 20, 25);
            //Колеса
            g.FillEllipse(Wheels, _startPosX - 50, _startPosY + 10, 40, 40);
            g.FillEllipse(Wheels, _startPosX + 5, _startPosY + 30, 20, 20);

        }
    }
}