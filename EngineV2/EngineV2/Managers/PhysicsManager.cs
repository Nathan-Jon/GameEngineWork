using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
   public sealed class PhysicsManager : IPhysicsMgr
    {
        IPhysicsObj physicsObjs;

        private static PhysicsManager instance = null;
        private static object syncInstance = new object();

        private PhysicsManager()
        { }

        /// <summary>
        /// Returns an instance of the Physics Manager
        /// </summary>
        public static PhysicsManager getPhysicsInstance
        {
            get
            {
                if (instance == null)
                {
                    //Ensures only one class can access this if statement at a time
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new PhysicsManager();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Sets the passed IPhysicsObj to the physicsObj variable
        /// </summary>
        /// <param name="physics"></param>
        public void setPhysicsList(IPhysicsObj physics)
        {
            physicsObjs = physics;
        }

        /// <summary>
        /// Runs the gravity method on the physicsObjs instance
        /// </summary>
        public void update()
        {
            physicsObjs.gravity();
        }
    }
}
