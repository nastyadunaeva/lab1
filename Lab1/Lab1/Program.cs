using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid1D x = new Grid1D((float)0.2, 2);
            Grid1D y = new Grid1D((float)0.2, 2);
            V3DataOnGrid onGrid = new V3DataOnGrid("", DateTime.Now, x, y);
            onGrid.InitRandom(0.5, 1.0);
            Console.WriteLine(onGrid.ToLongString());

            V3DataCollection dataCollection = new V3DataCollection();
            dataCollection = (V3DataCollection)onGrid;
            Console.WriteLine(dataCollection.ToLongString());

            Console.WriteLine("Основная коллекция:");
            V3MainCollection main = new V3MainCollection();
            main.AddDefaults();
            Console.WriteLine(main.ToString());

            Vector2 dot = new Vector2((float)0.1, (float)0.3);
            Console.WriteLine($"\n dot = {dot}\n");
            foreach (V3Data element in main)
            {
                Vector2[] vector2s = new Vector2[] { };
                Console.WriteLine(element.ToLongString());

                vector2s = element.Nearest(dot);
                Console.WriteLine("Nearest:");
                foreach (Vector2 vector2 in vector2s)
                { Console.WriteLine(vector2); }
                Console.WriteLine("\n");
            }
        }
    }
}

