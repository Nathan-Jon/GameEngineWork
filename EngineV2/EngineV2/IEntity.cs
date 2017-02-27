using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    interface IEntity
    {
        void setPos(float Xpos, float Ypos);
        void setTex(Texture2D Tex);
        void Draw(SpriteBatch spriteBatch);

    }
}
