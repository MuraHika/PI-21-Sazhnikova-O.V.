﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class GarageOverflowException : Exception
    {
        public GarageOverflowException() : base("В гараже нет свободных мест!") { }
    }
}
