using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using EngineV2.Interfaces;

namespace EngineV2.Collision_Management
{
    public sealed class CollisionManagerSingleton
    {
        public event EventHandler<CollisionEventData> NewCollision;
        public IEntity collisionObj;

        private static CollisionManagerSingleton instance = null;
        private static object syncInstance = new object();


        //SETING UP SINGLETON
        private CollisionManagerSingleton()
        { }

        public static CollisionManagerSingleton GetColliderInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new CollisionManagerSingleton();
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