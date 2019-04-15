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
        private Drawing draw;

        public Logic(Drawing draw)
        {
            this.draw = draw;
            points = new LinkedList<Point>();
        }

        public void drawline(Point p)
        {
            points.AddLast(p);
            if (points.Count == 1)
            {
                rootP = p;
                draw.drawCartisan();
                draw.drawdot(p);
            }
            else if (points.Count == 2)
            {
                endP = p;
                draw.drawline(rootP, endP, points);
            }
            else
            {
                mindistance(p, points);
                draw.drawline(rootP, endP, points);
            }
           
        }

        private void mindistance(Point p, LinkedList<Point> points)
        {
            float dist = 0.0f;
            float mindist = 1000.0f;
            Console.WriteLine("calculating");
            foreach (var point in points)
            {
                if(point != p)
                {
                    dist = (float)Math.Sqrt((p.X - point.X) ^ 2 - (p.Y - point.Y) ^ 2);
                    Console.WriteLine("calculating distace");
                    Console.WriteLine(dist);
                    Console.WriteLine(point+" "+p);
                    if (dist < mindist)
                    {
                        mindist = dist;
                        Console.WriteLine(mindist);
                        Point midpoint = new Point((p.X + point.X) / 2, (p.Y + point.Y) / 2);
                        Console.WriteLine("midpoint"+midpoint);
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
            if (p1.X > p2.X)
                return true;
            else
                return false;
        }
    }
}
