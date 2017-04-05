using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;
using EngineV2.Managers;

namespace EngineV2.Entities
{
    class Player : GameEntity
    {

        public Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;

        public float speed = 3;

        //Input Management
        private KeyboardState keyState;
        InputManager inputMgr;
        // InputPublisher inputPublisher; //Input publisher
        // InputSubscriber subscribe;  //InputSubscriber

        public override void Initialize(Texture2D Tex, Vector2 Posn)
        {
            Position = Posn;
            Texture = Tex;
            inputMgr.AddListener(OnNewInput);

        }

        public override void setInputMgr(InputManager inputManager)
        {
            inputMgr = inputManager;
        }
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;

            //Act on the data
            if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
            { Position.Y -= speed; }
            if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            { Position.Y += speed; }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            { Position.X += speed; }
            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            { Position.X -= speed; }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public override void update()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, AnimationMgr.Width, AnimationMgr.Height);
        }

        public override Vector2 getPos()
        {
            return Position;
        }

        //public override float

        public override Texture2D getTex()
        {
            return Texture;
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
