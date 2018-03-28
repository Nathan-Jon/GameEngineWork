using Engine.Collision_Management;
using Engine.Interfaces;
using Engine.Managers;
using Engine.Service_Locator;
using Microsoft.Xna.Framework;
using ProjectHastings.Animations;
using ProjectHastings.Behaviours;

namespace ProjectHastings.Entities.Enemies
{
    class Thug : GamePhysicsEntity
    {
        public IAnimations ani;
        public int row = 1;

        private IEntity collisionObj;

        private EnemyMind mind;

        ICollisionManager coli = Locator.Instance.getProvider<CollisionManager>() as ICollisionManager;

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            Tag = "thug";
            ani = new ThugAnimation();
            ani.Initialize(this, 3, 3);
            mind = new EnemyMind();
            mind.Initialise(this);
            _Collisions.isCollidableEntity(this);
            coli.subscribe(onCollision);


        }

        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            //if (Hitbox.X > 850)
            //{
            //    Position = new Vector2(849, Position.Y);
            //    row = 0;
            //    Behaviours.EnemyMind.speed *= -1;
            //}
            //if (Hitbox.X < 0)
            //{
            //    Position = new Vector2(1, Position.Y);
            //    row = 1;
            //    Behaviours.EnemyMind.speed *= -1;
            //}

        }


        public override void Update(GameTime game)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

            ani.Update(game);
            mind.Update();
        }

        public override int getRows()
        {
            return row;
        }

        public override void setRow(int rows)
        {
            row = rows;
        }
    }
}