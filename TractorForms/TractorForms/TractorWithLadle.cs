using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    class TractorWithLadle : Tractor
    {
        public Color DopColor { private set; get; }
        public Color GlassColor { private set; get; }
        public bool Crane { private set; get; }
        public TractorWithLadle(int maxSpeed, int weight, Color mainColor, Color dopColor, Color glassColor, bool crane)
            : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            GlassColor = glassColor;
            Crane = crane;
        }

        public override void DrawTractor(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush Kuzov = new SolidBrush(MainColor);
            Brush Wheels = new SolidBrush(DopColor);
            Brush Glass = new SolidBrush(GlassColor);
            if (Crane)
            {
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
            }
            //Труба
            g.FillRectangle(Kuzov, _startPosX, _startPosY, 6, 10);
            g.DrawRectangle(pen, _startPosX, _startPosY, 6, 10);

            //Кузов
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY - 30, 50, 30);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY - 30, 50, 30);
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY, 75, 40);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY, 75, 40);
            //Ковш
            g.FillRectangle(Kuzov, _startPosX + 25, _startPosY + 20, 6, 10);
            g.DrawRectangle(pen, _startPosX + 25, _startPosY + 20, 6, 10);
            g.DrawPolygon(pen, new PointF[] { new PointF(_startPosX + 30, _startPosY - 20), new PointF(_startPosX + 30, _startPosY + 50), new PointF(_startPosX + 90, _startPosY + 50) });
            g.FillPolygon(Wheels, new PointF[] { new PointF(_startPosX + 30, _startPosY - 20), new PointF(_startPosX + 30, _startPosY + 50), new PointF(_startPosX + 90, _startPosY + 50) });
            //Стекло
            g.FillRectangle(Glass, _startPosX - 25, _startPosY - 25, 20, 25);
            g.DrawRectangle(pen, _startPosX - 25, _startPosY - 25, 20, 25);
            //Колеса
            g.FillEllipse(Wheels, _startPosX - 50, _startPosY + 10, 40, 40);
            g.FillEllipse(Wheels, _startPosX + 5, _startPosY + 30, 20, 20);

        }

    }
}
