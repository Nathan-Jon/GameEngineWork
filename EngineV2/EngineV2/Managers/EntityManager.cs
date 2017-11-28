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
    public sealed class EntityManager : IEntityManager
    {
        public static List<IEntity> Entities = new List<IEntity>();

        private static EntityManager instance = null;
        private static object syncInstance = new object();

        public EntityManager()
        {

        }

        public static IEntityManager getEntityManager
        {
           get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                        if (instance == null)
                            instance = new EntityManager();
                }

                return instance;

            }
        }
        
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
