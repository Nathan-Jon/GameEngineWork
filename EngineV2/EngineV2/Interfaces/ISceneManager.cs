using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2.Interfaces
{
    interface ISceneManager
    {
        void Initalize(IEntity ent, ICollisionManager col, IBehaviourManager behav, IInputManager imput);
        void addScn(Texture2D Scene);
    }
}
