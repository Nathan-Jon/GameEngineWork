﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;


namespace EngineV2.Entities
{
    class GameEntity : Entity
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;

        public override void Initialize(Texture2D Tex, Vector2 Posn)
        {
            Position = Posn;
            Texture = Tex;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public override void setInputMgr(InputManager inputManager)
        { }

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