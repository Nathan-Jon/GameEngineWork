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
using EngineV2.Entities;
using EngineV2.Input;

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



        //Input Management
        private KeyboardState keyState;
        private InputManager input;

        //Collision Management Variables
        private IEntity collisionObj;
        private CollisionManager collisionMgr;
        private ICollidable colliders;
        private List<IEntity> interactiveObjs;

        #endregion

        //OnKeyboard Event Change scene

        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd)
        {
            Position = Posn;
            Texture = Tex;
            colliders = _collider;

            //SUBSCRIBERS
            input.AddListener(OnNewInput);
            collisionMgr.subscribe(onCollision);

            //CALL COLLIDABLEOBJS()
            CollidableObjs();
        }
        #region EVENTS

        //INITIALISE EVENT HANDLERS
        public override void applyEventHandlers(InputManager inputManager, CollisionManager collisions)
        {
            input = inputManager;
            collisionMgr = collisions;
        }

        //INPUT EVENTS
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
            if (keyState.IsKeyDown(Keys.H) || keyState.IsKeyDown(Keys.Enter))
            {
                //set y move value
            }
        }

        //INITIALISE INTERACTIVEOBJS LIST
        public override void CollidableObjs()
        {
            interactiveObjs = colliders.getEntityList();
        }

        //COLLISION EVENTS
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            for (int i = 0; i < interactiveObjs.Count; i++)
            {
                //checks to see if player is in contact with the ladder 
                if (HitBox.Intersects((interactiveObjs[0].getHitbox())))
                {
                    //set y move action
                }
            }
        }
        #endregion
    }
}
}