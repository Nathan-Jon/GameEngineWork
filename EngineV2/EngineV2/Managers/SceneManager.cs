using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Collision_Management;
using EngineV2.BackGround;
using EngineV2.Input_Managment;
using EngineV2.Scenes;

namespace EngineV2.Managers
{
    class SceneManager : DrawableGameComponent, ISceneManager


    {
        List<IBehaviour> behaviours = new List<IBehaviour>();
        List<IEntity> SceneGraph = new List<IEntity>();
        public static List<IScene> SceneList;

        SpriteBatch spriteBatch;
        InputManager inputMgr;
        IPhysicsMgr physicsMgr;
        static IBackGrounds background;

        public static bool WinGame = false;
        public static bool Level1 = false;
        public static bool mainmenu = true;
        public static bool ExitGame = false;
        public static bool LoseScreen = false;

        public SceneManager(Game game) : base(game)
        {
            inputMgr = InputManager.GetInputInstance;
            physicsMgr = PhysicsManager.getPhysicsInstance;
            
        }

        public SceneManager(Game game, List<IScene> scenelist)
            : base(game)
        {
            inputMgr = InputManager.GetInputInstance;
            physicsMgr = PhysicsManager.getPhysicsInstance;
            SceneList = scenelist;
        }


        public void Initalize(IBackGrounds back, ISoundManager sound)
        {

            background = back;
            behaviours = BehaviourManager.behaviours;
            SceneGraph = EntityManager.Entities;
            
        }

        public override void Update(GameTime gameTime) 
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            Game.Exit();

            if (ExitGame == true)
            {
                Game.Exit();
            }

            if (mainmenu == true)
            {
                SceneList[0].update(gameTime);
            }

            if (Level1 == true)
            {
                SceneList[1].update(gameTime);
            }

            if (WinGame == true)
            {
                SceneList[2].update(gameTime);
            }
            if (LoseScreen == true)
            {
                SceneList[3].update(gameTime);
            }
            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
           

            spriteBatch.Begin();
            if (mainmenu == true)
            {
                SceneList[0].Draw(spriteBatch);
            }

            if (Level1 == true)
            {
                SceneList[1].Draw(spriteBatch);
            }

            if (WinGame == true)
            {
                SceneList[2].Draw(spriteBatch);
            }

            if (LoseScreen == true)
            {
                SceneList[3].Draw(spriteBatch);
            }


            spriteBatch.End();
            base.Draw(gameTime);

        }

    }
}
