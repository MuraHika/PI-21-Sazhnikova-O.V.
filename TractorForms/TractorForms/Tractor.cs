﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class Tractor : Vehicle, IComparable<Tractor>, IEquatable<Tractor>
    {
        protected const int tractorWidth = 60;
        protected const int tractorHeight = 200;

        public Tractor(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public Tractor(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
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

            //Кузов
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY - 15, 50, 20);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY - 15, 50, 20);
            g.FillRectangle(Kuzov, _startPosX - 50, _startPosY + 5, 60, 30);
            g.DrawRectangle(pen, _startPosX - 50, _startPosY + 5, 60, 30);
            //Стекло
            g.FillRectangle(Glass, _startPosX - 25, _startPosY - 12, 20, 17);
            g.DrawRectangle(pen, _startPosX - 25, _startPosY - 12, 20, 17);
            //Колеса
            g.FillEllipse(Wheels, _startPosX - 50, _startPosY + 10, 35, 35);
            g.FillEllipse(Wheels, _startPosX - 10, _startPosY + 20, 25, 25);
        }

        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }

        public int CompareTo(Tractor other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (MainColor != other.MainColor)
            {
                MainColor.Name.CompareTo(other.MainColor.Name);
            }
            return 0;
        }

        public bool Equals(Tractor other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
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
            Tractor tractorObj = obj as Tractor;
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