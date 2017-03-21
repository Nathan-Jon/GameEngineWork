using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    public interface IEntity
    {
        void setTexPos(Texture2D Tex, float Xpos, float Ypos);
        void Draw(SpriteBatch spriteBatch);
        void update();
        float getXPos();
        float getYPos();
        void setXPos(float Xpos);
        void setYPos(float Ypos);


    }
}
