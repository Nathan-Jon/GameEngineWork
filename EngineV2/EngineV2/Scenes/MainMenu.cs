using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using EngineV2.Buttons;
using EngineV2.BackGround;
using EngineV2.Managers;
using EngineV2.Interfaces;
using Microsoft.Xna.Framework.Audio;

namespace EngineV2.Scenes
{
    class MainMenu : IScene
    {
        public static List<IButton> Buttons = new List<IButton>();
        IButton StartBut, ResumeBut, ExitBut;
        IBackGrounds back;
        ButtonList buttonlist;
        MouseState mouseinput;
        Point mousePosition;

        public MainMenu()
        {
            
            back = new BackGrounds(900, 600);
            StartBut = new StartButton();
            ResumeBut = new ResumeButton();
            ExitBut = new ExitButton();
            buttonlist = new ButtonList();
            

        }

        public void LoadContent(ContentManager Content)
        {
            SoundManager.getSoundInstance.Initialize("MainMenu" ,Content.Load<SoundEffect>("MenuMusic"));
            SoundManager.getSoundInstance.CreateInstance();


            back.Initialize("Menu" ,Content.Load<Texture2D>("MenuBackground"));

            StartBut.Initialize(Content.Load<Texture2D>("Start Button"), new Vector2(25, 400));
            ExitBut.Initialize(Content.Load<Texture2D>("Exit Button"), new Vector2(25, 500));

            Buttons = ButtonList.menuButtons;
            buttonlist.Initalize(StartBut);
            buttonlist.Initalize(ExitBut);

        }

        public void update(GameTime gameTime)
        {
            

            if (SceneManager.mainmenu == true)
            {
                for (int i = 0; i < Buttons.Count; i++)
                {
                    Buttons[i].update();
                }
                mouseinput = Mouse.GetState();
                mousePosition = new Point(mouseinput.X, mouseinput.Y);


                if (Buttons[0].getHitbox().Contains(mousePosition) && mouseinput.LeftButton == ButtonState.Pressed)
                {
                    Buttons[0].click();
                }
                if (Buttons[1].getHitbox().Contains(mousePosition) && mouseinput.LeftButton == ButtonState.Pressed)
                {
                    Buttons[1].click();
                }


            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                back.Draw(spriteBatch);
                for (int i = 0; i < Buttons.Count; i++)
                {
                    Buttons[i].Draw(spriteBatch);
                }
        }
    }
}
