using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    class PhysicsManager : IPhysicsMgr
    {
        IPhysicsObj physicsObjs;

        public PhysicsManager(IPhysicsObj physics)
        {
            physicsObjs = physics;
        }

        public void update()
        {
            physicsObjs.gravity();
        }
    }
}
