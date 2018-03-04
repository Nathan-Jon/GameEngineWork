using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineV2.Interfaces;

namespace EngineV2.BackGround
{
    public class BackGrounds :IBackGrounds
    {
        public static IDictionary<string, Texture2D> Backgrounds = new Dictionary<string, Texture2D>();
        public Rectangle Size;
        string B;

        public BackGrounds(int width, int height)
        {
            Size = new Rectangle(0, 0, width, height); 
        }

        public void Initialize(string BackgroundName, Texture2D Texture)
        {
            Backgrounds.Add(BackgroundName, Texture);
            B = BackgroundName;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Backgrounds[B], Size, Color.AntiqueWhite);

        }
    }
}
