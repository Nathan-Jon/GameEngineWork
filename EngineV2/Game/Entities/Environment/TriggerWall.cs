using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Interfaces;
using Engine.Collision_Management;

namespace ProjectHastings.Entities
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
        public string tag = "triggerWall";

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
            CollisionManager.GetColliderInstance.subscribe(onCollision);
            physicsObjs = _PhysicsObj.getPhysicsList();
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

            for (int i = 0; i < physicsObjs.Count; i++)
            {
                //if (HitBox.Intersects(physicsObjs[i].getHitbox()))
                //{ physicsObjs[i].setXPos(physicsObjs[i].getPos().X - 3); }
                if (HitBox.Intersects(physicsObjs[i].getHitbox()))
                {
                    if (physicsObjs[i].getPos().X < HitBox.Width)
                    { physicsObjs[i].setXPos(physicsObjs[i].getPos().X - 3); }
                    if (physicsObjs[i].getPos().X > HitBox.Width/2)
                    { physicsObjs[i].setXPos(physicsObjs[i].getPos().X - 3); }
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
        public override void update(GameTime game)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        #region get/Sets
        public override Rectangle getHitbox()
        {
            return HitBox;
        }
        public override string getTag()
        {
            return tag;
        }
        public override void setXPos(float Xpos)
        {
            Position.X = Xpos;
        }
        public override void setYPos(float Ypos)
        {
            Position.Y = Ypos;
        }
        public override Vector2 getPos()
        { return Position; }
        #endregion
    }
}
