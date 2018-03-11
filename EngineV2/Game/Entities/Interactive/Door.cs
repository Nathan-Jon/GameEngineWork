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
using ProjectHastings.Scenes;
using Engine.Buttons;
using Engine.Input_Managment;

namespace ProjectHastings.Entities
{
    /// <summary>
    /// INteractive object that changes the scene
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    class Door : GameEntity
    {
        #region Instance Variables
        public bool doorContact = false;
        

        //Input Management
        private KeyboardState keyState;

        //Collision Management Variables
        private IEntity collisionObj;
        private ICollidable colliders;
        

        //Lists
        private List<IEntity> interactiveObjs;

        #endregion

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            InputManager.GetInputInstance.AddListener(OnNewInput);

            CollisionManager.GetColliderInstance.subscribe(onCollision);

            //CALL COLLIDABLEOBJS()
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

            //if Plyaer has unlocked the door, change scene and play audio instance
            if (doorContact && keyState.IsKeyDown(Keys.W) && Key.Unlock|| doorContact && keyState.IsKeyDown(Keys.Up) && Key.Unlock)
            {
                SoundManager.getSoundInstance.Playsnd("Exit", 0.5f);
                EntityManager.Entities.Clear();
                BehaviourManager.behaviours.Clear();
                ButtonList.menuButtons.Clear();
                SceneManager.TestLevel = false;
                SceneManager.WinGame = true;


                //doorContact = false;

            }
            if (doorContact == false)
            {
                SoundManager.getSoundInstance.Stopsnd("Exit");
            }
        }

        /// <summary>
        /// Get the list of interactive objects
        /// </summary>
        public override void CollidableObjs()
        {
            interactiveObjs = _Collisions.getCollidableList();
        }

        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            for (int i = 0; i < interactiveObjs.Count; i++)
            {
                //checks to see if player is in contact with the door 
                if (HitBox.Intersects((interactiveObjs[0].getHitbox())))
                {
                    doorContact = true;
                }
                else
                {
                    doorContact = false;
                }
            }
        }
    }
}
