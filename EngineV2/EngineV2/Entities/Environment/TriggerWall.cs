using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineV2.Interfaces;
using EngineV2.Collision_Management;

namespace EngineV2.Entities
{
    class TriggerWall : GameEntity
    {
        private string tag = "triggerWall";
        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;

        //COLLISIONS
        private IEntity collisionObj;
        private IEntity collision;


        //PHYSICS
        private IPhysicsObj physics;

        //LISTS
        private List<IEntity> physicsObjs;


        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider,  IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            physics = phys;


            CollisionManager.GetColliderInstance.subscribe(onCollision);
            physicsObjs = physics.getPhysicsList();

            //CollidableObjs();

            _collider.isEnvironmentCollidable(this);

        }

        public virtual void onCollision(object source, CollisionEventData data)
        {

            bool onTerrain = false;

            collision = data.objectCollider;

            for (int i = 0; i < physicsObjs.Count; i++)
            {
                //if (HitBox.Intersects(physicsObjs[i].getHitbox()))
                //{ physicsObjs[i].setXPos(physicsObjs[i].getPos().X - 3); }
                if (HitBox.Intersects(physicsObjs[i].getHitbox()))
                {
                    if (physicsObjs[i].getPos().X < HitBox.Width)
                    { physicsObjs[i].setXPos(physicsObjs[i].getPos().X - 3); }
                    if (physicsObjs[i].getPos().X > HitBox.Width/2)
                    { physicsObjs[i].setXPos(physicsObjs[i].getPos().X - 3); }
                }
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
        public override Vector2 getPos()
        { return Position; }
    }
}
