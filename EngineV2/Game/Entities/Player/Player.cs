using System.Collections.Generic;
using ProjectHastings.Behaviours.Player_Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Managers;
using Engine.Interfaces;
using Engine.Collision_Management;
using Engine.Input_Managment;
using ProjectHastings.Animations;

namespace ProjectHastings.Entities
{
    /// <summary>
    /// Class for Player Entity
    /// 
    /// Author: Nathan Robertson & Carl Chalmers
    /// Date of change: 03/02/18
    /// Version 0.5
    /// 
    /// </summary>
    public class Player : GamePhysicsEntity
    {
        #region Properties
        //Animation Variable
        public IAnimations ani;
        public static int row = 1;
        public static bool Animate = false;


        //Movement
        public static bool canClimb = false;
        public bool sprint = false;

        //Jump Variables
        private float jumpForce = 10;
        private float maxJump = 120;
        private bool canJump = false;
        private bool isJumping = false;
        private float jumpHeight = 0;

        //Input Management
        private KeyboardState keyState;

        //Collision Lists
        private List<IEntity> collisionObjs;
        private List<IEntity> interactiveObjs;
        private List<IEntity> environment;

        private IEntity collision;

        #endregion

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            Tag = "Player";
            speed = 3;
            ani = new PlayerAnimation();
            ani.Initialize(this, 3, 3);
            CollidableObjs();
            // _BehaviourManager.createMind<PlayerMind>(this);

            // CollisionManager.GetColliderInstance.subscribe(onCollision);
            InputManager.GetInputInstance.AddListener(OnNewInput);
        }

        /// <summary>
        /// Event Handler for Keyboard Input
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;


            #region SPACEBAR
            if (keyState.IsKeyDown(Keys.Space))
            {
                isJumping = true;
                jump();
            }
            #endregion

            #region LEFT SHIFT
            if (keyState.IsKeyDown(Keys.LeftShift))
            {
                sprint = true;
            }
            else if (keyState.IsKeyUp(Keys.LeftShift))
            {
                sprint = false;
            }
            #endregion


            if (keyState.GetPressedKeys().Length == 0)
            {
                SoundManager.getSoundInstance.Stopsnd("Walk");
                SoundManager.getSoundInstance.Stopsnd("Ladder");
            }
        }

        #region Collision Management
        /// <summary>
        /// Gets the lists for the collidable Objecs
        /// </summary>
        public override void CollidableObjs()
        {
            //   collisionObjs = _Collisions.getCollidableList();
            //   interactiveObjs = _Collisions.getInteractiveObj();
            //   environment = _Collisions.getEnvironment();
        }
        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        //public virtual void onCollision(object source, CollisionEventData data)
        //{
        //    collision = data.objectCollider;

        //    //gravity = true;
        //    canClimb = false;

        //    #region Map corners 
        //    if (Hitbox.X <= 0)
        //    { Position += new Vector2(3, 0); }

        //    if (Hitbox.X >= 875)
        //    { Position += new Vector2(-3,0); }

        //    if (Hitbox.Y <= 0)
        //    { Position += new Vector2(0, ySpeed);}

        //    if (Hitbox.Y >= 559)
        //    {
        //        canJump = true;
        //    }
        #endregion

        #region Enemy collisions
        //    //for (int i = 0; i < collisionObjs.Count; i++)
        //    //{
        //    //    if (Hitbox.Intersects(collisionObjs[i].Hitbox) && collisionObjs[i].Tag == "Thug")
        //    //    {
        //    //        EntityManager.Entities.Clear();
        //    //        BehaviourManager.behaviours.Clear();
        //    //        SceneManager.LoseScreen = true;
        //    //    }
        //    //}
        #endregion

        //    #region Interactive Obj collisions
        //    for (int i = 0; i < interactiveObjs.Count; i++)
        //    {
        //        if (Hitbox.Intersects(interactiveObjs[i].Hitbox) && interactiveObjs[i].Tag == "Crate")
        //        { }

        //        if (Hitbox.Intersects(interactiveObjs[i].Hitbox) && interactiveObjs[i].Tag == "Ladder")
        //        {
        //            ySpeed = 2;
        //            canClimb = true;
        //        }

        //        if (Hitbox.Intersects(interactiveObjs[i].Hitbox))
        //        {
        //            //gravity = false;
        //            canClimb = false;
        //        }
        //    }

        //    for (int i = 0; i < environment.Count; i++)
        //    {
        //        if (Hitbox.Intersects(environment[i].Hitbox))
        //        {
        //            canJump = true;
        //        }
        //        else if (!Hitbox.Intersects(environment[i].Hitbox))
        //        {
        //        }
        //    }

        //}

        #region Behaviours
        /// <summary>
        /// Moves the Player up onthe Y axis up to a maximum point
        /// </summary>
        public void jump()
        {

            if (canJump)
            {
                //            gravity = false;
                if (isJumping)
                {
                    Position -= new Vector2(0, jumpForce);
                    jumpHeight += jumpForce;
                    Position += new Vector2(0, jumpForce);
                }

                if (jumpHeight >= maxJump)
                {

                    canJump = false;
                    jumpHeight = 0;
                }
            }
        }

        #endregion

        /// <summary>
        /// Draws the entty based on the texture and position obtained from the animation class
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            ani.Draw(spriteBatch);
        }
        /// <summary>
        /// Called Every Frame
        /// </summary>
        /// <param name="game"></param>
        public override void Update(GameTime game)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, PlayerAnimation._width, PlayerAnimation._height);

            if (Animate == true)
            {
                ani.Update(game);
            }
            Animate = false;
        }

        #region get/sets
        public override int getRows()
        {
            return row;
        }
        public override void setRow(int rows)
        {
            row = rows;
        }

        #endregion


    }

}