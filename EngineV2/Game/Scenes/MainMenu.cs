using System.Collections.Generic;
using Engine.BackGround;
using Engine.Buttons;
using Engine.Interfaces;
using Engine.Managers;
using Engine.Service_Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectHastings.Buttons;

namespace ProjectHastings.Scenes
{
    class MainMenu : IScene
    {
        public static List<IButton> Buttons = new List<IButton>();
        IButton StartBut, ResumeBut, ExitBut;
        IBackGrounds back;
        ButtonList buttonlist;
        MouseState mouseinput;
        Point mousePosition;

        ISoundManager sound = Locator.Instance.getProvider<SoundManager>() as ISoundManager;

        public MainMenu()
        {
            
            back = new BackGrounds(900, 600);
            StartBut = new StartButton();
            ExitBut = new ExitButton();
            buttonlist = new ButtonList();
            

        }

        public void LoadContent(ContentManager Content)
        {
            sound.Initialize("MainMenuMusic" ,Content.Load<SoundEffect>("MainMenuMusic"));
            sound.CreateInstance();


            back.Initialize("Menu" ,Content.Load<Texture2D>("MainMenuBackground"));

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


                if (Buttons[0].HitBox.Contains(mousePosition) && mouseinput.LeftButton == ButtonState.Pressed)
                {
                    Buttons[0].click();
                }
                if (Buttons[1].HitBox.Contains(mousePosition) && mouseinput.LeftButton == ButtonState.Pressed)
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
