using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    class Ball : GameEntity
    {

        Texture2D Texture;
        Vector2 Position;

        public void setPos(float Xpos, float Ypos)
        {
            Position.X = Xpos;
            Position.Y = Ypos;

        }
        public void setTex(Texture2D Tex)
        {
            Texture = Tex;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public void Move()
        {
            Position.X += 1;
        }

    }
}
