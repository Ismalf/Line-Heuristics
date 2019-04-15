using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Line_Heuristics
{
    class Drawing
    {
        private Panel pic;
        public Panel Pic { get => pic; set => pic = value; }
        private Pen pen = new Pen(Color.Black, 4);
        private Graphics canvas;
        private int scaleF = 10;
        private int offsetx, offsety;

        public Drawing(Panel p)
        {
            pic = p;
            canvas = Pic.CreateGraphics();
            offsetx = Pic.Width / 2;
            offsety = Pic.Height / 2;
        }

        public void drawline(Point p1, Point p2, LinkedList<Point> points)
        {
            canvas.Clear(Color.White);
            drawCartisan();
            foreach (var point in points)
            {
                drawdot(point);
            }
            canvas.DrawLine(pen, p1, p2);
        }

        public  void drawCartisan()
        {
            canvas.DrawLine(pen, Pic.Width / 2, 0, Pic.Width / 2, Pic.Height);
            canvas.DrawLine(pen, 0, Pic.Height / 2, Pic.Width, Pic.Height / 2);
        }

        public void drawdot(Point p)
        {
            canvas.DrawEllipse(pen, p.X, p.Y, 4, 4);
        }
    }
}
