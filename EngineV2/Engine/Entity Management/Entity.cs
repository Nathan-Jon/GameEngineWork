using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Interfaces;
using Engine.Collision_Management;


namespace Engine.Entity_Management
{
    public abstract class Entity : IEntity
    {
        public abstract void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, IBehaviourManager behaviours);

        public abstract void Update(GameTime game);
        public abstract Rectangle Hitbox { get; set; }
        public abstract string Tag { get; set; }

        public abstract void CollidableObjs();
        public abstract void UniqueData();

        //Animations
        public abstract int getRows();
        public abstract void setRow(int row);
        public abstract float Direction { get; set; }

        //Virtual Variables
        public virtual Vector2 Position { get; set; }
        public abstract Texture2D Texture { get; set; }

        //Virtual Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite); //Draws the entity onto the scene
        }

    }
}

