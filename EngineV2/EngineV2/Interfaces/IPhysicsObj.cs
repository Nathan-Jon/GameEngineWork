using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2.Interfaces
{
    interface IPhysicsObj
    {
        void hasPhysics(IEntity obj);
        void gravity();

        List<IEntity> getPhysicsList();
    }
}
