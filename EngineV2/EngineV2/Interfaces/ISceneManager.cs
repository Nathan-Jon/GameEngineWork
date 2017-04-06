using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;

namespace EngineV2.Interfaces
{
    interface ISceneManager
    {
        void Initalize(IEntity ent, IBehaviourManager behav, IAnimationMgr ani);
    }
}
