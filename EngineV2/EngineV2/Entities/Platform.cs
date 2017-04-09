using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Collision_Management;
using EngineV2.Input;

namespace EngineV2.Entities
{
    class Platform : GameEntity
    {
        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        private CollisionManager collisionMgr;
        private IEntity collisionObj;


        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd)
        {
            Position = Posn;
            Texture = Tex;
            collisionMgr.subscribe(onCollision);
        }

        public override void applyEventHandlers(InputManager inputManager, CollisionManager collisions)
        {
            collisionMgr = collisions;
        }

        public virtual void onCollision(object source, CollisionEventData data)
        {

         //   bool active = false;

         //      collisionObj = data.objectCollider;
         //for (int i = 0; physicsObj.Count; i++)
         //   {
         //       if (HitBox.Intersects(physicsObj[i].getHitbox()))
         //       {
         //           collisionObj.setGrav(active);
         //       }

         //   }
        }
    }
}
