using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine
{
    interface IEntity
    {
        void setPos(float Xpos, float Ypos);
        void setTex(Texture2D tex);
        void move();
        void DrawEnt(SpriteBatch spriteBatch);
        void CollisionDetection();
        void Hitbox();
        

    }
}
