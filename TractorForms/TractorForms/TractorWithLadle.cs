using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    class TractorWithLadle : Tractor, IComparable<TractorWithLadle>, IEquatable<TractorWithLadle>
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

        public TractorWithLadle(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 6)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                GlassColor = Color.FromName(strs[4]);
                Crane = Convert.ToBoolean(strs[5]);
            }
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

        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + GlassColor.Name + ";" + Crane;
        }

        public int CompareTo(TractorWithLadle other)
        {
            var res = (this is Tractor).CompareTo(other is Tractor);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                DopColor.Name.CompareTo(other.DopColor.Name);
            }
            if (GlassColor != other.GlassColor)
            {
                GlassColor.Name.CompareTo(other.GlassColor.Name);
            }
            if (Crane != other.Crane)
            {
                return Crane.CompareTo(other.Crane);
            }
            return 0;
        }

        public bool Equals(TractorWithLadle other)
        {
            var res = (this is Tractor).Equals(other as Tractor);
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (GlassColor != other.GlassColor)
            {
                return false;
            }
            if (Crane != other.Crane)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            TractorWithLadle tractorObj = obj as TractorWithLadle;
            if (tractorObj == null)
            {
                return false;
            }
            else
            {
                return Equals(tractorObj);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
