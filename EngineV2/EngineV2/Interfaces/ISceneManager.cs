using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    interface ISceneManager
    {
        void Initalize(IEntity ent, SpriteBatch spriteBatch, ICollisionManager col);
        void Update();
        void Draw();
    }
}
