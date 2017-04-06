using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EngineV2.Interfaces;

namespace EngineV2.Collision_Management
{
    public class CollisionEventData : EventArgs
    {
        public IEntity objectCollider;

        public CollisionEventData(IEntity collidedObject)
        {
            objectCollider = collidedObject;
        }
    }
}
