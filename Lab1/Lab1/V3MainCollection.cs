using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace Lab1
{
    class V3MainCollection : IEnumerable<V3Data>
    {
        private List<V3Data> v3Datas;
        public V3MainCollection()
        {
            v3Datas = new List<V3Data>();
        }
        public int Count => v3Datas.Count;
        public IEnumerator<V3Data> GetEnumerator()
        {
            return v3Datas.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return v3Datas.GetEnumerator();
        }

        public void Add(V3Data item)
        {
            v3Datas.Add(item);
        }
        public bool Remove(string id, DateTime dt)
        {
            int amount = v3Datas.RemoveAll(x => ((x.information == id) && (x.time == dt)));
            if (amount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddDefaults()
        {
            Grid1D x = new Grid1D((float)0.2, 2);
            Grid1D y = new Grid1D((float)0.2, 2);
            V3DataOnGrid data1 = new V3DataOnGrid("", DateTime.Now, x, y);
            data1.InitRandom(0.25, 0.5);
            V3DataCollection data2 = new V3DataCollection();
            data2.InitRandom(3, 10, 10, 0.25, 0.5);
            v3Datas.Add(data1);
            v3Datas.Add(data2);
            V3DataCollection data3 = new V3DataCollection();
            data3.dataItems.Add(new DataItem(new Vector2(0.0f, 0.0f), 1.11));
            data3.dataItems.Add(new DataItem(new Vector2(0.0f, 0.2f), 2.22));
            data3.dataItems.Add(new DataItem(new Vector2(0.2f, 0.0f), 3.33));
            data3.dataItems.Add(new DataItem(new Vector2(0.2f, 0.2f), 4.44));
            v3Datas.Add(data3);
        }
        public override string ToString()
        {
            string tmp = "";
            foreach (V3Data v3 in v3Datas)
            {
                tmp = tmp + v3.ToString() + " ";
            }
            return tmp;
        }

    }
}
