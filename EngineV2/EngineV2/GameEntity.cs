using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    class GameEntity : Entity
    {
        public Texture2D Texture;
        Vector2 Position;

        public override void setTexPos(Texture2D Tex, float Xpos, float Ypos)
        {
            Position.X = Xpos;
            Position.Y = Ypos;
            Texture = Tex;
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public virtual void Move()
        {
            Position.X += 4;
        }

        public override void update()
        {
            Move();
        }

        public override float getXPos()
        {
            return Position.X;
        }

    }
}
