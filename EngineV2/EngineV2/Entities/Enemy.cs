﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;

namespace EngineV2.Entities
{
    class Enemy : GameEntity
    {

        public Texture2D Texture;
        public static Vector2 Position;
        public Rectangle HitBox;

        private IMoveBehaviour Move;


        public override void setTexPos(Texture2D Tex, Vector2 Posn)
        {
            Position = Posn;
            Texture = Tex;
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }

        
        public override void update()
        { 
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public override Vector2 getPos()
        {
            return Position;
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
