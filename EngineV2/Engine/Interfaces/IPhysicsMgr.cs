using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics;

namespace Engine.Interfaces
{
    interface IPhysicsMgr
    {
        void Update(IPhysics phys);
    }
}
