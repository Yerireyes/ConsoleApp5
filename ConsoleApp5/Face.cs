using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp5
{
    class Face
    {
        public Dictionary<string, Vector> listaDeVertices { get; set; }
        public Color color { get; set; }
        public Vector centro { get; set; }
        public Vector traslacion { get; set; } = new Vector(0, 0, 0);

        public Face(Dictionary<string, Vector> listaDeVertices, Color color, Vector centro)
        {
            this.listaDeVertices = listaDeVertices;
            this.color = color;
            this.centro = centro;
        }

        public void Insertar(Vector nuevoVertice, string key)
        {
            listaDeVertices.Add(key, nuevoVertice);
        }

        public void Eliminar(string key)
        {
            listaDeVertices.Remove(key);
        }

        public Vector Obtener(string key)
        {
            return listaDeVertices[key];
        }

        public void Dibujar()
        {
            GL.Color4(color);
            GL.Begin(PrimitiveType.Polygon);

            foreach (var vertice in listaDeVertices)
            {
                GL.Vertex3(vertice.Value.X + centro.X + traslacion.X, vertice.Value.Y + centro.Y + traslacion.Y, vertice.Value.Z + centro.Z + traslacion.Z);

            }
            GL.End();

        }

        public void Rotar(float anguloX, float anguloY, float anguloZ)
        {
            anguloX = MathHelper.DegreesToRadians(anguloX);
            anguloY = MathHelper.DegreesToRadians(anguloY);
            anguloZ = MathHelper.DegreesToRadians(anguloZ);
            foreach (var vertice in listaDeVertices)
            {
                vertice.Value.Set(RotarX(vertice.Value, anguloX));
                vertice.Value.Set(RotarY(vertice.Value, anguloY));
                vertice.Value.Set(RotarZ(vertice.Value, anguloZ));
            }
        }

        private Vector RotarX(Vector verticeARotar, float angulo)
        {
            Matrix3 matriz = Matrix3.CreateRotationX(angulo);
            return verticeARotar * matriz;
        }

        private Vector RotarY(Vector verticeARotar, float angulo)
        {
            Matrix3 matriz = Matrix3.CreateRotationY(angulo);
            return verticeARotar * matriz;
        }

        private Vector RotarZ(Vector verticeARotar, float angulo)
        {
            Matrix3 matriz = Matrix3.CreateRotationZ(angulo);
            return verticeARotar * matriz;
        }

        public void Trasladar(float x, float y, float z)
        {
            traslacion += new Vector(x, y, z);
        }

        public void Escalado(float x, float y, float z)
        {
            Matrix3 matriz = Matrix3.CreateScale(x, y, z);
            foreach (var vertice in listaDeVertices)
            {
                vertice.Value.Set(vertice.Value * matriz);
            }
        }

    }
}
