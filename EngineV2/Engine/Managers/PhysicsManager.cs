using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Interfaces;

namespace Engine.Managers
{
   public sealed class PhysicsManager : IPhysicsMgr
    {
        IPhysicsObj physicsObjs;

        private static PhysicsManager instance = null;
        private static object syncInstance = new object();

        private PhysicsManager()
        { }

        public static PhysicsManager getPhysicsInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new PhysicsManager();
                    }
                }

                return instance;
            }
        }

        public void setPhysicsList(IPhysicsObj physics)
        {
            physicsObjs = physics;
        }

        public void update()
        {
            physicsObjs.gravity();
        }
    }
}
