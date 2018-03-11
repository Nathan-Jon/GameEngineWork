using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;
using Engine.Managers;
using Engine.Collision_Management;
using Engine.Input;

namespace ProjectHastings.Entities
{
    /// <summary>
    /// ojbect which is triggered by lever
    /// </summary>
    class LeverTarget : GameEntity
    {
        //Tag Identifier
        public string tag = "LeverTarget";

        //COLLISIONS
        private IEntity collisionObj;
        private IEntity collision;


        //PHYSICS
        private IPhysicsObj physics;

        //LISTS
        private List<IEntity> physicsObjs;

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            _Collisions.isEnvironmentCollidable(this);
            physicsObjs = _PhysicsObj.getPhysicsList();
            CollisionManager.GetColliderInstance.subscribe(onCollision);

        }

        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {

            bool onTerrain = false;

            collision = data.objectCollider;

            for (int i = 0; i < physicsObjs.Count; i++)
            {
                if (HitBox.Intersects(physicsObjs[i].getHitbox()))
                { physicsObjs[i].setGrav(false); }


            }
        }

        /// <summary>
        /// Draws the entty based on the texture and position obtained from the animation class
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }

        /// <summary>
        /// Called Every Frame
        /// </summary>
        /// <param name="game"></param>
        public override void update(GameTime game)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        #region get/sets
        public override Rectangle getHitbox()
        {
            return HitBox;
        }
        public override void setXPos(float Xpos)
        {
            Position.X = Xpos;
        }
        public override void setYPos(float Ypos)
        {
            Position.Y = Ypos;
        }
        #endregion
    }
}

