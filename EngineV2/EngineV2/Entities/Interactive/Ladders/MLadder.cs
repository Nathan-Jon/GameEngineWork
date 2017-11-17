using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Collision_Management;
using EngineV2.Entities;
using EngineV2.Input;
using EngineV2.Input_Managment;

namespace EngineV2.Entities
{
    /*
    *
    *when player comes into contact with this entity they can go and and down on the y axis
    *
    */
    class MLadder : GameEntity
    {
        #region Instance Variables

        public string tag = "Ladder";

        //Input Management
        private KeyboardState keyState;
        private InputManager InputMgr;

        //Collision Management Variables
        private IEntity collisionObj;
        private CollisionManagerSingleton collisionMgr;
        private ICollidable colliders;
        private List<IEntity> playerObj;

        #endregion

        //OnKeyboard Event Change scene

        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            colliders = _collider;

            //SUBSCRIBERS
            InputMgr = InputManager.GetInputInstance;
            InputMgr.AddListener(OnNewInput);
            collisionMgr.subscribe(onCollision);

            //CALL COLLIDABLEOBJS()
            collisionMgr = CollisionManagerSingleton.GetColliderInstance;

            CollidableObjs();
            _collider.isInteractiveCollidable(this);
        }
        #region EVENTS

        #region INPUT
        //INPUT EVENTS
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
        }
        #endregion
        #region COLLISIONS
        //INITIALISE INTERACTIVEOBJS LIST
        public override void CollidableObjs()
        {
            playerObj = colliders.getPlayableObj();
        }

        //COLLISION EVENTS
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

        }
        #endregion
        #endregion

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public override void update()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
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
    }
}
