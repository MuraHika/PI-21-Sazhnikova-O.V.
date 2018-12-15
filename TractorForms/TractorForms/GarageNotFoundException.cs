using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class GarageNotFoundException : Exception
    {
        public GarageNotFoundException(int i) : base("Не найден трактор по месту " + i) { }
    }
}
