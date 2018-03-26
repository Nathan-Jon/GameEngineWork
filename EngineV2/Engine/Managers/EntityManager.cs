using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;
namespace Engine.Managers
{
    /// <summary>
    /// Factory for the creation and initialisation of Entites
    /// Author: Nathan Robertson
    /// Edit Date: 03/02/18
    /// </summary>
    public sealed class EntityManager : IEntityManager
    {
        public static IList<IEntity> Entities;

        public EntityManager()
        {
            Entities = new List<IEntity>();

        }

        public void ListClear()
        {
            Entities.Clear();
        }

        /// <summary>
        /// Factory for the creation of entities - Passes 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <param name="phys"></param>
        /// <param name="IBehave"></param>
        /// <returns></returns>
        public T CreateEnt<T>(Texture2D text, Vector2 posn, ICollidable col, IBehaviourManager behave) where T : IEntity, new()
        {
            //Create a new object of type T
            T Ent = new T();
            //Call the Initialise Method of Type T
            Ent.Initialize(text, posn, col, behave);
            //Add the object to a list of entities
            Entities.Add(Ent);
            return Ent;
        }

    }
}
