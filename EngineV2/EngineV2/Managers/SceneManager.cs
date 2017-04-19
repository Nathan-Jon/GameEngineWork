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

namespace EngineV2.Managers
{
    class SceneManager : DrawableGameComponent, ISceneManager


    {
        
        List<IEntity> onScnEnts = new List<IEntity>();
        List<IEntity> SceneGraph = new List<IEntity>();
        public static List<IAnimationMgr> animationlist = new List<IAnimationMgr>();

        IEntity Entities;
        SpriteBatch spriteBatch;
        IBehaviourManager behaviours;
        InputManager input;
        CollisionManager coli;
        IPhysicsMgr physicsMgr;
        InputPublisher inpUpdate;
        IAnimationMgr animation;

        public SceneManager(Game game, InputManager inp, CollisionManager collision, IPhysicsMgr physUp) : base(game)
        {
            input = inp;
            coli = collision;
            physicsMgr = physUp;

        }

        public void Initalize(IEntity ent, IBehaviourManager behav, IAnimationMgr ani)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Entities = ent;
            behaviours = behav;
            animation = ani;
            animationlist.Add(ani);
            SceneGraph.Add(ent);

            SceneGraph.Add(Entities);
            
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

            behaviours.update();
            physicsMgr.update();

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            spriteBatch.Begin();

            for (int i = 4; i < SceneGraph.Count; i++)
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
