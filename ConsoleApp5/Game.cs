using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp5
{
    class Game : GameWindow
    {
        private Dictionary<String, Objeto3D> objetos = new Dictionary<String, Objeto3D>();
        private Dictionary<String, Objeto3D> objetos1 = new Dictionary<String, Objeto3D>();
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        public HelloEscenario escenario;
        public HelloEscenario escenario2;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.White);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-500, 500, -500, 500, -500, 500);
            Objeto3D prueba = CargadorJson.Cargar("../../Objetos/prueba.json");
            Objeto3D prueba1 = CargadorJson.Cargar("../../Objetos/prueba1.json");
            Objeto3D prueba2 = CargadorJson.Cargar("../../Objetos/prueba.json");
            Objeto3D prueba3 = CargadorJson.Cargar("../../Objetos/prueba1.json");
            objetos.Add("prueba", prueba);
            objetos.Add("prueba1", prueba1);
            objetos1.Add("prueba2", prueba2);
            objetos1.Add("prueba3", prueba3);
            escenario = new HelloEscenario(objetos, new Vector(-200, -100, 0));
            escenario2 = new HelloEscenario(objetos1, new Vector(50, 50, 0));


        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            escenario.Dibujar();
            escenario.Obtener("prueba").Rotar(1, 0, 0);
            escenario2.Dibujar();
            SwapBuffers();

            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}
