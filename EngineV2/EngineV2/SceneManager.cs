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

        public void Update() 
        {

        }

        public void Draw(IEntity Entity, Vector2 Posn)
        {


            spriteBatch.Draw(, Posn, Color.AntiqueWhite);
            AddEnt(Ent);
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
