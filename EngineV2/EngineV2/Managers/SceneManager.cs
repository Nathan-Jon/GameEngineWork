using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Input;
using EngineV2.Collision_Management;
using EngineV2.BackGround;

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
        IBackGrounds background;

        public SceneManager(Game game, InputManager inp, CollisionManager collision, IPhysicsMgr physUp) : base(game)
        {
            input = inp;
            coli = collision;
            physicsMgr = physUp;

        }

        public void Initalize(IAnimationMgr ani, IBackGrounds back)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

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

            input.update();
            coli.update();

            for (int i = 0; i < SceneGraph.Count; i++)
            {
                SceneGraph[i].update();
            }

            for (int i = 0; i < animationlist.Count; i++)
            {

                animationlist[i].Update(gameTime);
            }

            for (int i = 0; i < behaviours.Count; i++)
            {

                behaviours[i].update();
            }

            physicsMgr.update();

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            spriteBatch.Begin();

            background.Draw(spriteBatch);

            for (int i = 2; i < SceneGraph.Count; i++)
            {
                SceneGraph[i].Draw(spriteBatch);
            }

            for (int i = 0; i < animationlist.Count; i++)
            {
                animationlist[i].Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);

        }

    }
}
