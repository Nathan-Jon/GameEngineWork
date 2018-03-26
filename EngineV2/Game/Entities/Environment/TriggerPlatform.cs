using System.Collections.Generic;
using Engine.Collision_Management;
using Engine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Collision_Management;


namespace ProjectHastings.Entities
{
    /// <summary>
    /// Environment object for the player which the player can use to trigger an event
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    class TriggerPlatform : GameEntity
    {
        //COLLISIONS
        private IEntity collisionObj;
        private IEntity collision;


        //LISTS
        private List<IEntity> physicsObjs;

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            Tag = "leverObj";
            CollisionManager.GetColliderInstance.subscribe(onCollision);
            //physicsObjs = _PhysicsObj.getPhysicsList();
            _Collisions.isEnvironmentCollidable(this);
        }

        #region behaviours
        public void lower()
        {
            if (Position.Y < 107)
                Position += new Vector2(0, 1);
        }
        #endregion

        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {

            bool onTerrain = false;

            collision = data.objectCollider;

            //for (int i = 0; i < physicsObjs.Count; i++)
            //{
            //    //if (Hitbox.Intersects(physicsObjs[i].Hitbox))
            //    //{
            //    //    physicsObjs[i].setGrav(false);
            //    //}
            //}
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
