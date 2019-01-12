using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
//using OpenTK;
//using OpenTK.Graphics.OpenGL;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace OpenTKWindowTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a = false;
            w = false;
            s = false;
            d = false;
            this.e = false;
            q = false;
            
        }

        float x = 0;
        float y = 0;
        float z = -5;
        bool a, w, s, d, e, q;
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            
            gl.Translate(0f, 0f, z);

            gl.Rotate(x, 1f, 0f, 0f);
            gl.Rotate(y, 0f, 1f, 0f);

            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.Color(1f, 0f, 0f);

            gl.Vertex(0f, 1f, 1f);
            gl.Vertex(1f, 0f, 1f);
            gl.Vertex(-1f, 0f, 1f);

            gl.Color(1f, 1f, 0f);

            gl.Vertex(0f, 1f, -1f);
            gl.Vertex(1f, 0f, -1f);
            gl.Vertex(-1f, 0f, -1f);
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(0f, 0f, 1f);
            gl.Vertex(0f, 1f, 1f);
            gl.Vertex(0f, 1f, -1f);
            gl.Vertex(1f, 0f, -1f);
            gl.Vertex(1f, 0f, 1f);

            gl.Color(0f, 1f, 0f);
            gl.Vertex(0f, 1f, 1f);
            gl.Vertex(0f, 1f, -1f);
            gl.Vertex(-1f, 0f, -1f);
            gl.Vertex(-1f, 0f, 1f);

            gl.Color(0f, 1f, 1f);
            gl.Vertex(1f, 0f, -1f);
            gl.Vertex(1f, 0f, 1f);
            gl.Vertex(-1f, 0f, 1f);
            gl.Vertex(-1f, 0f, -1f);
            gl.End();

            gl.LoadIdentity();
            gl.Flush();

            x += w ? 3f : 0f;
            x -= s ? 3f : 0f;
            y += a ? 3f : 0f;
            y -= d ? 3f : 0f;
            z += z < -2 ? (e ? 1f : 0f) : 0f;
            z -= z > -30 ? (q ? 1f : 0f) : 0f;
        }
        
        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 'W':
                    w = true;
                    break;
                case 'S':
                    s = true;
                    break;
                case 'D':
                    d = true;
                    break;
                case 'A':
                    a = true;
                    break;
                case 'E':
                    this.e = true;
                    break;
                case 'Q':
                    q = true;
                    break;
            }
        }

        private void openGLControl1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 'W':
                    w = false;
                    break;
                case 'S':
                    s = false;
                    break;
                case 'D':
                    d = false;
                    break;
                case 'A':
                    a = false;
                    break;
                case 'E':
                    this.e = false;
                    break;
                case 'Q':
                    q = false;
                    break;
            }
        }
    }
}
