using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using ProjectHastings.Buttons;
using Engine.BackGround;
using Engine.Managers;
using Engine.Interfaces;

namespace ProjectHastings.Scenes
{
    class WinGame : IScene
    {

        IButton ExitBut;
        IBackGrounds back;
        MouseState mouseinput;
        Point mousePosition;


        public WinGame()
        {

            back = new BackGrounds(900, 600);
            ExitBut = new ExitButton();
        }


        public void LoadContent(ContentManager Content)
        {
            back.Initialize("WinGameBackground" ,Content.Load<Texture2D>("WinGameBackground"));
            ExitBut.Initialize(Content.Load<Texture2D>("Exit Button"), new Vector2(355, 300));

        }

        public void update(GameTime gameTime)
        {
            ExitBut.update();
            mouseinput = Mouse.GetState();
            mousePosition = new Point(mouseinput.X, mouseinput.Y);


            if (ExitBut.HitBox.Contains(mousePosition) && mouseinput.LeftButton == ButtonState.Pressed)
            {
                ExitBut.click();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            back.Draw(spriteBatch);
            ExitBut.Draw(spriteBatch);
        }
    }
}
