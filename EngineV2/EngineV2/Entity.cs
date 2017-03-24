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
        public abstract void setTexPos(Texture2D Tex, float Xpos, float Ypos);        
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void update();
        public abstract float getXPos();
        public abstract float getYPos();
        public abstract Rectangle getHitbox();
        public abstract void setXPos(float Xpos);
        public abstract void setYPos(float Ypos);
        

    }
}
