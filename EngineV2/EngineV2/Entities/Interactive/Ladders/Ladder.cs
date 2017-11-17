using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Collision_Management;
using EngineV2.Input;
using EngineV2.Input_Managment;

namespace EngineV2.Entities
{
    /*
    *
    *when player comes into contact with this entity they can go and and down on the y axis
    *
    */
    class Ladder : GameEntity
    {
        #region Instance Variables

        public string tag = "Ladder";

        //Input Management
        private KeyboardState keyState;
        private InputManager inputMgr;

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
            inputMgr = InputManager.GetInputInstance;
            collisionMgr = CollisionManagerSingleton.GetColliderInstance;

            inputMgr.AddListener(OnNewInput);
            collisionMgr.subscribe(onCollision);

            //CALL COLLIDABLEOBJS()
            CollidableObjs();
            _collider.isInteractiveCollidable(this);
        }
        #region EVENTS

        //INITIALISE EVENT HANDLERS

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

            for (int i = 0; i < playerObj.Count; i++)
            {
                if (HitBox.Intersects(playerObj[i].getHitbox()) && playerObj[i].getTag() == "Player")
                {
                    Player.canClimb = true;
                }

                Player.canClimb = false;
            }


        }
        #endregion
        #endregion

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public override void update(GameTime game)
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
