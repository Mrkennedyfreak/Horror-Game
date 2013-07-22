using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Horror_Engine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    { 
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;

        public Matrix viewMatrix;

        Menu m;

        BasicEffect effect;

        DrawMouseCursor cursor;

        public Boolean gameInit = true;
        public Boolean drawCursor = true;

        InputListener updateInput = new InputListener();

        Model house;

        // Set the position of the camera in world space, for our view matrix.
        public Vector3 cameraPosition = new Vector3(0.0f, 0.0f, 0.0f);

        public float pitch;
        public float yaw;
        public const float rotationSpeed = 0.025f;
        public const float moveSpeed = 1f; //30.0f;
        public float aspectRatio;

        MouseState originalMouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            device = graphics.GraphicsDevice;
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;

            Window.Title = "The Engine of Horrors";

            //graphics.GraphicsDevice.BlendState = BlendState.Opaque;
            //graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            //graphics.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
            
            graphics.ApplyChanges();
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
            
            //graphics.ToggleFullScreen();

            aspectRatio = graphics.GraphicsDevice.Viewport.Width / graphics.GraphicsDevice.Viewport.Height;

            m = new Menu(Content);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.UpdateViewMatrix();

            if (gameInit == true)
            {
                cursor = new DrawMouseCursor(true, spriteBatch, Content);

                m.MenuContent(Content, spriteBatch);
            }

            if (gameInit == false)
            {
                //house = Content.Load<Model>("Models\\house");
                house = Content.Load<Model>("Models\\house");
            }
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;

            if (gameInit == true)
            {
                Draw(gameTime);

                for (int i = 1; i <= m.getButtonCount(); i++)
                {
                    Boolean check = m.checkMenu(i);

                    if (check == true && i == 1)
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            newGame(gameTime);
                        }
                    }

                    else if (check == true && i == 2)
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            
                        }
                    }

                    else if (check == true && i == 3)
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            this.Exit();
                        }
                    }
                }
            }

            if (gameInit == false)
            {
                Vector3 translation = new Vector3(Mouse.GetState().X, 0, -Mouse.GetState().Y);

                //UpdateInput(translation, (graphics.GraphicsDevice.Viewport.X / 2) + Mouse.GetState().X, (graphics.GraphicsDevice.Viewport.Y / 2) + Mouse.GetState().Y);

                ProcessInput(timeDifference);

                UpdateViewMatrix();

                effect.View = viewMatrix;

                Mouse.SetPosition(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);
            }

            base.Update(gameTime);
        }

        // Variable that controls positive and negative camera rotation.
        public static int rotationVar = 1;

        // Set the position of the model in world space, and set the rotation.
        public Vector3 modelPosition = new Vector3(0, 0, -800);
        //public Vector3 modelPosition = Vector3.Zero;
        public float modelRotation = 0.0f;

        // Set the "Look At" point for the camera. Edited in 'UpdateCamera()' function.
        public Vector3 lookAtPosition = Vector3.Zero;

        // Set the direction the camera points without rotation.
        public static Vector3 cameraReference = new Vector3(0, 0, 1);

        // Matrix for Camera Rotation. X axis.
        public static Matrix rotationMatrixX = Matrix.CreateRotationX(MathHelper.ToRadians(45));

        // Matrix for Camera Rotation. Z axis.
        public static Matrix rotationMatrixZPos = Matrix.CreateRotationZ(MathHelper.ToRadians(45));

        // Matrix for Camera Rotation. Z axis.
        public static Matrix rotationMatrixZNeg = Matrix.CreateRotationZ(MathHelper.ToRadians(-45));

        // Create a vector pointing the direction the camera is facing.
        public Vector3 transformedReferenceX = Vector3.Transform(cameraReference, rotationMatrixX);

        // Create a vector pointing the direction the camera is facing.
        public Vector3 transformedReferenceZPos = Vector3.Transform(cameraReference, rotationMatrixZPos);

        // Create a vector pointing the direction the camera is facing.
        public Vector3 transformedReferenceZNeg = Vector3.Transform(cameraReference, rotationMatrixZNeg);

        // Set the velocity for the model
        public Vector3 modelVelocity = Vector3.Zero;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);

            spriteBatch.Begin();

            if (gameInit == true)
            {
                m.Draw(spriteBatch);
            }

            if (gameInit == false)
            {
                for (int i = 0; i < 20; i++)
                {
                    // Copy any parent transforms.
                    Matrix[] transforms = new Matrix[house.Bones.Count];
                    house.CopyAbsoluteBoneTransformsTo(transforms);

                    // Draw the model. A model can have multiple meshes, so loop.
                    foreach (ModelMesh mesh in house.Meshes)
                    {
                        // This is where the mesh orientation is set, as well as our camera and projection.
                        foreach (BasicEffect effect in mesh.Effects)
                        {
                            this.effect = effect;

                            effect.EnableDefaultLighting();
                            effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(modelRotation)
                                * Matrix.CreateTranslation(new Vector3(0, 0, -1200 - (i * 1000)));
                            effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1f, 5000f);
                            effect.LightingEnabled = true;
                            effect.Alpha = 1.0f;
                        }
                        // Draw the mesh, using the effects set above.
                        mesh.Draw();
                    }
                }
}

            if (drawCursor == true)
            {
                cursor.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void newGame(GameTime gameTime)
        {
            gameInit = false;
            drawCursor = false;

            LoadContent();

            Draw(gameTime);
        }


        protected void createHUD()
        {

        }


        private void ProcessInput(float amount)
        {
            //MouseState currentMouseState = Mouse.GetState();
            //if (currentMouseState != originalMouseState)
            //{
            //    float xDifference = currentMouseState.X - originalMouseState.X;
            //    float yDifference = currentMouseState.Y - originalMouseState.Y;
            //    pitch += xDifference * rotationSpeed * amount;
            //    yaw -= yDifference * rotationSpeed * amount;
            //    //leftrightRot = yDifference * amount;
            //    //updownRot = xDifference * amount;
            //    //leftrightRot -= rotationSpeed * xDifference * amount;
            //    //updownRot -= rotationSpeed * yDifference * amount;
            //    Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            //    UpdateViewMatrix();
            //}

            Vector3 moveVector = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                pitch += rotationSpeed;
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                pitch -= rotationSpeed;
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                yaw += rotationSpeed;
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                yaw -= rotationSpeed;
            if (keyState.IsKeyDown(Keys.Q))
                cameraPosition += new Vector3(0, 1, 0);
            if (keyState.IsKeyDown(Keys.Z))
                cameraPosition += new Vector3(0, -1, 0);
            if (keyState.IsKeyDown(Keys.Escape))
                Exit();

            AddToCameraPosition(moveVector * amount);
        }

        private void AddToCameraPosition(Vector3 vectorToAdd)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            cameraPosition += moveSpeed * rotatedVector;
            UpdateViewMatrix();
        }

        private void UpdateViewMatrix()
        {
            // Calculate the camera's current position.
            Vector3 cameraPosition = Vector3.Zero;

            Matrix rotationMatrixY = Matrix.CreateRotationY(yaw);
            Matrix rotationMatrixX = Matrix.CreateRotationX(pitch);

            Matrix cameraRotation = rotationMatrixX * rotationMatrixY;

            // Create a vector pointing the direction the camera is facing.
            Vector3 transformedReference = Vector3.Transform(cameraReference, cameraRotation);

            // Calculate the position the camera is looking at.
            Vector3 cameraLookat = cameraPosition + transformedReference;

            // Set up the view matrix and projection matrix.
            viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraLookat, new Vector3(0.0f, 1.0f, 0.0f));

            //Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);

            //Vector3 cameraOriginalTarget = modelPosition;
            //Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);

            //Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            //Vector3 cameraFinalTarget = cameraRotatedTarget;

            //Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            //viewMatrix = Matrix.CreateLookAt(cameraPosition, modelPosition, cameraRotatedUpVector);
        }
    }
}
