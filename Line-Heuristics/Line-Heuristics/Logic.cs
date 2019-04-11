using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Line_Heuristics
{
    class Logic
    {
        private LinkedList<Point> points;
        private Point rootP, endP;
        public Logic()
        {
            points = new LinkedList<Point>();
        }

        public void drawline(Point p)
        {
            points.AddLast(p);
            if (points.Count == 1)
            {
                rootP = p;
            }
            else if (points.Count == 2)
            {
                endP = p;
                drawline(rootP, endP);
            }
            else
            {
                mindistance(p, points);
                drawline(rootP, endP);
            }
           
        }

        private void drawline(Point p1, Point p2)
        {

        }

        private void mindistance(Point p, LinkedList<Point> points)
        {
            float dist = 0.0f;
            float mindist = 0.0f;
            foreach (var point in points)
            {
                if(point != p)
                {
                    dist = (float)Math.Sqrt((p.X - point.X) ^ 2 - (p.Y - point.Y) ^ 2);
                    if (mindist == 0.0) mindist = dist;
                    else if (dist < mindist)
                    {
                        mindist = dist;
                        Point midpoint = new Point((p.X + point.X) / 2, (p.Y + point.Y) / 2);
                        if (isleft(midpoint, rootP))
                        {
                            endP = rootP;
                            rootP = midpoint;
                        }
                        else
                            endP = midpoint;
                    }
                }
            }
        }

        private Boolean isleft(Point p1, Point p2)
        {
            if (p1.X < p2.X)
                return true;
            else
                return false;
        }
    }
}
