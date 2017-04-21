using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;
using EngineV2.Managers;
using EngineV2.Interfaces;
using EngineV2.Collision_Management;

namespace EngineV2.Entities
{
    class Player : GameEntity
    {
        #region Properties
        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        public int row = 1;
        public static bool Animate = false;
        public bool gravity = false;
        private float speed = 3;
        private float ySpeed = 3;

        //Jump Variables
        private bool canJump = true;
        private float maxJump = -100;
        private float jumpHeight;


        //Input Management
        private KeyboardState keyState;
        private InputManager inputMgr;
        //Collision Management
        private List<IEntity> collisionObjs;
        private IEntity collision;
        private CollisionManager collisionMgr;
        private ICollidable colliders;
        private ISoundManager sound;
        #endregion

        #region Initialisation
        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            sound = snd;
            colliders = _collider;
            inputMgr.AddListener(OnNewInput);
            collisionMgr.subscribe(onCollision);
            CollidableObjs();
            _collider.isCollidableEntity(this);
            phys.hasPhysics(this);
        }
        //Subscribe to Event Handlers
        public override void applyEventHandlers(InputManager inputManager, CollisionManager col)
        {
            inputMgr = inputManager;
            collisionMgr = col;
        }
        #endregion

        #region Input Management
        //Input Manager
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;

            sound.Volume(1, 0.5f);

            //Act on the data
            if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
            {
                Position.Y -= ySpeed;
                Animate = true;
                row = 2;
                sound.Playsnd(1);
            }
            if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            {
                Position.Y += ySpeed;
                Animate = true;
                row = 2;
                sound.Playsnd(1);
            }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {
                speed = 3;
                Position.X += speed;
                Animate = true;
                row = 1;
                sound.Playsnd(1);
            }
            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {
                speed = -3;
                Position.X += speed;
                Animate = true;
                row = 0;
                sound.Playsnd(1);
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                if (canJump == true)
                {
                    jump();
                }
            }
            if (keyState.GetPressedKeys().Length == 0 || SceneManager.animationlist.Count == 0)
            {

                sound.Stopsnd(1);

            }
        }
        #endregion

        #region Collision Management
        //List of Collidable Objects
        public override void CollidableObjs()
        {
            collisionObjs = colliders.getEntityList();
        }
        //Collision Manager
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collision = data.objectCollider;

            if (Position.X <= 0)
            {Position.X += speed * -1;}
            if (HitBox.X >= 850)
            { Position.X += speed * -1; }
            if (Position.Y <= 0)
            { Position.Y += ySpeed; }
            if (HitBox.Y >= 565)
            {
                Position.Y -= ySpeed;
                gravity = false;
                canJump = true;
            }

            for (int i = 0; i < collisionObjs.Count; i++)
            {
                if (HitBox.Intersects(collisionObjs[1].getHitbox()))
                {
                    SceneManager.animationlist.Clear();

                }
            }
        }
        #endregion

        #region Behaviours

        public void jump()
        {
            if (canJump == true)
            {
                Position.Y -= 8;
                gravity = true;
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
