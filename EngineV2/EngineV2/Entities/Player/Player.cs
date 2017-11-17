using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Behaviours.Player_Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;
using EngineV2.Managers;
using EngineV2.Interfaces;
using EngineV2.Collision_Management;
using EngineV2.Input_Managment;
using EngineV2.Scenes;

namespace EngineV2.Entities
{
    class Player : GameEntity
    {
        #region Properties
        public string tag = "Player";

        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        public int row = 1;
        public static bool Animate = false;
        public bool gravity = false;
        public bool onTerrain = false;

        //Movement
        private float speed = 3;
        private float ySpeed = 2;
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
        private InputManager inputMgr;

        //Behaviours
        private IBehaviour playerController;


        //Lists
        private List<IEntity> collisionObjs;
        private List<IEntity> interactiveObjs;
        private List<IEntity> environment;

        private IEntity collision;
        private CollisionManagerSingleton collisionMgr;
        private ICollidable colliders;
        private ISoundManager sound;
        #endregion

        #region Initialisation
        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            collisionMgr = CollisionManagerSingleton.GetColliderInstance;
            inputMgr = InputManager.GetInputInstance;
            Position = Posn;
            Texture = Tex;
            sound = snd;
            colliders = _collider;
            collisionMgr.subscribe(onCollision);
            inputMgr.AddListener(OnNewInput);
            CollidableObjs();
            _collider.isPlayerEntity(this);
            phys.hasPhysics(this);
            behaviours.createMind<PlayerMind>(this);

        }

        #endregion

        #region Input Management
        //Input Manager
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;

            sound.Volume(1, 0.1f);
            sound.Volume(5, 0.1f);

            //Act on the data
            #region ARROWS & WASD
            if (canClimb && keyState.IsKeyDown(Keys.W) ||canClimb &&keyState.IsKeyDown(Keys.Up))
            {
                Position.Y -= ySpeed;
                Animate = true;
                row = 2;
                sound.Playsnd(5);
            }
            if (canClimb && keyState.IsKeyDown(Keys.S) || canClimb && keyState.IsKeyDown(Keys.Down))
            {
                Position.Y += ySpeed;
                Animate = true;
                row = 2;
                sound.Playsnd(5);
            }
            //if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            //{
            //    if (sprint)
            //    {
            //        speed = 6;
            //    }
            //    else speed = 3;
            //    Position.X += speed;
            //    Animate = true;
            //    row = 1;
            //    sound.Playsnd(1);
            //}
            //if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            //{
            //    if (sprint)
            //    {
            //        speed = -6;
            //    }
            //    else speed = -3;
            //    Position.X += speed;
            //    Animate = true;
            //    row = 0;
            //    sound.Playsnd(1);
            //}
            #endregion

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


            if (keyState.GetPressedKeys().Length == 0 || SceneManager.animationlist.Count == 0)
            {
                sound.Stopsnd(1);
                sound.Stopsnd(5);
            }
        }
        #endregion

        #region Collision Management
        //List of Collidable Objects
        public override void CollidableObjs()
        {
            collisionObjs = colliders.getEntityList();
            interactiveObjs = colliders.getInteractiveObj();
            environment = colliders.getEnvironment();
        }
        //Collision Manager
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collision = data.objectCollider;

            gravity = true;
            canClimb = false;

            #region map corners 
            if (HitBox.X <= 0)
            { Position.X -= -3; }

            if (HitBox.X >= 875)
            { Position.X -= 3; }

            if (HitBox.Y <= 0)
            { Position.Y += ySpeed; }

            if (HitBox.Y >= 559)
            {
                gravity = false;
                canJump = true;
            }
            #endregion

            #region enemy collisions
            for (int i = 0; i < collisionObjs.Count; i++)
            {
                if (HitBox.Intersects(collisionObjs[0].getHitbox()))
                {
                    EntityManager.Entities.Clear();
                    BehaviourManager.behaviours.Clear();
                    Scene1.Animation.Clear();
                    SceneManager.ExitGame = true;
                }
            }
            #endregion

            #region Interactive Obj collisions
            for (int i = 0; i < interactiveObjs.Count; i++)
            {
                if (HitBox.Intersects(interactiveObjs[i].getHitbox()) && interactiveObjs[i].getTag() == "Crate")
                {
                    canJump = true;
                }

                if (HitBox.Intersects(interactiveObjs[i].getHitbox()) && interactiveObjs[i].getTag() == "Ladder")
                {
                    gravity = false;
                    ySpeed = 2;
                    canClimb = true;
                }

                if (HitBox.Intersects(interactiveObjs[i].getHitbox()))
                {
                    gravity = false;
                    //canClimb = false;
                }
                //else gravity = true;
            }


            for (int i = 0; i < environment.Count; i++)
            {
                if (HitBox.Intersects(environment[i].getHitbox()))
                {
                   // gravity = false;
                    canJump = true;
                }
            }
        }
            #endregion


        #endregion

        #region Behaviours

        public void jump()
        {

            if (canJump)
            {
                //            gravity = false;
                if (isJumping)
                {
                    Position.Y -= jumpForce;
                    jumpHeight += jumpForce;
                    Position.Y += 3f;
                }

                if (jumpHeight >= maxJump)
                {

                    canJump = false;
                    jumpHeight = 0;
                }
            }
        }

        #endregion

        //Draw Method
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);

        }
        //Update Method
        public override void update()
        {

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, AnimationMgr.Width, AnimationMgr.Height);
        }

        #region get/sets

        public override Vector2 getPos()
        {
            return Position;
        }
        public override Texture2D getTex()
        {
            return Texture;
        }
        public override int getRows()
        {
            return row;
        }
        public override bool getGrav()
        {
            return gravity;
        }
        public float getDirection()
        {
            return speed;
        }
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
        public override void setRow(int rows)
        {
            row = rows;
        }

        public override void setGrav(bool active)
        {
            gravity = active;
        }

        #endregion


    }

}