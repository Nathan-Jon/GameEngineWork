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
        void setTexPos(Texture2D Tex, float Xpos, float Ypos);
        void Draw(SpriteBatch spriteBatch);
        void update();
        float getXPos();
        

    }
}
