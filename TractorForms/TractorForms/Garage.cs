using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class Garage<T> where T : class, ITransport
    {
        private T[] _places;
        private int ScreenWidth { get; set; }
        private int ScreenHeigth { get; set; }
        private int _placeSizeWidth = 250;
        private int _placeSizeHeight = 80;

        public Garage(int sizes, int screenWidth, int screenHeigth)
        {
            _places = new T[sizes];
            ScreenWidth = screenWidth;
            ScreenHeigth = screenHeigth;
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i] = null;
            }
        }

        public static int operator +(Garage<T> p, T tractor)
        {
            for (int i = 0; i < p._places.Length; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places[i] = tractor;
                    p._places[i].SetPosition(5 + i / 5 * p._placeSizeWidth + 5 + 50, i % 5 * p._placeSizeHeight + 35, p.ScreenWidth, p.ScreenHeigth);
                    return i;
                }
            }
            return -1;
        }

        public static T operator -(Garage<T> p, int index)
        {
            if (index < 0 || index > p._places.Length)
            {
                return null;
            }
            if (!p.CheckFreePlace(index))
            {
                T tractor = p._places[index];
                p._places[index] = null;
                return tractor;
            }
            return null;
        }

        private bool CheckFreePlace(int index)
        {
            return _places[index] == null;
        }

        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
            {
                if (!CheckFreePlace(i))
                {
                    _places[i].DrawTractor(g);
                }
            }
        }

        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawRectangle(pen, 0, 0, ScreenWidth, ScreenHeigth);

            for (int i = 0; i < _places.Length / 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + 110, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, ScreenHeigth);
            }
        }
    }
}
