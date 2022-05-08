using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeTest
{
    class Point2D
    {
        public double x, y;
        public Point2D(double X_Value, double Y_Value)
        {
            x = X_Value;
            y = Y_Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding closest point pair...");
            int type = Convert.ToInt32(args[0]);
            Console.WriteLine("Verwende {0} als algoritmus", type == 1 ? "euklid" : "simple");
            var points = GetPoints("C:\\Users\\max.mustermann\\repos\\codeschnipsel\\points.csv");

            int p1Index = -1, p2Index = -1;
            var minDist = double.MaxValue;
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    var d = CalculateDistance(points[i], points[j],type);
                    if (d < minDist)
                    {
                        minDist = d;
                        p1Index = i;
                        p2Index = j;
                    }
                }
            }
            Console.WriteLine("Minimaler Abstand ist {0}", minDist);
            Console.WriteLine("Point 1 @ idx {0}: ({1}, {2}", p1Index, points[p1Index].x, points[p1Index].y);
            Console.WriteLine("Point 2 @ idx {0}: ({1}, {1}", p2Index, points[p2Index].x, points[p2Index].y);
        }

        private static List<Point2D> GetPoints(string F)
        {
            
            return File.ReadAllLines(F).
                Select(l => l.Split(';'))
                .Select(a => new Point2D(double.Parse(a[0]), double.Parse(a[1])))
                .ToList();
        }

        public static double CalculateDistance(Point2D P1, Point2D P2, int type)
        {
            double result = 0;
            if (type == 1)
            {
                result = Convert.ToSingle(Math.Sqrt((P2.x - P1.x) * (P2.x - P1.x) + (P2.y - P1.y) * (P2.y - P1.y)));
            }
            else if (type == 2)
            {
                result = Math.Abs(P2.x - P1.x) + Math.Abs(P2.y - P1.y);
            }
            return result;
        }
    }
}
