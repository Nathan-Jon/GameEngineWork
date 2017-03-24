using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace EngineV2
{
    class Player : GameEntity
    {

        public Texture2D Texture;
        public static Vector2 Position;
        float speed = 6;
        public Rectangle HitBox;

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
        public override void Move()
        {
           Position.X += speed;
        }
        public override void update()
        {
            
            //Move();
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public override float getXPos()
        {
            return Position.X;
        }

        public override float getYPos()
        {
            return Position.Y;
        }

        public override Rectangle getHitbox()
        {
            return HitBox;
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
