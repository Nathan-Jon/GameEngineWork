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
        public static Vector2 Position;
        float speed = 6;

        public override void setTexPos(Texture2D Tex, float Xpos, float Ypos)
        {
            Position.X = Xpos;
            Position.Y = Ypos;
            Texture = Tex;
        }
        
        public Vector2 getPos
        {
            get {return Position; }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public override void Move()
        {
           Position.X += speed* CollisionManager.mFacingdirection;
        }
        public override void update()
        {
            Move();
        }

        public override float getXPos()
        {
            return Position.X;
        }

        public override float getYPos()
        {
            return Position.Y;
        }

        public override void setXPos(float Xpos)
        {
            Position.X = Xpos;

        }
        public override void setYPos(float Ypos)
        {
            Position.Y = Ypos;

        }
    }
}
