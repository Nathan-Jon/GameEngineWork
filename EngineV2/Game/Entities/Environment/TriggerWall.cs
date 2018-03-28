using System.Collections.Generic;
using Engine.Collision_Management;
using Engine.Interfaces;
using Engine.Service_Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectHastings.Entities.Environment
{
    /// <summary>
    /// Environment object for the player which the player can use to trigger an event
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    class TriggerWall : GameEntity
    {
        //Tag Identifier
        public string Tag = "triggerWall";

        //COLLISIONS
        private IEntity collisionObj;
        private IEntity collision;

        //LISTS
        private List<IEntity> physicsObjs;

        ICollisionManager coli = Locator.Instance.getProvider<CollisionManager>() as ICollisionManager;

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            coli.subscribe(onCollision);
            // physicsObjs = _PhysicsObj.getPhysicsList();
            _Collisions.isEnvironmentCollidable(this);
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

            //for (int i = 0; i < physicsObjs.Count; i++)
            //{
            //    //if (Hitbox.Intersects(physicsObjs[i].Hitbox))
            //    //{ physicsObjs[i].setXPos(physicsObjs[i].getPos().X - 3); }
            //    if (Hitbox.Intersects(physicsObjs[i].Hitbox))
            //    {
            //        //if (physicsObjs[i].Position.X < Hitbox.Width)
            //        //{ physicsObjs[i].Position.X = physicsObjs[i].getPos().X - 3; }
            //        //if (physicsObjs[i].Position.X > Hitbox.Width/2)
            //        //{ physicsObjs[i].Position.X = physicsObjs[i].Position.X - 3; }
            //    }
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
