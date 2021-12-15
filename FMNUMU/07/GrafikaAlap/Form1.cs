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

        double alpha = 0.0;
        Vector4 v = new Vector4(1.1, 1.0, 10.2);
        Vector2 center;
        Matrix4 parallel;
        List<Matrix4> transformations = new List<Matrix4>();
        Pen pen = new Pen(Color.Blue, 20f);

        ObjectBRep suzanne = new ObjectBRep();

        public Form1()
        {
            InitializeComponent();

            suzanne.model.LoadFromFile(@"Obj\Suzanne.obj", ModelFileType.Wavefront);
            suzanne.transformation = Matrix4.Scale(150) * Matrix4.RotX(2 * alpha);
            suzanne.color = Color.Salmon;

            parallel = Matrix4.Parallel(v);
            center = new Vector2(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.DrawObjectBRepWithEdges(suzanne, parallel, center);
            //MessageBox.Show(suzanne.model.vertices.Count().ToString());
            
            for (int i = 0; i < suzanne.model.vertices.Count()-3; i+=4)
            {
                g.DrawBezier3Arc(pen, suzanne.model.vertices[i], suzanne.model.vertices[i+1],
                    suzanne.model.vertices[i+2], suzanne.model.vertices[i+3]);
            }
            //ha lett volna még idő :c
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
