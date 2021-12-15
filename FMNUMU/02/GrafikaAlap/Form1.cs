using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrafikaDLL;

namespace GrafikaAlap
{
    public partial class Form1 : Form
    {
        Graphics g;
        double scale = 100;
        Vector2 o;
        int penWidth = 5;

        public Form1()
        {
            InitializeComponent();
            o = new Vector2(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawLine(Pens.Black, 0, (float)o.y, canvas.Width, (float)o.y);
            g.DrawLine(Pens.Black, (float)o.x, 0, (float)o.x, canvas.Height);
            for (double i = 0; i < 100; i++)
            {

                drawCurve(g, (i*0.2), penWidth++);
            }
        }

        private void drawCurve(Graphics g, double interval, int penwidth)
        {
            g.DrawParametricCurve2D(new Pen(Color.Red, penwidth),
              t => scale * Math.Sin(2 * t) + o.x,
              t => scale * Math.Sin(3 * t) + o.y,
              interval, 2 * Math.PI, 500);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
