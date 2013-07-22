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
    class DrawHouses
    {
        public DrawHouses(Game1 g, Model m)
        {
            for (int z = 0; z < 9; z++)
            {
                for (int x = 0; x < 9; x++)
                {
                    DrawModel(m, Matrix.CreateTranslation(x * 1000, 0, z * 1000), g);
                }
            }
        }

        public void DrawModel(Model model, Matrix world, Game1 g)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    

                    be.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, g.GraphicsDevice.Viewport.AspectRatio, 1f, 5000f);
                    be.View = g.viewMatrix;
                    be.World = world;
                }
                mesh.Draw();
            }
        }
    }
}
