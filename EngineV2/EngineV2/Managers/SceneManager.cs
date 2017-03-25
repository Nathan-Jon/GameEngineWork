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
    class SceneManager : ISceneManager
        
    {
        
        public static List<IEntity> onScnEnts = new List<IEntity>();
        List<IEntity> SceneGraph = new List<IEntity>();
        List<Texture2D> Scenes = new List <Texture2D>();

        IEntity Entities;
        SpriteBatch sprt;
        ICollisionManager coli;
        IBehaviourManager behaviours;
        IInputManager input;

        public void Initalize(IEntity ent, SpriteBatch spriteBatch, ICollisionManager col, IBehaviourManager behav, IInputManager imp)
        {
            Entities = ent;
            sprt = spriteBatch;
            coli = col;
            input = imp;
            behaviours = behav;
            SceneGraph.Add(Entities);
            
        }

        public void Update() 
        {
            coli.Update();
            input.Update();

            for (int i = 0; i < SceneGraph.Count; i++)
            {
                SceneGraph[i].update();
            }
            behaviours.update();

        }

        public void addScn(Texture2D Scene)
        {
            Scenes.Add(Scene);
        }

        public void Draw()
        {
            sprt.Draw(Scenes[0], new Rectangle(0, 0, 900, 600), Color.AntiqueWhite);
            for (int i = 0;  i < SceneGraph.Count ; i++)
            {
                onScnEnts = SceneGraph;
                onScnEnts[i].Draw(sprt);
            }      
            if (CollisionManager.Hit == true)
            {
                CollisionManager.Hit = false;
                if (Scenes.Count == 2)
                {
                onScnEnts.Clear();
                Scenes.Remove(Scenes[0]);
                }
                if (Scenes.Count == 1)
                {
                    sprt.Draw(Scenes[0], new Rectangle(0, 0, 900, 600), Color.AntiqueWhite);
                }
                
                
            }
            
        }

    }
}
