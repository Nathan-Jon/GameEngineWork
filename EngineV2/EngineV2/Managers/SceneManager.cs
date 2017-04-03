using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Input;

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
        InputManager input;
        InputPublisher inpUpdate;

        public SceneManager(Game game, InputManager inp) : base(game)
        {
            input = inp;
        }

        public void Initalize(IEntity ent, ICollisionManager col, IBehaviourManager behav)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Entities = ent;
            coli = col;
            behaviours = behav;
            SceneGraph.Add(Entities);
            
        }

        public override void Update(GameTime gameTime) 
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }

            input.update();
            coli.Update();

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
