using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class RayFromScreen{
        private Ray main;

        public RayFromScreen() {
            main.Position = new Vector3(-100,-100,-100);
            main.Direction = new Vector3(-1, -1, -1);
        }

        public Ray GetRay{ get{ return main; } }

        public void update(Vector3 Direction, Vector3 Position) {
            main.Direction = Direction;
            main.Position = Position;
        }

        public float IfInteresects(BoundingBox Inter) {
            if (main.Intersects(Inter) != null) {
                return (float)main.Intersects(Inter);
            } else {
                return 0;
            }      
        }

    }
}
