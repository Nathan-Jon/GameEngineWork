using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using EngineV2.Interfaces;
using EngineV2.Input;
using EngineV2.Collision_Management;
using EngineV2.BackGround;
using EngineV2.Scenes;

namespace EngineV2.Managers
{
    class SceneManager : DrawableGameComponent, ISceneManager


    {
        List<IBehaviour> behaviours = new List<IBehaviour>();
        List<IEntity> SceneGraph = new List<IEntity>();
        public static List<IAnimationMgr> animationlist = new List<IAnimationMgr>();

        SpriteBatch spriteBatch;
        InputManager input;
        CollisionManager coli;
        IPhysicsMgr physicsMgr;
        static IBackGrounds background;
        IScene scn;

        public static bool Level1 = true;

        public SceneManager(Game game, InputManager inp, CollisionManager collision, IPhysicsMgr physUp, IScene scene) : base(game)
        {
            input = inp;
            coli = collision;
            physicsMgr = physUp;
            scn = scene;
        }

        public SceneManager(Game game, InputManager inp, CollisionManager collision, IPhysicsMgr physUp)
            : base(game)
        {
            input = inp;
            coli = collision;
            physicsMgr = physUp;
        }

        public void Initalize(IAnimationMgr ani, IBackGrounds back, ISoundManager sound)
        {

            background = back;
            behaviours = BehaviourManager.behaviours;
            animationlist.Add(ani);
            SceneGraph = EntityManager.Entities;
            
        }

        public override void Update(GameTime gameTime) 
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }

            if (Kernel.StartGame == true)
            {
                scn.update(gameTime);
            }

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
           

            spriteBatch.Begin();

            if (Level1 == true)
            {
                scn.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);

        }

    }
}
