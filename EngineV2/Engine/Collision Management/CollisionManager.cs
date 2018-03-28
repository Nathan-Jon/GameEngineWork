using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Interfaces;

namespace Engine.Collision_Management
{
    public class CollisionManager : ICollisionManager, IProvider
    {
        public event EventHandler<CollisionEventData> NewCollision;
        public IEntity collisionObj;

        //SETING UP SINGLETON
        public CollisionManager()
        { }

        //Raise the event
        public void onCollision(object source, IEntity collidedObject)
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