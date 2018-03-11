using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.Collision_Management;

namespace Engine.Interfaces
{
    public interface ICollisionManager
    {
        void onCollision(object source, IEntity collidedObject);
        void subscribe(EventHandler<CollisionEventData> collisionHandler);
        void update();
    }
}
