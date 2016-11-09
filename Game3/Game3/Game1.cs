using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MoveableCamera camera;
        MouseState mouseState = Mouse.GetState();
        Chunk triangle;
        Texture2D CursorTexture;
        RayFromScreen rayFromScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Create a new SpriteBatch, which can be used to draw textures.
            camera = new MoveableCamera(GraphicsDevice);
            triangle = new Chunk(GraphicsDevice, new Vector3(4, 0, 0), 4, 10, 3, Content.Load<Texture2D>("texture"));
            CursorTexture = Content.Load<Texture2D>("Cursor");
            rayFromScreen = new RayFromScreen();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (IsActive && keyState.IsKeyDown(Keys.V))
            {
                IsMouseVisible = false;
                camera.Update(gameTime);
            }
            else {
                IsMouseVisible = true;
            }
            // rotation += 0.001f;
            //camera.UpdateViewMatrix(Vector3.Transform(new Vector3(50, 50, 50), Matrix.CreateRotationY(rotation)), new Vector3(60, 30, 60), Vector3.Up);

            triangle.MoveCube(0,0,0, new Vector3(-1*gameTime.ElapsedGameTime.Milliseconds/1000f,0,0));

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }
            rayFromScreen.update(GraphicsDevice.Viewport.Unproject(new Vector3(mouseState.X ,mouseState.Y, 0) ,camera.View, camera.Projection, Matrix.Identity), camera.GetCameraTarget);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.Black);
            
            triangle.Draw(camera.View, camera.Projection);
            // TODO: Add your drawing code here
            //4, 10, 3
            for (int z = 0; z < 3; z++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (rayFromScreen.IfInteresects(triangle.GetCubeParam(x, y, z).BoundingBoxOfThatCube) != 0) {

                            spriteBatch.Begin();
                            spriteBatch.Draw(CursorTexture, Vector2.Zero, Color.White);
                            spriteBatch.End();

                        }
                    }
                }
            }
            


            base.Draw(gameTime);
        }
    }
}
