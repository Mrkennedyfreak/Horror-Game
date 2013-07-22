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
    class Menu
    {
        Game1 g;

        /*
         *  Rectangles for the placement of the buttons. Used to test for the mouse cursor inside of these rectangles.
         */
        Rectangle NewGameButtonRect;
        Rectangle OptionsButtonRect;
        Rectangle ExitGameButtonRect;

        ContentManager Content;

        GameMenuButton NewGameButton, OptionsButton, ExitGameButton;


        public Menu(ContentManager Content)
        {
            this.Content = Content;

            NewGameButtonRect = new Rectangle(75, 475, 125, 50);
            OptionsButtonRect = new Rectangle(75, 550, 125, 50);
            ExitGameButtonRect = new Rectangle(75, 625, 125, 50);

            NewGameButton = new GameMenuButton(Content);
            OptionsButton = new GameMenuButton(Content);
            ExitGameButton = new GameMenuButton(Content);
        }

        public Menu(ContentManager Content, String MenuName)
        {
            if (MenuName == "pause")
            {

            }
        }

        Texture2D Background2;
        Texture2D Background1;
        Texture2D foreground;

        Vector2 Background2Pos = Vector2.Zero;


        public void MenuContent(ContentManager Content, SpriteBatch spriteBatch)
        {
            Background2 = Content.Load<Texture2D>("Menu Content\\Background2");

            //NewGameButton.createButton(spriteBatch, NewGameButtonRect, "NewGameButton");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            NewGameButton.createButton(spriteBatch, NewGameButtonRect, "Menu Content\\NewGameButton");
            OptionsButton.createButton(spriteBatch, OptionsButtonRect, "Menu Content\\OptionsButton");
            ExitGameButton.createButton(spriteBatch, ExitGameButtonRect, "Menu Content\\ExitGameButton");
            
            //spriteBatch.Draw(Background2, new Rectangle(0, 0, 1600, 900), Color.White);
        }

        public Boolean checkMenu(int i)
        {
            if (i == 1)
            {
                if (NewGameButton.getMouseListener(NewGameButtonRect) == true)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            if (i == 2)
            {
                if (OptionsButton.getMouseListener(OptionsButtonRect) == true)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            if (i == 3)
            {
                if (ExitGameButton.getMouseListener(ExitGameButtonRect) == true)
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

        public int getButtonCount()
        {
            return 3;
        }
    }
}
