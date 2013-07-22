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
    class DrawMouseCursor
    {
        ContentManager Content;
        SpriteBatch spriteBatch;

        Texture2D CursorTexture;

        public DrawMouseCursor(Boolean enabled, SpriteBatch spriteBatch, ContentManager Content)
        {
            this.Content = Content;
            this.spriteBatch = spriteBatch;

            CursorTexture = Content.Load<Texture2D>("Menu Content\\Cursor");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CursorTexture, new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 15, 30), Color.White);
        }
    }
}
