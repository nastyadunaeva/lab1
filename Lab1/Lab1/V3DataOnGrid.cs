using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace Lab1
{
    class V3DataOnGrid : V3Data
    {
        public Grid1D x { get; set; }
        public Grid1D y { get; set; }
        public double[,] value { get; set; }
        public V3DataOnGrid() { }
        public V3DataOnGrid(string constr_information, DateTime constr_time, Grid1D x0, Grid1D y0) : base(constr_information, constr_time)
        {
            x = x0;
            y = y0;
            value = new double[x.node, y.node];
        }
        public void InitRandom(double minValue, double maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < x.node; i++)
            {
                for (int j = 0; j < y.node; j++)
                {
                    value[i, j] = minValue + rnd.NextDouble() * (maxValue - minValue);
                }
            }
        }
        public static explicit operator V3DataCollection(V3DataOnGrid v3DtOnGrid)
        {
            V3DataCollection ret = new V3DataCollection(v3DtOnGrid.information, v3DtOnGrid.time);
            List<DataItem> ins = new List<DataItem>();
            for (int i = 0; i < v3DtOnGrid.x.node; i++)
            {
                for (int j = 0; j < v3DtOnGrid.y.node; j++)
                {
                    Vector2 v2 = new Vector2(i * v3DtOnGrid.x.step, j * v3DtOnGrid.y.step);
                    double field = v3DtOnGrid.value[i, j];
                    DataItem di = new DataItem(v2, field);
                    ins.Add(di);
                }
            }
            ret.dataItems = ins;
            return ret;
        }
        public override Vector2[] Nearest(Vector2 dot)
        {
            List<Vector2> ans = new List<Vector2>();
            double minDist = 0.0;
            for (int i = 0; i < x.node; i++)
            {
                for (int j = 0; j < y.node; j++)
                {
                    Vector2 cur = new Vector2(i * x.step, j * y.step);
                    double cur_dist = Vector2.Distance(cur, dot);
                    if ((i == 0) && (j == 0))
                    {
                        minDist = cur_dist;
                        ans.Add(cur);
                    }
                    else
                    {
                        if (cur_dist < minDist)
                        {
                            ans.Clear();
                            minDist = cur_dist;
                            ans.Add(cur);
                        }
                        else if (cur_dist == minDist)
                        {
                            ans.Add(cur);
                        }
                    }
                }
            }
            return ans.ToArray();
        }
        public override string ToString()
        {
            return "V3DataOnGrid " + base.ToString() + " x axis " + x.ToString() + ", y axis " + y.ToString() + "\n";
        }
        public override string ToLongString()
        {
            string tmp = "";
            tmp = tmp + this.ToString() + " ";
            for (int i = 0; i < x.node; i++)
            {
                for (int j = 0; j < y.node; j++)
                {
                    tmp = tmp + "x = " + (i * x.step).ToString() + " y = " + (j * y.step).ToString() + " value = " + value[i, j].ToString() + "\n";
                }
            }
            return tmp;
        }
    }
}
