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
        Rectangle target;
        List<Vector2> V = new List<Vector2>();
        int grabbed = -1;

        int x = 400;
        int y = 200;
        int w = 200;
        int h = 150;


        public Form1()
        {
            target = new Rectangle(x, y, w, h);
            V.Add(new Vector2(x, y));
            V.Add(new Vector2(x+w, y));
            V.Add(new Vector2(x+w, y+h));
            V.Add(new Vector2(x, y+h));

            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {

            g = e.Graphics;
            g.DrawRectangle(new Pen(Color.Red, 2),target);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for (int i = 0; i < V.Count - 1; i++)
            {
                g.DrawLine(Pens.Black, V[i], V[i + 1]);
                g.DrawPoint(Pens.Black, Brushes.White, V[i], 5);
            }
            if (V.Count > 1)
                g.DrawPoint(Pens.Black, Brushes.White, V.LastOrDefault(), 5);

            g.DrawBezier(Pens.Blue, V);

        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < V.Count; i++)
            {
                if (e.CloseEnough(V[i]))
                    grabbed = i;
            }

            if (grabbed == -1)
            {
                V.Add(new Vector2(e.X, e.Y));
                grabbed = V.Count - 1;
                canvas.Invalidate();
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                V[grabbed] = new Vector2(e.X, e.Y);
                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
