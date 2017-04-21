using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EngineV2.BackGround
{
    class BackGrounds :IBackGrounds
    {

        public Texture2D Texture;
        public Rectangle Size;

        public BackGrounds(int width, int height)
        {
            Size = new Rectangle(0, 0, width, height); 
        }

        public void Initialize(Texture2D tex)
        {
            Texture = tex;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Size, Color.AntiqueWhite);

        }
    }
}
