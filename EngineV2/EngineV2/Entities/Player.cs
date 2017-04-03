using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;


namespace EngineV2.Entities
{
    class Player : GameEntity
    {

        public Texture2D Texture;
        public static Vector2 Position;
        public Rectangle HitBox;

        float speed = 3;

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
            if (keyState.IsKeyDown(Keys.W))
            { Position.Y -= speed; }
            if (keyState.IsKeyDown(Keys.S))
            { Position.Y += speed; }
            if (keyState.IsKeyDown(Keys.D))
            { Position.X += speed; }
            if (keyState.IsKeyDown(Keys.A))
            { Position.X -= speed; }
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
