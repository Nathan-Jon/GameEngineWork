using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineV2.Interfaces;

namespace EngineV2.Buttons
{
    public interface IButton
    {
        void Initialize(Texture2D tex, Vector2 Posn, ISoundManager sound);
        void Draw(SpriteBatch spriteBatch);
        Vector2 GetButtonPos();
        void update();
        Rectangle getHitbox();
        void click();
    }
}
