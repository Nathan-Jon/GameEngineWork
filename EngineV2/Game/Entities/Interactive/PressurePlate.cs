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
    /// Trigger Object
    /// </summary>
    class PressurePlate : GameEntity
    {
        //tag Identifier
        public string tag = "PressurePlate";
        private float moveDirec = 3;
        private bool moveObject = false;
        private bool canMove = true;
        private bool crateContact = false;

        //Physics
        public bool gravity = true;

        //Input Management
        private KeyboardState keyState;

        //Collision Management
        private IEntity collisionObj;
        private ICollidable colliders;
        IPhysicsObj physics;

        //Lists
        private List<IEntity> environementObjs;
        private List<IEntity> interactiveObj;
        private IEntity triggerWall;

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            InputManager.GetInputInstance.AddListener(OnNewInput);

            CollisionManager.GetColliderInstance.subscribe(onCollision);
            CollidableObjs();
            _Collisions.isInteractiveCollidable(this);
        }

        /// <summary>
        /// Trigger Input Event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
        }

        /// <summary>
        /// Get the list of interactive objects
        /// </summary>
        public override void CollidableObjs()
        {
            //physicsObj = physics.getPhysicsList();
            environementObjs = _Collisions.getEnvironment();
            interactiveObj = _Collisions.getInteractiveObj();
        }

        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;


            #region Player Collision
            for (int i = 0; i < interactiveObj.Count; i++)
            {
                if (HitBox.Intersects(interactiveObj[i].getHitbox()) && interactiveObj[i].getTag() == "Crate")
                {
                    activate();
                }
                
            }
            
            #endregion
        }

        #region behaviours

        public void activate()
        {
            for (int i = 0; i < environementObjs.Count; i++)
            {
                if (environementObjs[i].getTag() == "triggerWall")
                {
                    triggerWall = environementObjs[i];
                }
            }
            triggerWall.setYPos(1000);
        }

        public void reset()
        { triggerWall.setYPos(351); }

        #endregion

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


        #region  get/Sets


        public override Vector2 getPos()
        {
            return Position;
        }

        public override Rectangle getHitbox()
        {
            return HitBox;
        }
        public override bool getGrav()
        {
            return gravity;
        }
        public override string getTag()
        {
            return tag;
        }

        public override void setYPos(float Ypos)
        {
            Position.Y = Ypos;
        }
        public override void setXPos(float Xpos)
        {
            Position.X = Xpos;
        }
        public override void setGrav(bool active)
        {
            gravity = active;
        }

        #endregion
    }
}