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
using EngineV2.Behaviours;
using EngineV2.Animations;

namespace EngineV2.Entities
{
    class Thug : GameEntity
    {
        public string tag ="Thug";
        public IAnimations ani;
        public Vector2 Position;
        public Rectangle HitBox;
        public int row = 1;

        private IEntity collisionObj;

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            ani = new ThugAnimation();
            ani.Initialize(this, 3, 3);
            _BehaviourManager.createMind<EnemyMind>(this);
            _Collisions.isCollidableEntity(this);
            _PhysicsObj.hasPhysics(this);
            CollisionManager.GetColliderInstance.subscribe(onCollision);


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
            ani.Draw(spriteBatch);
        }


        public override void update(GameTime game)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

            ani.Update(game);

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
        public override string getTag()
        {
            return tag;
        }
    }
}
