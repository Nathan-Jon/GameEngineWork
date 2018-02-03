using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Entities;
namespace EngineV2.Managers
{
    /// <summary>
    /// Factory for the creation and initialisation of Entites
    /// Author: Nathan Robertson
    /// Edit Date: 03/02/18
    /// </summary>
    public sealed class EntityManager : IEntityManager
    {
        public static List<IEntity> Entities = new List<IEntity>();
        private static IEntityManager instance = null;
        private static object syncInstance = new object();

        public EntityManager()
        {
          
        }

        /// <summary>
        /// Returns an instance of the IEntityManager interface
        /// </summary>
        public static IEntityManager getEntityManager
        {
           get
            {
                if (instance == null)
                {
                    //Ensures only one class can access this if statement at a time
                    lock (syncInstance)
                        if (instance == null)
                            instance = new EntityManager();
                }

                return instance;

            }
        }


        /// <summary>
        /// Factory for the creation of entities - Passes 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <param name="phys"></param>
        /// <param name="IBehave"></param>
        /// <returns></returns>
        public T CreateEnt<T>(Texture2D text, Vector2 Posn, ICollidable col, IPhysicsObj phys, IBehaviourManager IBehave) where T : IEntity, new()
        {
            T Ent = new T();
            Ent.Initialize(text, Posn, col, phys, IBehave);
            AddEnt(Ent);
            return Ent;      
        }

        /// <summary>
        /// Adds an object of type IEntity to the Entities list
        /// </summary>
        /// <param name="Ent"></param>
        public void AddEnt(IEntity Ent)
        {
            Entities.Add(Ent);
        }

        /// <summary>
        /// Removes an object of type IEntity from the Entities list
        /// </summary>
        /// <param name="Ent"></param>
        public void RemoveEnt(IEntity Ent)
        {
            Entities.Remove(Ent);
        }


    }
}
