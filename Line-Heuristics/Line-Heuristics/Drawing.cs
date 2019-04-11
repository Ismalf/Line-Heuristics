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
        private Pen pen = new Pen(Color.Black);
        private Graphics canvas;
        private int scaleF = 10;

        public Drawing(Panel p)
        {
            pic = p;
            canvas = Pic.CreateGraphics();
        }

        public void drawline(Point p1, Point p2, LinkedList<Point> points)
        {
            Point p1tmp = new Point((p1.X * scaleF + Pic.Width / 2), (p1.Y * scaleF + Pic.Height / 2));
            Point p2tmp = new Point((p2.X * scaleF + Pic.Width / 2), (p2.Y * scaleF + Pic.Height / 2));
            canvas.Clear(Color.White);
            drawCartisan();
            foreach (var point in points)
            {
                drawdot(point);
            }
            canvas.DrawLine(pen, p1tmp, p2tmp);
        }

        public  void drawCartisan()
        {
            canvas.DrawLine(pen, Pic.Width / 2, 0, Pic.Width / 2, Pic.Height);
            canvas.DrawLine(pen, 0, Pic.Height / 2, Pic.Width, Pic.Height / 2);
        }

        public void drawdot(Point p)
        {
            canvas.DrawEllipse(pen, p.X, p.Y, 2, 2);
        }
    }
}
