using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;



namespace EngineV2.Animations
{
    class ThugAnimation : IAnimations
    {
        public static int Width, Height;
        private int CurrentFrame, totalFrames;
        private int timeSinceLastFrame = 0;
        private int MillisecondsPerFrame = 200;
        private int Rows, row, Columns, columns;
        public IEntity entity;
        private Rectangle sourceRectangle, destinationRectangle;

        public void Initialize(IEntity ent, int rows, int columns)
        {
            entity = ent;
            Columns = columns;
            Rows = rows;
        }
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > MillisecondsPerFrame)
            {
                timeSinceLastFrame -= MillisecondsPerFrame;


                CurrentFrame++;

                if (CurrentFrame == totalFrames)
                {
                    CurrentFrame = 0;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {


            Width = entity.getTex().Width / Columns;
            Height = entity.getTex().Height / Rows;

            row = entity.getRows();

            columns = CurrentFrame % Columns;


            sourceRectangle = new Rectangle(Width * columns, Height * row, Width, Height);
            destinationRectangle = new Rectangle((int)entity.getPos().X, (int)entity.getPos().Y, Width, Height);

            spriteBatch.Draw(entity.getTex(), destinationRectangle, sourceRectangle, Color.White);



        }



    }



}

