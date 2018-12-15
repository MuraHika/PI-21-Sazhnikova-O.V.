using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class GarageOccupiedPlaceException : Exception
    {
        public GarageOccupiedPlaceException(int i) : base("На месте " + i + " уже стоит трактор") { }
    }
}
