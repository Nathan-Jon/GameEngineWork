using System.Collections.Generic;
using Engine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Collision_Management;
using Engine.Physics;

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
        private IPhysics physics;

        //LISTS
        private List<IEntity> physicsObjs;

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            _Collisions.isEnvironmentCollidable(this);
            //physicsObjs = _PhysicsObj.getPhysicsList();
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
                if (Hitbox.Intersects(physicsObjs[i].Hitbox))
                {
                    //physicsObjs[i].setGrav(false); 

                }


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
        public override void Update(GameTime game)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }
    }
}

