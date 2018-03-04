using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineV2.Interfaces;

namespace EngineV2.Collision_Management
{
    public sealed class CollisionManager : ICollisionManager
    {
        public event EventHandler<CollisionEventData> NewCollision;
        public IEntity collisionObj;

        private static CollisionManager instance = null;
        private static object syncInstance = new object();


        //SETING UP SINGLETON
        private CollisionManager()
        { }

        public static ICollisionManager GetColliderInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new CollisionManager();
                    }
                }
                return instance;
            }
        }




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