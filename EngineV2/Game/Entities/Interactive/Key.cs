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
    /// Interactive object used to Unlock Doors
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    class Key : GameEntity
    {
        #region Instance Variables
        public bool keyContact = false;
        public static bool Unlock = false;
        public bool gravity = true;


        //Input Management
        private KeyboardState keyState;

        //Collision Management Variables
        private IEntity collisionObj;
        private ICollidable colliders;



        //Lists
        private List<IEntity> interactiveObjs;

        #endregion

        public override void UniqueData()
        {
            InputManager.GetInputInstance.AddListener(OnNewInput);
            CollisionManager.GetColliderInstance.subscribe(onCollision);
            _PhysicsObj.hasPhysics(this);
            _Collisions.isEnvironmentCollidable(this);
            CollidableObjs();
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




        /// <summary>
        /// Trigger Input Event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
            if (keyContact)
            {
                SoundManager.getSoundInstance.Playsnd("Key", 0.5f);
                Unlock = true;

            }
            if (keyContact == false)
            {
                SoundManager.getSoundInstance.Stopsnd("Key");
            }
        }

        /// <summary>
        /// Get the list of interactive objects
        /// </summary>
        public override void CollidableObjs()
        {
            interactiveObjs = _Collisions.getPlayableObj();
        }

        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;
            gravity = true;

            for (int i = 0; i < interactiveObjs.Count; i++)
            {
                //checks to see if player is in contact with the door 
                if (HitBox.Intersects((interactiveObjs[0].getHitbox())))
                {
                    keyContact = true;
                    EntityManager.Entities.Remove(this);
                }
                else
                {
                    keyContact = false;
                }
            }
        }
        


        #region GET/SETS
        public override bool getGrav()
        {
            return gravity;
        }
        public override void setGrav(bool active)
        {
            gravity = active;
        }
        #endregion
    }
}
