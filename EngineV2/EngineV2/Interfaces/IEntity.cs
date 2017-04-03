using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;

namespace EngineV2.Interfaces
{
    public interface IEntity
    {
        void Initialize(Texture2D Tex, Vector2 Posn);
        void Draw(SpriteBatch spriteBatch);
        void update();
        Vector2 getPos();
        Rectangle getHitbox();
        void setXPos(float Xpos);
        void setYPos(float Ypos);
        void setInputMgr(InputManager inputManager);


    }
}
