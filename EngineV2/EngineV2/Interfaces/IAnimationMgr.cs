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
        void Initialize(IEntity ent, int rows, int columns);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void setRow(int rownum);
    }
}
