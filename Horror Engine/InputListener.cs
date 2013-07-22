using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Horror_Engine
{
    class InputListener
    {
        //Menu pauseMenu;

        //float moveSpeed = Game1.moveSpeed;

        //public Vector3 position;
        //public Vector3 target;

        //public static Vector3 cameraReference = new Vector3(0, 0, 1);

        

        //float leftrightRot;
        //float updownRot;

        //public float rotationSpeed = 0.05f;
        //public float translationSpeed = 1f;

        //public MouseState originalMouseState;

         
        
        ////public void UpdateViewMatrix(Game1 g)
        ////{
        ////    Matrix cameraRotation = Matrix.CreateRotationX(g.upDownRotation) * Matrix.CreateRotationY(g.leftRightRotation);

        ////    Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
        ////    Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
        ////    Vector3 cameraFinalTarget = g.cameraPosition + cameraRotatedTarget;

        ////    Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
        ////    Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

        ////    //viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        ////}


        //public void UpdateCamera(Game1 g, Vector3 translation, float leftRightRot, float upDownRot)
        //{
        //    int currentMouseStateX = Mouse.GetState().X;
        //    int currentMouseStateY = Mouse.GetState().Y;





        //    //Console.WriteLine("Current " + currentMouseState.ToString());
        //    //Console.WriteLine("Original " + originalMouseState.ToString());

        //    if (currentMouseStateX != originalMouseState.X || currentMouseStateY != originalMouseState.Y)
        //    {
        //        Console.WriteLine("CurrentMouseState did NOT equal OriginalMouseState");
        //        this.leftrightRot = currentMouseStateX / (float)Math.PI / 4;
        //        Console.WriteLine(this.leftrightRot);
        //        this.updownRot = currentMouseStateY / (float)Math.PI / 4;
        //        Console.WriteLine(this.updownRot);
        //        Matrix rotationMatrix = Matrix.CreateRotationX(this.updownRot) * Matrix.CreateRotationY(this.leftrightRot);
        //        Vector3 transformedReference = Vector3.Transform(cameraReference, rotationMatrix);
        //        position += Vector3.Transform(translation, rotationMatrix) * translationSpeed;
        //        target = transformedReference + position;

        //        //UpdateViewMatrix(g);
        //    }


        //    originalMouseState = Mouse.GetState();
        //}

        
        //public void UpdateInput(float amount, Game1 g, float rotationSpeed, GraphicsDevice device)
        //{

        //    //MouseState currentMouseState = Mouse.GetState();
        //    //if (currentMouseState != originalMouseState)
        //    //{
        //    //    this.leftrightRot += leftrightRot * rotationSpeed;
        //    //    this.updownRot += updownRot * rotationSpeed;
        //    //    Matrix rotationMatrix = Matrix.CreateRotationX(this.updownRot) * Matrix.CreateRotationY(this.leftrightRot);
        //    //    Vector3 transformedReference = Vector3.Transform(g.cameraReference, rotationMatrix);
        //    //    position += Vector3.Transform(translation, rotationMatrix) * translationSpeed;
        //    //    target = transformedReference + position;

        //    //    UpdateViewMatrix();
        //    //}

        //    Vector3 moveVector = new Vector3(0, 0, 0);
        //    KeyboardState keyState = Keyboard.GetState();
        //    if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
        //        g.updownRot += 10;
                
        //        //moveVector += new Vector3(0, 0, -1);
        //    if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
        //        g.updownRot -= 10;
                
        //        //moveVector += new Vector3(0, 0, 1);
        //    if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
        //        g.leftrightRot += 10;

        //        //moveVector += new Vector3(1, 0, 0);
        //    if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
        //        g.leftrightRot -= 10;

        //        //moveVector += new Vector3(-1, 0, 0);
        //    if (keyState.IsKeyDown(Keys.Q))
        //        moveVector += new Vector3(0, 1, 0);
        //    if (keyState.IsKeyDown(Keys.Z))
        //        moveVector += new Vector3(0, -1, 0);

        //    if (keyState.IsKeyDown(Keys.Escape))
        //        g.Exit();

        //    //if (keyState.IsKeyDown(Keys.Enter))
        //        //g.viewMatrix = Matrix.CreateLookAt(g.cameraPosition, g.lookAtPosition, Vector3.Up);

        //    AddToCameraPosition(moveVector * amount, g);
        //}

        //private void AddToCameraPosition(Vector3 vectorToAdd, Game1 g)
        //{
        //    Matrix cameraRotation = Matrix.CreateRotationX(g.updownRot) * Matrix.CreateRotationY(g.leftrightRot);
        //    //Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
        //    Vector3 rotatedVector = Vector3.Zero;
        //    //position += moveSpeed * rotatedVector;
        //    UpdateViewMatrix();
        //}
    }
}
