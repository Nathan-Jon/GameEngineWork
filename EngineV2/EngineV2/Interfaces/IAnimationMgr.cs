using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EngineV2.Interfaces
{
    interface IAnimationMgr
    {
        void Initalise(Texture2D texture, int rows, int columns);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 Posn);
    }
}
