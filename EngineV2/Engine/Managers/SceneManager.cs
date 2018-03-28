using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;
using Engine.Render;
using Engine.Service_Locator;

namespace Engine.Managers
{
    public class SceneManager : DrawableGameComponent, ISceneManager
    {


        IDictionary<string, IScene> Scenes = new Dictionary<string, IScene>();
        SpriteBatch spriteBatch;
        IRenderable render;

        public static bool WinGame = false;
        public static bool TestLevel = true;
        public static bool mainmenu = false;
        public static bool ExitGame = false;
        public static bool LoseScreen = false;

        ISoundManager sound = Locator.Instance.getProvider<SoundManager>() as ISoundManager;

        public SceneManager(Game game) : base(game)
        {

        }

        public SceneManager(Game game, IDictionary<string, IScene> scenes)
            : base(game)
        {
            render = new Renderable();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Scenes = scenes;
            render.Initalise(Scenes, spriteBatch);
        }


        public override void Update(GameTime gameTime) 
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            Game.Exit();

            render.Draw();

            if (ExitGame == true)
            {
                Game.Exit();
            }

            if (mainmenu == true)
            {
                Scenes["Mainmenu"].update(gameTime);
                
            }

            if (TestLevel == true)
            {
                Scenes["TestLevel"].update(gameTime);
                
            }

            if (WinGame == true)
            {
                
                Scenes["Wingame"].update(gameTime);
            }
            if (LoseScreen == true)
            {
                
                Scenes["LoseScreen"].update(gameTime);
                sound.Playsnd("MyHeartWillGoOn", 1.0f);
            }
            base.Update(gameTime);

        }

    }
}
