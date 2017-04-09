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

        public static Texture2D Texture;
        public bool gravity = true;
        public Vector2 Position;
        public Rectangle HitBox;
        public int row = 1;
        public static Boolean Animate = false;
        
        public float xSpeed = 3;
        private float ySpeed = 5;

        //Input Management
        private KeyboardState keyState;
        private InputManager inputMgr;
        //Collision Management
        private List<IEntity> collisionObjs;
        private IEntity collision;
        private CollisionManager collisionMgr;
        private ICollidable colliders;
        private ISoundManager sound;

        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd)
        {
            Position = Posn;
            Texture = Tex;
            sound = snd;
            colliders = _collider;
            inputMgr.AddListener(OnNewInput);
            collisionMgr.subscribe(onCollision);
            CollidableObjs();
        }

        public override void CollidableObjs()
        {
            collisionObjs = colliders.getList();
        }

        public override void applyEventHandlers(InputManager inputManager, CollisionManager col)
        {
            inputMgr = inputManager;
            collisionMgr = col;
        }

        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;

            //Act on the data
            if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
            { 
                Position.Y -= ySpeed;
                Animate = true;
                row = 2;
                sound.Playsnd(0);
            }
            if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            { 
                Position.Y += ySpeed;
                Animate = true;
                row = 2;
            }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {                 Position.X += xSpeed;
                Animate = true;
                row = 1;
            }
            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            { 
                Position.X -= xSpeed;
                Animate = true;
                row = 0;
            }
        }

        public virtual void onCollision(object source, CollisionEventData data)
        {
            collision = data.objectCollider;

            if (Position.X <= 0)
            { Position.X += xSpeed; }
            if (HitBox.X >= 800)
            { Position.X -= xSpeed; }
            if (Position.Y <= 0)
            { Position.Y += ySpeed; }
            if (HitBox.Y >= 500)
            { Position.Y -= ySpeed; }

            for (int i = 0; i < collisionObjs.Count; i++)
            {
                if (HitBox.Intersects(collisionObjs[1].getHitbox()))
                { collisionObjs[1].setXPos(300);
                    gravity = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public override void update()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, AnimationMgr.Width, AnimationMgr.Height);
        }

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

        public override Rectangle getHitbox()
        {
            return HitBox;
        }
        public override bool getGrav()
        {
            return gravity;
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


    }
}
