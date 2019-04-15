using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Line_Heuristics
{
    public partial class Form1 : Form
    {
        private Drawing drawing;
        private Logic logic;
        public Form1()
        {
            InitializeComponent();
            drawing = new Drawing(picB);
            logic = new Logic(drawing);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int x, y;
            try
            {
                x = int.Parse(txtX.Text);
                y = int.Parse(txtY.Text);
                logic.drawline(new Point(x+300, -1*y+200));
                txtX.Text = "";
                txtY.Text = "";
            }
            catch
            {

            }
            
        }
    }
}
