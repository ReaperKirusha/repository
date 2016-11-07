using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class Triangle
    {
        int numbersOfCubes;
        VertexPositionTexture[] vertices;//= new VertexPositionTexture[16*16*16*16];
        int[] indices;// = new int[36 * 16 * 16 * 16];
       
        public Vector3 Zplus = new Vector3(0,0,10);
        public Vector3 Xplus= new Vector3(10,0,0);
        public Vector3 Yplus = new Vector3(0,10,0);
        public Texture2D texture;
        BasicEffect basicEffect;
        GraphicsDevice device;

        public Triangle(GraphicsDevice device, Vector3 a, int numbersOfCubes, Texture2D texture)
        {
            this.numbersOfCubes = numbersOfCubes;
            vertices = new VertexPositionTexture[16 * numbersOfCubes * numbersOfCubes * numbersOfCubes];
            indices = new int[36 * numbersOfCubes * numbersOfCubes * numbersOfCubes];
            this.texture = texture;
            this.device = device;
            basicEffect = new BasicEffect(device);
            Vector3 IterationVector = new Vector3(0,0,0);
            int IterationSum = 0;
            for (int i = 0; i < numbersOfCubes; i++) {
                for (int j = 0; j < numbersOfCubes; j++) {
                    for (int g = 0; g < numbersOfCubes; g++) {
                        IterationVector = g * Xplus + j * Yplus + i * Zplus;
                        IterationSum = numbersOfCubes * g + numbersOfCubes * numbersOfCubes * j + numbersOfCubes * numbersOfCubes * numbersOfCubes * i;
                        vertices[0 + IterationSum].Position = a + IterationVector;
                        vertices[1 + IterationSum].Position = a + Yplus + IterationVector;
                        vertices[2 + IterationSum].Position = a + Yplus + Xplus + IterationVector;
                        vertices[3 + IterationSum].Position = a + Xplus + IterationVector;
                        vertices[4 + IterationSum].Position = a + Zplus + IterationVector;
                        vertices[5 + IterationSum].Position = a + Zplus + Yplus + IterationVector;
                        vertices[6 + IterationSum].Position = a + Zplus + Yplus + Xplus + IterationVector;
                        vertices[7 + IterationSum].Position = a + Zplus + Xplus + IterationVector;
                        vertices[8 + IterationSum].Position = a + IterationVector;
                        vertices[9 + IterationSum].Position = a + Yplus + IterationVector;
                        vertices[10 + IterationSum].Position = a + Yplus + Xplus + IterationVector;
                        vertices[11 + IterationSum].Position = a + Xplus + IterationVector;
                        vertices[12 + IterationSum].Position = a + Zplus + IterationVector;
                        vertices[13 + IterationSum].Position = a + Zplus + Yplus + IterationVector;
                        vertices[14 + IterationSum].Position = a + Zplus + Yplus + Xplus + IterationVector;
                        vertices[15 + IterationSum].Position = a + Zplus + Xplus + IterationVector;
                    }
                }
            }
            /* vertices[0].Position = a;//+new Vector3(100,100,100)
             vertices[1].Position = b;
             vertices[2].Position = c;
             vertices[3].Position = d;*/
            /*vertices[0 ].Position = a;
            vertices[1 ].Position = a + Yplus;
            vertices[2 ].Position = a + Yplus + Xplus;
            vertices[3 ].Position = a + Xplus ;
            vertices[4].Position = a + Zplus;
            vertices[5].Position = a + Zplus + Yplus;
            vertices[6].Position = a + Zplus + Yplus + Xplus;
            vertices[7].Position = a + Zplus + Xplus;*/
            IterationSum = 0;
            int IterationIndex = 0;
            for (int i = 0; i < numbersOfCubes; i++)
            {
                for (int j = 0; j < numbersOfCubes; j++)
                {
                    for (int g = 0; g < numbersOfCubes; g++)
                    {
                        IterationSum = numbersOfCubes * g + numbersOfCubes * numbersOfCubes * j + numbersOfCubes * numbersOfCubes * numbersOfCubes * i;
                        vertices[0 + IterationSum].TextureCoordinate = new Vector2(1, 1);
                        vertices[1 + IterationSum].TextureCoordinate = new Vector2(1, 0);
                        vertices[2 + IterationSum].TextureCoordinate = new Vector2(0, 0);
                        vertices[3 + IterationSum].TextureCoordinate = new Vector2(0, 1);
                        vertices[4 + IterationSum].TextureCoordinate = new Vector2(0, 1);
                        vertices[5 + IterationSum].TextureCoordinate = new Vector2(0, 0);
                        vertices[6 + IterationSum].TextureCoordinate = new Vector2(1, 0);
                        vertices[7 + IterationSum].TextureCoordinate = new Vector2(1, 1);

                        vertices[8 + IterationSum].TextureCoordinate = new Vector2(0, 0);
                        vertices[9 + IterationSum].TextureCoordinate = new Vector2(0, 0);
                        vertices[10 + IterationSum].TextureCoordinate = new Vector2(1, 0);
                        vertices[11 + IterationSum].TextureCoordinate = new Vector2(1, 0);
                        vertices[12 + IterationSum].TextureCoordinate = new Vector2(0, 1);
                        vertices[13 + IterationSum].TextureCoordinate = new Vector2(0, 1);
                        vertices[14 + IterationSum].TextureCoordinate = new Vector2(1, 1);
                        vertices[15 + IterationSum].TextureCoordinate = new Vector2(1, 1);

                        IterationSum = 36 * g + 36 * numbersOfCubes * j + 36 * numbersOfCubes * numbersOfCubes * i;
                        IterationIndex = numbersOfCubes * g + numbersOfCubes * numbersOfCubes * j + numbersOfCubes * numbersOfCubes * numbersOfCubes * i;
                        indices[0 + IterationSum] = 0 + IterationIndex;
                        indices[1 + IterationSum] = 3 + IterationIndex;
                        indices[2 + IterationSum] = 2 + IterationIndex;
                        indices[3 + IterationSum] = 2 + IterationIndex;
                        indices[4 + IterationSum] = 1 + IterationIndex;
                        indices[5 + IterationSum] = 0 + IterationIndex;
                        indices[6 + IterationSum] = 7 + IterationIndex;
                        indices[7 + IterationSum] = 6 + IterationIndex;
                        indices[8 + IterationSum] = 3 + IterationIndex;
                        indices[9 + IterationSum] = 6 + IterationIndex;
                        indices[10 + IterationSum] = 2 + IterationIndex;
                        indices[11 + IterationSum] = 3 + IterationIndex;
                        indices[12 + IterationSum] = 4 + IterationIndex;
                        indices[13 + IterationSum] = 5 + IterationIndex;
                        indices[14 + IterationSum] = 7 + IterationIndex;
                        indices[15 + IterationSum] = 5 + IterationIndex;
                        indices[16 + IterationSum] = 6 + IterationIndex;
                        indices[17 + IterationSum] = 7 + IterationIndex;
                        indices[18 + IterationSum] = 5 + IterationIndex;
                        indices[19 + IterationSum] = 4 + IterationIndex;
                        indices[20 + IterationSum] = 0 + IterationIndex;
                        indices[21 + IterationSum] = 0 + IterationIndex;
                        indices[22 + IterationSum] = 1 + IterationIndex;
                        indices[23 + IterationSum] = 5 + IterationIndex;


                        indices[24 + IterationSum] = 14 + IterationIndex;
                        indices[25 + IterationSum] = 13 + IterationIndex;
                        indices[26 + IterationSum] = 9 + IterationIndex;
                        indices[27 + IterationSum] = 10 + IterationIndex;
                        indices[28 + IterationSum] = 14 + IterationIndex;
                        indices[29 + IterationSum] = 9 + IterationIndex;
                        indices[30 + IterationSum] = 15 + IterationIndex;
                        indices[31 + IterationSum] = 8 + IterationIndex;
                        indices[32 + IterationSum] = 12 + IterationIndex;
                        indices[33 + IterationSum] = 7 + IterationIndex;
                        indices[34 + IterationSum] = 11 + IterationIndex;
                        indices[35 + IterationSum] = 8 + IterationIndex;
                    }
                }
            }
        }


        public void Draw(Matrix View, Matrix Projection)
        {
            basicEffect.World = Matrix.Identity;
            basicEffect.View = View;
            basicEffect.Projection = Projection;
            basicEffect.TextureEnabled = true;
            basicEffect.Texture = texture;
            basicEffect.CurrentTechnique.Passes[0].Apply();
            
            //basicEffect.Texture = ;

            device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, 12 * numbersOfCubes * numbersOfCubes * numbersOfCubes);
            //device.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 2, VertexPositionColor.VertexDeclaration);
        }
    }
}
