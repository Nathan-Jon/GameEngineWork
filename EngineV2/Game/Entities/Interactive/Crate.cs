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
    class Crate : GameEntity
    {
        public string tag = "Crate";
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
        //Lists
        private List<IEntity> player;
        private List<IEntity> environment;

        public override void UniqueData()
        {
            InputManager.GetInputInstance.AddListener(OnNewInput);
            CollisionManager.GetColliderInstance.subscribe(onCollision);
            CollidableObjs();
            _Collisions.isInteractiveCollidable(this);
            _PhysicsObj.hasPhysics(this);
        }

        /// <summary>
        /// Event Handler for Keyboard Input
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
            if (crateContact && keyState.IsKeyDown(Keys.H) || crateContact && keyState.IsKeyDown(Keys.E))
            {

                moveObject = true;

                if (crateContact && keyState.IsKeyDown(Keys.D) || moveObject && keyState.IsKeyDown(Keys.Right))
                {
                    Position.X += 3;
                    SoundManager.getSoundInstance.Playsnd("Crate", 0.2f);
                }
                if (crateContact && keyState.IsKeyDown(Keys.A) || moveObject && keyState.IsKeyDown(Keys.Left))
                {
                    Position.X += -3;
                    SoundManager.getSoundInstance.Playsnd("Crate", 0.2f);
                }

            }

            if (crateContact == false)
            {
                SoundManager.getSoundInstance.Stopsnd("Crate");
            }
        }

        /// <summary>
        /// Get the lists of collidabl objects
        /// </summary>
        public override void CollidableObjs()
        {
            //interactiveObjs = colliders.getEntityList();
            player = _Collisions.getPlayableObj();
            environment = _Collisions.getEnvironment();
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

            #region wall collisions

            if (Position.X <= 0)
            { Position.X -= -3; }
            if (HitBox.X >= 850)
            { Position.X -= 3; }
            if (Position.Y >= 570)
            {
                gravity = false;
                Position.Y -= 2;
            }
            #endregion

            #region Player Collision
            for (int i = 0; i < player.Count; i++)
            {
                if (HitBox.Intersects((player[i].getHitbox())))
                {
                    //if (player[i].getTag() == "Player")
                    //{ crateContact = true; }
                    //else if (player[i].getTag() != "Player")
                    //{ crateContact = false; }

                    crateContact = true;
                    player[i].setGrav(false);
                }
                else
                { crateContact = false; }

            }
            for (int i = 0; i < environment.Count; i++)
            {
                if (HitBox.Intersects(environment[i].getHitbox()))
                {
                    gravity = false;
                }
            }
            #endregion
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
