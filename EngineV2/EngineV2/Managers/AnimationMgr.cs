using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Entities;

namespace EngineV2.Managers
{
    class AnimationMgr : IAnimationMgr
    {
        public static List<IEntity> Animation = new List<IEntity>();
        public static int  Width, Height;
        private int enemyCurrentFrame, playerCurrentFrame, totalFrames;
        private int timeSinceLastFrame = 0;
        private int MillisecondsPerFrame = 200;
        public int playerRow, enemyRow;
        int Rows, Columns, enemyColumn, playerColumn;
        public static Rectangle enemySourceRectangle, enemyDestinationRectangle, playerSourceRectangle, playerDestinationRectangle;

        public void Initialize(IEntity ent, int rows, int columns)
        {
            Animation.Add(ent);
            Rows = rows;
            Columns = columns;
            enemyCurrentFrame = 0;
            playerCurrentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > MillisecondsPerFrame)
            {
                timeSinceLastFrame -= MillisecondsPerFrame;


                if (Player.Animate == true)
                {
                playerCurrentFrame++;
                Player.Animate = false;
                if (playerCurrentFrame == totalFrames)
                {
                    playerCurrentFrame = 0;
                }
                }
                enemyCurrentFrame++;
                if (enemyCurrentFrame == totalFrames)
                {
                    enemyCurrentFrame = 0;
                }

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < Animation.Count; i++)
            {

                Width = Animation[i].getTex().Width / Columns;
                Height = Animation[i].getTex().Height / Rows;
            }
                playerRow = Animation[0].getRows();
                enemyRow = Animation[1].getRows();


                enemyColumn = enemyCurrentFrame % Columns;
                playerColumn = playerCurrentFrame % Columns;

                enemySourceRectangle = new Rectangle(Width * enemyColumn, Height * enemyRow, Width, Height);
                enemyDestinationRectangle = new Rectangle((int)Animation[1].getPos().X, (int)Animation[1].getPos().Y, Width, Height);

                playerSourceRectangle = new Rectangle(Width * playerColumn, Height * playerRow, Width, Height);
                playerDestinationRectangle = new Rectangle((int)Animation[0].getPos().X, (int)Animation[0].getPos().Y, Width, Height);
            
            
                spriteBatch.Draw(Animation[0].getTex(), playerDestinationRectangle, playerSourceRectangle, Color.White);
                spriteBatch.Draw(Animation[1].getTex(), enemyDestinationRectangle, enemySourceRectangle, Color.White);
            
            
        }
    }
}
