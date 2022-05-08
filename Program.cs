using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding closest point pair...");
            int type = Convert.ToInt32(args[0]);
            Console.WriteLine("Verwende {0} als algoritmus", type == 1 ? "euklid" : "simple");
            var points = GetPoints("C:\\Users\\max.mustermann\\repos\\codeschnipsel\\points.csv");

            Tuple<double, double> p1 = null;
            Tuple<double, double> p2 = null;
            int p1Index = -1, p2Index = -1;
            var minDist = double.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {

                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j) goto next;
                    var d = CalculateDistance((float)points[i].Item1, (float)points[i].Item2, (float)points[j].Item1, (float)points[j].Item2, type);
                    if (d < minDist)
                    {
                        minDist = d;
                        p1 = new Tuple<double, double>(points[i].Item1, points[i].Item2);
                        p2 = new Tuple<double, double>(points[j].Item1, points[j].Item2);
                        p1Index = i;
                        p2Index = j;
                    }
                }
                next:;
            }
            Console.WriteLine("Minimaler Abstand ist {0}", minDist);
            Console.WriteLine("Point 1 @ idx {0}: ({1}, {2}", p1Index, p1.Item1, p1.Item2);
            Console.WriteLine("Point 2 @ idx {0}: ({1}, {1}", p2Index, p2.Item1, p2.Item2);
        }

        private static Tuple<double, double>[] GetPoints(string F)
        {
            return File.ReadAllLines(F).
                Select(l => l.Split(';'))
                .Select(a => new Tuple<double, double>(double.Parse(a[0]), double.Parse(a[1])))
                .ToArray();
        }

        public static float CalculateDistance(float x1, float y1, float x2, float y2, int type)
        {
            float result = 0f;
            if (type == 1)
            {
                result = Convert.ToSingle(Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
            }
            else if (type == 2)
            {
                result = Math.Abs(x2 - x1) + Math.Abs(y1 - y2);
            }
            return result;
        }
    }
}
