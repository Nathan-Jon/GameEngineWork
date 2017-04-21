using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Collision_Management;
using EngineV2.Input;

namespace EngineV2.Entities
{
    class Crate : GameEntity
    {
        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        private float moveDirec = 3;
        private bool moveObject = false;
        private bool crateContact = false;

        //Physics
        public bool gravity = true;


        //Input Management
        private KeyboardState keyState;
        private InputManager input;

        //Collision Management
        private IEntity collisionObj;
        private CollisionManager collisionMgr;
        private ICollidable colliders;
        private List<IEntity> interactiveObjs;



        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            colliders = _collider;
            input.AddListener(OnNewInput);
            collisionMgr.subscribe(onCollision);
            CollidableObjs();
            _collider.isInteractiveCollidable(this);
            phys.hasPhysics(this);
        }

        public override void applyEventHandlers(InputManager inputManager, CollisionManager collisions)
        {
            input = inputManager;
            collisionMgr = collisions;
        }

        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
            if (crateContact && keyState.IsKeyDown(Keys.H) || keyState.IsKeyDown(Keys.Enter))
            {

                    moveObject = true;

                if (moveObject && keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
                {
                    Position.X += 3;
                }
                if (moveObject  && keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
                {
                    Position.X += -3;
                }
            }
            if (keyState.IsKeyUp(Keys.E))
            {
                moveObject = false;
            }
        }

        //List of Collidable Objects
        public override void CollidableObjs()
        {
            interactiveObjs = colliders.getEntityList();
        }

        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            for (int i = 0; i < interactiveObjs.Count; i++)
            {
                if (HitBox.Intersects((interactiveObjs[0].getHitbox())))
                {  crateContact = true;  }
                else
                {   crateContact = false; }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }


        public override void update()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        #region  get/Sets

        public override bool getGrav()
        {
            return gravity;
        }

        #endregion
    }
}
