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
using Engine.Input_Managment;

namespace ProjectHastings.Entities
{
    /// <summary>
    /// Lever Used to Trigger the event on an object
    /// </summary>
    class Lever : GameEntity
    {
        #region Instance Variables

        //BEHAVIOURS
        //LEVER RESPONSIBILITY CLASS
        IEntity target;

        private bool canTrigger = false;
        //Input Management
        private KeyboardState keyState;

        //Collision Management
        private IEntity collisionObj;
        private ICollidable colliders;
        private List<IEntity> playerObj;
        private List<IEntity> targetObjs;

        #endregion

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            //SUBSCRIBERS
            InputManager.GetInputInstance.AddListener(OnNewInput);
            CollisionManager.GetColliderInstance.subscribe(onCollision);

            //CALL COLLIDABLEOBJS()
            CollidableObjs();
        }

        /// <summary>
        /// Trigger Input Event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
            if (canTrigger && keyState.IsKeyDown(Keys.H) || canTrigger && keyState.IsKeyDown(Keys.E))
            {
                for (int i = 0; i < targetObjs.Count; i++)
                {
                    if (targetObjs[i].getTag() == "leverObj")
                    {
                            targetObjs[i].setYPos(105);
   
                    }
                }
            }
        }

        /// <summary>
        /// Get the list of interactive objects
        /// </summary>
        public override void CollidableObjs()
        {
            playerObj = _Collisions.getPlayableObj();
            targetObjs = _Collisions.getEnvironment();
        }

        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            for (int i = 0; i < playerObj.Count; i++)
            {
                //checks to see if player is in contact with the lever 
                if (HitBox.Intersects((playerObj[0].getHitbox())))
                {
                    //CAN ACTIVATE LEVER
                    canTrigger = true;
                }
                else canTrigger = false;
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


        #region GET/SETS
                public override void setXPos(float Xpos)
        {
            Position.X = Xpos;
        }
        public override void setYPos(float Ypos)
        {
            Position.Y = Ypos;
        }
        public override void setRow(int rows)
        {
            row = rows;
        }
        #endregion
    }
}
