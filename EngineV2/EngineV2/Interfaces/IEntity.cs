using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;
using EngineV2.Collision_Management;

namespace EngineV2.Interfaces
{
    public interface IEntity
    {
        void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd);
        void Draw(SpriteBatch spriteBatch);
        void update();
        Vector2 getPos();
        Texture2D getTex();
        int getRows();
        Rectangle getHitbox();
        void setXPos(float Xpos);
        void setYPos(float Ypos);
        void setRow(int row);
        void applyEventHandlers(InputManager inputManager, CollisionManager collisions);
        void CollidableObjs();

    }
}
