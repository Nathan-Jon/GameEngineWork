using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace EngineV2.Interfaces
{
    public interface IAnimations
    {
        void Initialize(IEntity ent, int rows, int columns);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
