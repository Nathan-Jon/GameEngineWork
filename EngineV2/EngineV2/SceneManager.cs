using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    class SceneManager : ISceneManager
        
    {
        
        List<IEntity> onScnEnts = new List<IEntity>();
        List<IEntity> SceneGraph = new List<IEntity>();
        
        IEntity Entities;
        SpriteBatch sprt;
        ICollisionManager coli;
        IBehaviourManager behaviours;

        public void Initalize(IEntity ent, SpriteBatch spriteBatch, ICollisionManager col, IBehaviourManager behav)
        {
            Entities = ent;
            sprt = spriteBatch;
            coli = col;
            behaviours = behav;
            SceneGraph.Add(Entities);
            
        }

        public void Update() 
        {
            coli.Update();

            for (int i = 0; i < SceneGraph.Count; i++)
            {
                SceneGraph[i].update();
            }
            behaviours.update();
        }

        public void Draw()
        {
            for (int i = 0;  i < SceneGraph.Count ; i++)
            {
                SceneGraph[i].Draw(sprt);
                onScnEnts.Add(Entities);

                
            }      
            
        }

        public void RemoveEnt(IEntity Ent)
        {
            onScnEnts.Remove(Ent);
        }

    }
}
