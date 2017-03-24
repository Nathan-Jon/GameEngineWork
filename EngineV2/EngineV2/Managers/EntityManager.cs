using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    class EntityManager : IEntityManager
    {
        public List<IEntity> Entities = new List<IEntity>();
        
        
        public T CreateEnt<T>() where T : IEntity, new()
        {
            T Ent = new T();
            AddEnt(Ent);
            return Ent;      
        }

        public void AddEnt(IEntity Ent)
        {
            Entities.Add(Ent);
        }

        public void RemoveEnt(IEntity Ent)
        {
            Entities.Remove(Ent);
        }


    }
}
