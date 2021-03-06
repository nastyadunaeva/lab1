﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    struct DataItem
    {
        public double field { get; set; }
        public System.Numerics.Vector2 Vec { get; set; }
        public DataItem(System.Numerics.Vector2 vector2, double f)
        {
            Vec = vector2;
            field = f;
        }
        public override string ToString()
        {
            string tmp = field.ToString() + " " + Vec.ToString();
            return tmp;
        }
    }
}
