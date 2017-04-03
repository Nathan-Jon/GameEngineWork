using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    class AnimationMgr : IAnimationMgr
    {
        public Texture2D Texture;
        public int Rows, Columns;
        private int currentFrame, totalFrames;

        public void Initalise(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
             currentFrame++;
             if(currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 Posn)
        {
            int Width = Texture.Width / Columns;
            int Height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)Posn.X, (int)Posn.Y, Width, Height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
