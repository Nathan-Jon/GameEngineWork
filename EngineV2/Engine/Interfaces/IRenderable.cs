using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Interfaces
{
    public interface IRenderable
    {
        void Draw(IScene scene, SpriteBatch sprite);
    }
}
