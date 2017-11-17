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
using EngineV2.Behaviours;

namespace EngineV2.Entities
{
    class Enemy : GameEntity
    {

        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        public int row = 1;

        private IEntity collisionObj;
        private IMoveBehaviour Move;
        private CollisionManagerSingleton collisionMgr;


        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            collisionMgr = CollisionManagerSingleton.GetColliderInstance;
            collisionMgr.subscribe(onCollision);
            _collider.isCollidableEntity(this);
            Position = Posn;
            Texture = Tex;
            behaviours.createMind<EnemyMind>(this);
            phys.hasPhysics(this);
        }

        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            if (HitBox.X > 850)
            {
                Position.X = 849;
                row = 0;
                Behaviours.EnemyMind.speed *= -1;
                
            }
            if (HitBox.X < 0)
            {
                Position.X = 1;
                row = 1;
                Behaviours.EnemyMind.speed *= -1;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }


        public override void update(GameTime game)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
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
    }
}
