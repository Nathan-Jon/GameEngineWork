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

        public static Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        public int row = 1;
        public static Boolean Animate = false;

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
            { 
                Position.Y -= speed;
                Animate = true;
                row = 2;
            }
            if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            { 
                Position.Y += speed;
                Animate = true;
                row = 2;
            }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            { 
                Position.X += speed;
                Animate = true;
                row = 1;
            }
            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            { 
                Position.X -= speed;
                Animate = true;
                row = 0;
            }
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

        public override Texture2D getTex()
        {
            return Texture;
        }

        public override int getRows()
        {
            return row;
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

        public override void setRow(int rows)
        {
            row = rows;
        }


    }
}
