using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Collision_Management;


namespace Engine.Interfaces
{
    public interface IEntity
    {
        void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, IBehaviourManager behaviours);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime game);
        Vector2 Position { get; set; }
        Texture2D Texture { get; set; }
        Rectangle Hitbox { get; set; }
        string Tag { get; set; }
        float Direction { get; set; }
        void CollidableObjs();
        void UniqueData();


        //Animations 
        void setRow(int row);
        int getRows();

    }
}
