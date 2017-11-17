using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineV2.Interfaces;
using EngineV2.Collision_Management;


namespace EngineV2.Entities
{
    abstract class Entity : IEntity
    {
        public abstract void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void update(GameTime game);
        public abstract Vector2 getPos();
        public abstract Texture2D getTex();
        public abstract int getRows();
        public abstract Rectangle getHitbox();
        public abstract string getTag();
        public abstract void setXPos(float Xpos);
        public abstract void setYPos(float Ypos);
        public abstract void setRow(int row);
        public abstract void setGrav(bool active);
        public abstract bool getGrav();
        public abstract float getDirection();
        public abstract void accessPhysics(IPhysicsObj obj);
        public abstract void CollidableObjs();


    }
}
