using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EngineV2.Buttons
{
    class StartButton
    {
        public Texture2D Texture;
        public Vector2 Position;

        public void Initialize(Texture2D tex, Vector2 Posn)
        {
            Texture = tex;
            Position = Posn;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);

        }
    }
}
