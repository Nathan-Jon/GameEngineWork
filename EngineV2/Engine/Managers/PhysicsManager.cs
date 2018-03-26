using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Interfaces;
using Engine.Physics;

namespace Engine.Managers
{
   public sealed class PhysicsManager : IPhysicsMgr
    {

        public void Update(IPhysics physicsObjs)
        {
            physicsObjs.UpdatePhysics();
        }
    }
}
