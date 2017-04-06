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

        IEntity Entities;
        SpriteBatch spriteBatch;
        IBehaviourManager behaviours;
        InputManager input;
        CollisionManager coli;
        InputPublisher inpUpdate;
        IAnimationMgr animation;

        public SceneManager(Game game, InputManager inp, CollisionManager collision) : base(game)
        {
            input = inp;
            coli = collision;
        }

        public void Initalize(IEntity ent, IBehaviourManager behav, IAnimationMgr ani)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Entities = ent;
            behaviours = behav;
            animation = ani;
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
            animation.Update(gameTime);
            behaviours.update();

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            spriteBatch.Begin();

            animation.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);

        }

    }
}
