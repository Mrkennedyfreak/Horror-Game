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
    class GameMenuButton
    {
        ContentManager Content;

        int x;
        int y;
        int width;
        int height;

        /*
         *  Constructor sets this.ContentManger equal to the Game1 ContentManager 
         */
        public GameMenuButton(ContentManager Content)
        {
            this.Content = Content;
        }





        /*
         *  createButton function creates the button to be drawn and places it at the designated x and y coordinates and with the designated width and heightd
         *  
         *  Args: spriteBatch, x, y, width, height, texture
         */
        public Boolean createButton(SpriteBatch spriteBatch, int x, int y, int width, int height, String texture)
        {
            Texture2D calledTexture = Content.Load<Texture2D>("Menu Content\\" + texture);

            spriteBatch.Begin();
            spriteBatch.Draw(calledTexture, new Rectangle(x, y, width, height), Color.White);
            spriteBatch.End();

            this.createMouseListener(x, y, width, height);

            return true;
        }


        /*
         *  createButton function creates the button to be drawn and places it at the designated x and y coordinates and with the designated width and heightd
         *  
         *  Args: spriteBatch, rectangle, texture
         */
        public Boolean createButton(SpriteBatch spriteBatch, Rectangle r, String texture)
        {
            Texture2D calledTexture = Content.Load<Texture2D>(texture);

            spriteBatch.Draw(calledTexture, r, Color.White);

            this.createMouseListener(r);

            return true;
        }






        /*
         *  createMouseListener function creates the MouseListener for the button
         *  
         *  Args: x, y, width, height
         */
        public void createMouseListener(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }


        /*
         *  createMouseListener function creates the MouseListener for the button
         *  
         *  Args: rectangle
         */
        public void createMouseListener(Rectangle r)
        {
            this.x = r.X;
            this.y = r.Y;
            this.width = r.Width;
            this.height = r.Height;
        }






        public Boolean getMouseListener(int x, int y, int width, int height)
        {
            if (Mouse.GetState().X >= x && Mouse.GetState().X <= x + width)
            {
                if (Mouse.GetState().Y >= y && Mouse.GetState().Y <= y + height)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        public Boolean getMouseListener(Rectangle r)
        {
            if (Mouse.GetState().X >= r.X && Mouse.GetState().X <= r.X + r.Width)
            {
                if (Mouse.GetState().Y >= r.Y && Mouse.GetState().Y <= r.Y + r.Height)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }
    }
}
