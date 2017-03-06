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
        void Update();
        void Draw(IEntity Entity, Vector2 Posn);
    }
}
