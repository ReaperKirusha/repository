﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public struct CubeParam
    {
        public int StartOfIdicies;
        public int StartOfVerticles;
        public BoundingBox BoundingBoxOfThatCube;
    }

    public class Chunk
    { 
        int numbersOfCubesX, numbersOfCubesY, numbersOfCubesZ; //кол-во кубов по осям

        VertexPositionTexture[] vertices;//массив вершин
        int[] indices;//массив индексов
        BoundingBox[] BoundingBoxes;// массив тел

        // векторы для IterationVector, для сдвига вершин куба
        public Vector3 Zplus = new Vector3(0,0,10);
        public Vector3 Xplus= new Vector3(10,0,0);
        public Vector3 Yplus = new Vector3(0,10,0);

        public Texture2D texture;

        BasicEffect basicEffect;
        GraphicsDevice device;

        public Chunk(GraphicsDevice device, Vector3 a, int numbersOfCubesX, int numbersOfCubesY, int numbersOfCubesZ, Texture2D texture)
        {
      

            this.numbersOfCubesX = numbersOfCubesX;
            this.numbersOfCubesY = numbersOfCubesY;
            this.numbersOfCubesZ = numbersOfCubesZ;

            vertices = new VertexPositionTexture[16 * numbersOfCubesX * numbersOfCubesY * numbersOfCubesZ]; // на каждый куб 16 вершин
            indices = new int[36 * numbersOfCubesX * numbersOfCubesY * numbersOfCubesZ]; // на каждый куб 12 треугольников =  36 индексов
            BoundingBoxes = new BoundingBox[numbersOfCubesX * numbersOfCubesY * numbersOfCubesZ];// кол-во кубов
            Vector3[] VectorsForBoundingBox = new Vector3[8];

            this.texture = texture;

            this.device = device;
            basicEffect = new BasicEffect(device);

            Vector3 IterationVector = new Vector3(0,0,0); // вектор для сдвига всех вершин куба

            int IterationSum = 0; //переменная для индексации indicies[i]
            int IterationIndex = 0; // переменная для назначения каждому индексу вершины, на каждой итерации увеличивается на 16(кол-во вершин для куба)
            int VerticleTextureIndex = 0; //переменная для индексации verticles[i].TextureCoordinate
            int VerticleIndex = 0; //переменная для индексации verticles[i].Position
            int BoundingBoxIndex = 0;// переменная для индексации Bounding box 

            for (int i = 0; i < numbersOfCubesZ; i++) { //третья итерация влияет на кол-во кубов по Z

                for (int j = 0; j < numbersOfCubesY; j++) { //вторая итерация влияет на кол-во кубов по Y

                    for (int g = 0; g < numbersOfCubesX; g++) { //первая итерация влияет на кол-во кубов по X

                        IterationVector = g * Xplus + j * Yplus + i * Zplus;
                       
                        vertices[VerticleIndex++].Position = a + IterationVector;
                        vertices[VerticleIndex++].Position = a + Yplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Yplus + Xplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Xplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + Yplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + Yplus + Xplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + Xplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + IterationVector;
                        vertices[VerticleIndex++].Position = a + Yplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Yplus + Xplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Xplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + Yplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + Yplus + Xplus + IterationVector;
                        vertices[VerticleIndex++].Position = a + Zplus + Xplus + IterationVector;

                        //BouningBox
                        for (int VectorsForBoundinBoxIndex = 0; VectorsForBoundinBoxIndex < 8; VectorsForBoundinBoxIndex++) {
                            VectorsForBoundingBox[VectorsForBoundinBoxIndex] = vertices[VerticleIndex-15+VectorsForBoundinBoxIndex].Position;
                        }

                        //BoundingBoxIndex = g + numbersOfCubesY * j + numbersOfCubesZ * numbersOfCubesZ * i;
                        BoundingBoxes[BoundingBoxIndex++] = BoundingBox.CreateFromPoints(VectorsForBoundingBox);

                        //боковые вершины
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 1); //1
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 0); //2
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0, 0); //3
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0, 1); //4
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0, 1); //5
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0, 0); //6
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 0); //7
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 1); //8

                        // нижние и верхние вершины
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 0); //9
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 0); //10
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(1, 0); //11
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(1, 0); //12
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 1); //13
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(0.5f, 1); //14
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(1, 1); //15
                        vertices[VerticleTextureIndex++].TextureCoordinate = new Vector2(1, 1); //16


                        //индексы для боковых граней
                        indices[IterationSum++] = 0 + IterationIndex;// X-Y , Z = 0
                        indices[IterationSum++] = 3 + IterationIndex;
                        indices[IterationSum++] = 2 + IterationIndex;
                        indices[IterationSum++] = 2 + IterationIndex;
                        indices[IterationSum++] = 1 + IterationIndex;
                        indices[IterationSum++] = 0 + IterationIndex;// X-Y , Z = 0

                        indices[IterationSum++] = 7 + IterationIndex;// Y-Z , X = 10
                        indices[IterationSum++] = 6 + IterationIndex;
                        indices[IterationSum++] = 3 + IterationIndex;
                        indices[IterationSum++] = 6 + IterationIndex;
                        indices[IterationSum++] = 2 + IterationIndex;
                        indices[IterationSum++] = 3 + IterationIndex;// Y-Z , X = 10

                        indices[IterationSum++] = 4 + IterationIndex;// X-Y , Z = 10
                        indices[IterationSum++] = 5 + IterationIndex;
                        indices[IterationSum++] = 7 + IterationIndex;
                        indices[IterationSum++] = 5 + IterationIndex;
                        indices[IterationSum++] = 6 + IterationIndex;
                        indices[IterationSum++] = 7 + IterationIndex;// X-Y , Z = 10

                        indices[IterationSum++] = 5 + IterationIndex;// Y-Z , X = 0
                        indices[IterationSum++] = 4 + IterationIndex;
                        indices[IterationSum++] = 0 + IterationIndex;
                        indices[IterationSum++] = 0 + IterationIndex;
                        indices[IterationSum++] = 1 + IterationIndex;
                        indices[IterationSum++] = 5 + IterationIndex;// Y-Z , X = 0

                        //индексы для верхней и нижней грани
                        indices[IterationSum++] = 14 + IterationIndex;//верхняя грань
                        indices[IterationSum++] = 13 + IterationIndex;
                        indices[IterationSum++] = 9 + IterationIndex;
                        indices[IterationSum++] = 10 + IterationIndex;
                        indices[IterationSum++] = 14 + IterationIndex;
                        indices[IterationSum++] = 9 + IterationIndex;// верхняя грань

                        indices[IterationSum++] = 15 + IterationIndex;// нижняя грань
                        indices[IterationSum++] = 8 + IterationIndex;
                        indices[IterationSum++] = 12 + IterationIndex;
                        indices[IterationSum++] = 15 + IterationIndex;
                        indices[IterationSum++] = 11 + IterationIndex;
                        indices[IterationSum++] = 8 + IterationIndex;// нижняя грань

                        IterationIndex += 16;
                    }
                }
            }
           
    }

        public CubeParam GetCubeParam(int x, int y, int z) { // взять параметры куба под номером(отсчет от 0)
            CubeParam temp;
            temp.StartOfIdicies = 36 * x + 36 * numbersOfCubesY * y + 36 * numbersOfCubesZ * numbersOfCubesZ * z;
            temp.StartOfVerticles = 16 * x + 16 * numbersOfCubesY * y + 16 * numbersOfCubesZ * numbersOfCubesZ * z;
            temp.BoundingBoxOfThatCube = BoundingBoxes[x + numbersOfCubesY * y + numbersOfCubesZ * numbersOfCubesZ * z];

            return temp;
        }

        public void MoveCube(int x, int y, int z, Vector3 MovingVector) { // сдвигает выбраный куб на вектор (отсчет то 0)
            CubeParam MovingCubeParam = GetCubeParam(x, y, z);
            
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
            vertices[MovingCubeParam.StartOfVerticles++].Position += MovingVector;
        }



        public void Draw(Matrix View, Matrix Projection)
        {
            basicEffect.World = Matrix.Identity;
            basicEffect.View = View;
            basicEffect.Projection = Projection;
            basicEffect.TextureEnabled = true;
            basicEffect.Texture = texture;
            basicEffect.CurrentTechnique.Passes[0].Apply();

            device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, 12 * numbersOfCubesX * numbersOfCubesY * numbersOfCubesZ);

        }
    }
}
