using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EngineV2.Buttons
{
    public interface IButton
    {
        void Initialize(Texture2D tex, Vector2 Posn);
        void Draw(SpriteBatch spriteBatch);
    }
}
