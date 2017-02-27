using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    abstract class Entity : IEntity
    {
        public abstract void setPos(float Xpos, float Ypos);
        public abstract void setTex(Texture2D Tex);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
