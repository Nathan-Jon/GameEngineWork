using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    class SceneManager : DrawableGameComponent, ISceneManager


    {
        
        public static List<IEntity> onScnEnts = new List<IEntity>();
         List<IEntity> SceneGraph = new List<IEntity>();
        List<Texture2D> Scenes = new List <Texture2D>();

        IEntity Entities;
        SpriteBatch spriteBatch;
        ICollisionManager coli;
        IBehaviourManager behaviours;
        IInputManager input;

        public SceneManager(Game game) : base(game)
        {
            
        }

        public void Initalize(IEntity ent, ICollisionManager col, IBehaviourManager behav, IInputManager imp)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Entities = ent;
            coli = col;
            input = imp;
            behaviours = behav;

            SceneGraph.Add(Entities);
            
        }

        public override void Update(GameTime gameTime) 
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }


            coli.Update();
            input.Update();

            for (int i = 0; i < SceneGraph.Count; i++)
            {
                SceneGraph[i].update();
            }
            behaviours.update();

            base.Update(gameTime);

        }

        public void addScn(Texture2D Scene)
        {
            Scenes.Add(Scene);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            spriteBatch.Begin();

            for (int i = 0; i < SceneGraph.Count; i++)
            {
                onScnEnts = SceneGraph;
                onScnEnts[i].Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);

        }

    }
}
