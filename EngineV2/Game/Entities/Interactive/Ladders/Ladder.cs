using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;
using Engine.Collision_Management;
using Engine.Input_Managment;

namespace ProjectHastings.Entities
{
    /// <summary>
    /// Interactive object for the player allowing them to go up and down the y axis
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    class Ladder : GameEntity
    {
        #region Instance Variables

        public string tag = "Ladder";

        //Input Management
        private KeyboardState keyState;

        //Collision Management Variables
        private IEntity collisionObj;
        private ICollidable colliders;
        private List<IEntity> playerObj;

        #endregion

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            InputManager.GetInputInstance.AddListener(OnNewInput);
            CollisionManager.GetColliderInstance.subscribe(onCollision);
            _Collisions.isInteractiveCollidable(this);
            CollidableObjs();
        }
        
        /// <summary>
        /// Initialise Keyboard Event Handler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
        }
        
        /// <summary>
        /// Get the player Object list
        /// </summary>
        public override void CollidableObjs()
        {
            playerObj = _Collisions.getPlayableObj();
        }

        /// <summary>
        /// Call collision Evem
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            for (int i = 0; i < playerObj.Count; i++)
            {
                if (HitBox.Intersects(playerObj[i].getHitbox()) && playerObj[i].getTag() == "Player")
                {
                    Player.canClimb = true;
                }

                Player.canClimb = false;
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
        #endregion
    }
}
