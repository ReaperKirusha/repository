using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game3
{
    public class MoveableCamera : Camera
    {
        private float TranslationSpeed = 50f;
        private float RotationSpeed = 0.1f;
        private Vector3 Position;
        private float Yaw = 0;
        private float Pitch = 0;
        Vector3 cameraFinalTarget;

        private MouseState lastMouseState;

        public MoveableCamera(GraphicsDevice device) : base(device)
        {
            cameraFinalTarget = new Vector3(1,1,1);
            lastMouseState = Mouse.GetState();
        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);



            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            MouseState mouseState = Mouse.GetState();
            float deltaX = mouseState.X - lastMouseState.X;
            float deltaY = mouseState.Y - lastMouseState.Y;
            Yaw -= RotationSpeed * deltaX * elapsedTime;
            Pitch -= RotationSpeed * deltaY * elapsedTime;


            Vector3 translation = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.W))
            {
                translation += new Vector3(0, 0, -TranslationSpeed) * elapsedTime;
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                translation += new Vector3(0, 0, TranslationSpeed) * elapsedTime;
            }

            if (keyState.IsKeyDown(Keys.D))
            {
                translation += new Vector3(TranslationSpeed, 0, 0) * elapsedTime;
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                translation += new Vector3(-TranslationSpeed, 0, 0) * elapsedTime;
            }


            Matrix rotationMatrix = Matrix.CreateFromYawPitchRoll(Yaw, Pitch, 0);
            Mouse.SetPosition(device.Viewport.Width / 2, device.Viewport.Height / 2);
            lastMouseState = Mouse.GetState();


            Vector3 Up = Vector3.Transform(Vector3.Up, rotationMatrix);

            Position += Vector3.Transform(translation, rotationMatrix);
            cameraFinalTarget = Position + Vector3.Transform(new Vector3(0, 0, -1), rotationMatrix);

            View = Matrix.CreateLookAt(Position, cameraFinalTarget, Up);            
        }

        public Vector3 GetCameraTarget { get { return cameraFinalTarget; } }
    }
}
