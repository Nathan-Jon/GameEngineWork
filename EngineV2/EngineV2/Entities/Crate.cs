﻿using System;
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
        private bool canMove = true;
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
        private ISoundManager sound;
        //Lists
        private List<IEntity> interactiveObjs;
        private List<IEntity> player;
        private List<IEntity> terrain;



        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            colliders = _collider;
            sound = snd;
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
            if (crateContact && keyState.IsKeyDown(Keys.H) || crateContact && keyState.IsKeyDown(Keys.Enter))
            {

                moveObject = true;
                sound.Volume(2, 0.2f);

                if (moveObject && canMove && keyState.IsKeyDown(Keys.D) || moveObject && keyState.IsKeyDown(Keys.Right))
                {
                    Position.X += 3;
                    sound.Playsnd(2);
                }
                if (moveObject && keyState.IsKeyDown(Keys.A) || moveObject && keyState.IsKeyDown(Keys.Left))
                {
                    Position.X += -3;
                    sound.Playsnd(2);
                }

            }

            if (crateContact == false)
            {
                sound.Stopsnd(2);
            }
        }

        //List of Collidable Objects
        public override void CollidableObjs()
        {
            //interactiveObjs = colliders.getEntityList();
            player = colliders.getPlayableObj();
            //terrain = colliders.getTerrain();
        }

        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

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
                if (HitBox.Intersects((player[0].getHitbox())))
                { crateContact = true; }
                else
                { crateContact = false; }
            }
            //for (int i = 0; i < terrain.Count; i++)
            //{
            //    if (HitBox.Intersects(terrain[i].getHitbox()))
            //    {
            //        gravity = false;
            //    }
            //}
            gravity = true;
            #endregion
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
