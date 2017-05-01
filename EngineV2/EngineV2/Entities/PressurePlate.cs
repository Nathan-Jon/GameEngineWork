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
    class PressurePlate : GameEntity
    {
        public string tag = "PressurePlate";
        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        private float moveDirec = 3;
        private bool moveObject = false;
        private bool canMove = true;
        private bool crateContact = false;

        //Physics
        public bool gravity = true;
        public Vector2 OriginalPosition;

        //Input Management
        private KeyboardState keyState;
        private InputManager input;

        //Collision Management
        private IEntity collisionObj;
        private CollisionManager collisionMgr;
        private ICollidable colliders;
        private ISoundManager sound;
        IPhysicsObj physics;

        //Lists
        private List<IEntity> physicsObj;
        private List<IEntity> environementObjs;
        private List<IEntity> interactiveObj;
        private IEntity triggerWall;



        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            colliders = _collider;
            sound = snd;
            physics = phys;
            input.AddListener(OnNewInput);
            collisionMgr.subscribe(onCollision);
            CollidableObjs();
            _collider.isInteractiveCollidable(this);
        }

        public override void applyEventHandlers(InputManager inputManager, CollisionManager collisions)
        {
            input = inputManager;
            collisionMgr = collisions;
        }

        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
        }

        //List of Collidable Objects
        public override void CollidableObjs()
        {
            //physicsObj = physics.getPhysicsList();
            environementObjs = colliders.getEnvironment();
            interactiveObj = colliders.getInteractiveObj();
        }

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
              //  else reset();

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
            OriginalPosition.Y = triggerWall.getPos().Y;
            triggerWall.setYPos(700);
        }

        public void reset()
        { triggerWall.setYPos(OriginalPosition.Y); }

        #endregion


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }

        public override void update()
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