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
        public static List<IEntity> Animation = new List<IEntity>();
        public static int  Width, Height;
        private int currentFrame, totalFrames;
        private int timeSinceLastFrame = 0;
        private int MillisecondsPerFrame = 200;
        private int row = 1;
        int Rows, Columns, column;


        public void Initialize(IEntity ent, int rows, int columns)
        {
            Animation.Add(ent);
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > MillisecondsPerFrame)
            {
                timeSinceLastFrame -= MillisecondsPerFrame;

                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Animation.Count; i++)
            {
                Width = Animation[i].getTex().Width / Columns;
                Height = Animation[i].getTex().Height / Rows;
                column = currentFrame % Columns;
                


                Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
                Rectangle destinationRectangle = new Rectangle((int)Animation[i].getPos().X, (int)Animation[i].getPos().Y, Width, Height);

                spriteBatch.Draw(Animation[i].getTex(), destinationRectangle, sourceRectangle, Color.White);
            }
        }
    }
}
