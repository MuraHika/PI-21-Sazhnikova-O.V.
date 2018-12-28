using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class Garage<T> : IEnumerator<T>, IEnumerable<T>, IComparable<Garage<T>> where T : class, ITransport
    {
        private Dictionary<int, T> _places;
        private int _maxCount;
        private int ScreenWidth { get; set; }
        private int ScreenHeigth { get; set; }
        private int _placeSizeWidth = 250;
        private int _placeSizeHeight = 80;
        private int _currentIndex;

        public int GetKey
        {
            get
            {
                return _places.Keys.ToList()[_currentIndex];
            }
        }

        public Garage(int sizes, int screenWidth, int screenHeigth)
        {
            _maxCount = sizes;
            _places = new Dictionary<int, T>();
            _currentIndex = -1;
            ScreenWidth = screenWidth;
            ScreenHeigth = screenHeigth;
        }

        public static int operator +(Garage<T> p, T tractor)
        {
            if (p._places.Count == p._maxCount)
            {
                throw new GarageOverflowException();
            }
            if (p._places.ContainsValue(tractor))
            {
                throw new GarageAlreadyHaveException();
            }
            for (int i = 0; i < p._maxCount; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places.Add(i, tractor);
                    p._places[i].SetPosition(5 + i / 5 * p._placeSizeWidth + 5 + 50, i % 5 * p._placeSizeHeight + 35, p.ScreenWidth, p.ScreenHeigth);
                    return i;
                }
            }
            return -1;
        }

        public static T operator -(Garage<T> p, int index)
        {
            if (!p.CheckFreePlace(index))
            {
                T tractor = p._places[index];
                p._places.Remove(index);
                return tractor;
            }
            throw new GarageNotFoundException(index);
        }

        private bool CheckFreePlace(int index)
        {
            return !_places.ContainsKey(index);
        }

        public void Draw(Graphics g)
        {
            DrawMarking(g);
            foreach (var tractor in _places)
            {
                tractor.Value.DrawTractor(g);
            }
        }

        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawRectangle(pen, 0, 0, (_maxCount / 5) * _placeSizeWidth, 480);

            for (int i = 0; i < _maxCount / 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + 110, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 480);
            }
        }

        public T this[int ind]
        {
            get
            {
                if (_places.ContainsKey(ind))
                {
                    return _places[ind];
                }
                throw new GarageNotFoundException(ind);
            }
            set
            {
                if (CheckFreePlace(ind))
                {
                    _places.Add(ind, value);
                    _places[ind].SetPosition(5 + ind / 5 * _placeSizeWidth + 50, ind % 5 * _placeSizeHeight + 33, ScreenWidth, ScreenHeigth);

                }
                else
                {
                    throw new GarageOccupiedPlaceException(ind);
                }
            }
        }

        public T Current
        {
            get
            {
                return _places[_places.Keys.ToList()[_currentIndex]];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            _places.Clear();
        }

        public bool MoveNext()
        {
            if (_currentIndex + 1 >= _places.Count)
            {
                Reset();
                return false;
            }
            _currentIndex++;
            return true;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(Garage<T> other)
        {
            if (_places.Count > other._places.Count)
            {
                return -1;
            }
            else if (_places.Count < other._places.Count)
            {
                return 1;
            }
            else if (_places.Count > 0)
            {
                var thisKeys = _places.Keys.ToList();
                var otherKeys = other._places.Keys.ToList();
                for (int i = 0; i < _places.Count; ++i)
                {
                    if (_places[thisKeys[i]] is Tractor && other._places[thisKeys[i]] is
                   TractorWithLadle)
                    {
                        return 1;
                    }
                    if (_places[thisKeys[i]] is TractorWithLadle && other._places[thisKeys[i]] is
                    Tractor)
                    {
                        return -1;
                    }
                    if (_places[thisKeys[i]] is Tractor && other._places[thisKeys[i]] is Tractor)
                    {
                        return (_places[thisKeys[i]] is
                       Tractor).CompareTo(other._places[thisKeys[i]] is Tractor);
                    }
                    if (_places[thisKeys[i]] is TractorWithLadle && other._places[thisKeys[i]] is
                    TractorWithLadle)
                    {
                        return (_places[thisKeys[i]] is
                       TractorWithLadle).CompareTo(other._places[thisKeys[i]] is TractorWithLadle);
                    }
                }
            }
            return 0;
        }
    }
}
