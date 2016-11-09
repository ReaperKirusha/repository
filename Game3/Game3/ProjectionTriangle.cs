using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game3
{
    class ProjectionTriangle
    {
        VertexPositionColor[] ProjectVetricies = new VertexPositionColor[3];
        int[] ProjectIndicies = new int[3];
        Vector3 point1 = new Vector3(200, 200, 200);
        Vector3 point2 = new Vector3(210, 210, 210);
        Vector3 point3 = new Vector3(220, 190, 220);


        
        GraphicsDevice device;
        BasicEffect basicEffect; 

        public ProjectionTriangle(GraphicsDevice device)
        {
            this.device = device;
            basicEffect = new BasicEffect(device);

            ProjectIndicies[0] = 0;
            ProjectIndicies[1] = 1;
            ProjectIndicies[2] = 2;
            ProjectVetricies[0].Color = Color.White;
            ProjectVetricies[1].Color = Color.White;
            ProjectVetricies[2].Color = Color.White;

        }
        public void update(Matrix View, Matrix Projection) {
            
        }


        public void Draw(Matrix View, Matrix Projection)
        {

            basicEffect.World = Matrix.Identity;
            basicEffect.View = View;
            basicEffect.Projection = Projection;
            basicEffect.CurrentTechnique.Passes[0].Apply();

            ProjectVetricies[0].Position = device.Viewport.Project(point1, basicEffect.Projection, basicEffect.View, basicEffect.World);

            ProjectVetricies[1].Position = device.Viewport.Project(point2, Projection, basicEffect.View, basicEffect.World);

            ProjectVetricies[2].Position = device.Viewport.Project(point3, Projection, basicEffect.View, basicEffect.World);


            device.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, ProjectVetricies, 0, ProjectVetricies.Length, ProjectIndicies, 0, 1);
        }
    }
}
