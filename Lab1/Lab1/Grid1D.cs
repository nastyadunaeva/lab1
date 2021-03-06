﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    struct Grid1D
    {
        public float step { get; set; }
        public int node { get; set; }
        public Grid1D(float first_step, int first_node)
        {
            step = first_step;
            node = first_node;
        }
        public override string ToString()
        {
            string tmp = "step: " + step.ToString() + " nodes: " + node.ToString();
            return tmp;
        }
    }
}
