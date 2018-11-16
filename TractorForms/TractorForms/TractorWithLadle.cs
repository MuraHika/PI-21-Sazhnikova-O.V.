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
                g.DrawRectangle(pen, _startPosX - 50, _startPosY - 30, 3, 30);
                g.FillRectangle(Kuzov, _startPosX - 50, _startPosY - 30, 3, 30);
                g.DrawRectangle(pen, _startPosX - 47, _startPosY - 30, 50, 3);
                g.FillRectangle(Kuzov, _startPosX - 47, _startPosY - 30, 50, 3);
                g.DrawRectangle(pen, _startPosX, _startPosY - 30, 3, 10);
                g.FillRectangle(Kuzov, _startPosX, _startPosY - 30, 3, 10);
                //Крюк
                g.DrawRectangle(pen, _startPosX + 1, _startPosY - 20, 1, 5);
                g.DrawRectangle(pen, _startPosX + 1, _startPosY - 15, 7, 1);
                g.DrawRectangle(pen, _startPosX + 8, _startPosY - 20, 1, 5);
            }
            //Труба
            g.FillRectangle(Kuzov, _startPosX + 10, _startPosY + 10, 6, 10);
            g.DrawRectangle(pen, _startPosX + 10, _startPosY + 10, 6, 10);

            //Кузов
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY - 15, 50, 20);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY - 15, 50, 20);
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY + 5, 60, 30);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY + 5, 60, 30);
            //Ковш
            g.FillRectangle(Kuzov, _startPosX + 25, _startPosY + 20, 6, 10);
            g.DrawRectangle(pen, _startPosX + 25, _startPosY + 20, 6, 10);
            g.DrawPolygon(pen, new PointF[] { new PointF(_startPosX + 15, _startPosY - 12), new PointF(_startPosX + 15, _startPosY + 38), new PointF(_startPosX + 60, _startPosY + 38) });
            g.FillPolygon(Wheels, new PointF[] { new PointF(_startPosX + 15, _startPosY - 12), new PointF(_startPosX + 15, _startPosY + 38), new PointF(_startPosX + 60, _startPosY + 38) });
            //Стекло
            g.FillRectangle(Glass, _startPosX - 25, _startPosY - 12, 20, 17);
            g.DrawRectangle(pen, _startPosX - 25, _startPosY - 12, 20, 17);
            //Колеса
            g.FillEllipse(Wheels, _startPosX - 50, _startPosY + 10, 35, 35);
            g.FillEllipse(Wheels, _startPosX - 10, _startPosY + 20, 25, 25);
        }

    }
}
