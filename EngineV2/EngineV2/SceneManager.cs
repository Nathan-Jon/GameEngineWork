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
        IEntity Entities;
        SpriteBatch sprt;
        public void Initalize(IEntity ent, SpriteBatch spriteBatch)
        {
            Entities = ent;
            sprt = spriteBatch;
        }

        public void Update() 
        {
            onScnEnts.Add(Entities);
            Entities.update();
        }

        public void Draw()
        {
            Entities.Draw(sprt);
        }

        public void AddEnt(IEntity Ent)
        {
            onScnEnts.Add(Ent);
        }

        public void RemoveEnt(IEntity Ent)
        {
            onScnEnts.Remove(Ent);
        }

    }
}
