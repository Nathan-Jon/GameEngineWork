using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using EngineV2.Interfaces;

namespace EngineV2.Collision_Management
{
    public class CollisionManager
    {
        public event EventHandler<CollisionEventData> NewCollision;
        public IEntity collisionObj;

        //Raise the event
        public virtual void onCollision(object source, IEntity collidedObject)
        {
            CollisionEventData collision = new CollisionEventData(collidedObject);
            NewCollision(this, collision);
            collisionObj = collidedObject;
        }

        public void subscribe(EventHandler<CollisionEventData> collisionHandler)
        {
            //Add Event Handlers
            NewCollision += collisionHandler;
        }

        public void update()
        {
            //for (int i = 0; i < CollidableObjs.Count; i++)
            //{
                if (NewCollision != null)
                {
                    onCollision(this, collisionObj);
                }
            //}

        }
    }
}
