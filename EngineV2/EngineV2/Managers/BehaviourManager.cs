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
    public sealed class BehaviourManager: IBehaviourManager
    {

        public static List<IBehaviour> behaviours = new List<IBehaviour>();


        private static IBehaviourManager instance = null;
        private static object syncnstance = new object();

        //constructor
        public BehaviourManager()
        { }

        /// <summary>
        /// Returns an instance of the Behavious Manager Interface
        /// </summary>
        public static IBehaviourManager getBehaviourManager
        {
            get
            {
                //Ensures only one class can access this if statement at a time
                if (instance == null)
                {
                    lock (syncnstance)
                        if (instance == null)
                            instance = new BehaviourManager();
                }
                return instance;
            }
        }

       
        /// <summary>
        /// loops through the behaviours list, running the update methods on the objects contained
        /// </summary>
        public void update()
        {
            for (int i = 0;i < behaviours.Count; i++)
            {
                behaviours[i].update();
            }
        }

        /// <summary>
        /// Creates a new class of type IBehaviour and attaches an entity body to the behaviour
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ent"></param>
        /// <returns></returns>
        public T createMind<T>(IEntity ent) where T : IBehaviour, new()
        {
            T Mind = new T();
            Mind.Initialise(ent);
            behaviours.Add(Mind);
            return Mind;
        }


        /// <summary>
        /// Removes a beahaviour from the behaviours list
        /// </summary>
        /// <param name="mind"></param>
        public void removeMind(IBehaviour mind)
        {
            behaviours.Remove(mind);
        }
    }
}