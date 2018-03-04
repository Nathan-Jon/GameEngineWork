using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EngineV2.Collision_Management;

namespace EngineV2.Interfaces
{
    public interface ICollisionManager
    {
        void onCollision(object source, IEntity collidedObject);
        void subscribe(EventHandler<CollisionEventData> collisionHandler);
        void update();
    }
}
