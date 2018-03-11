using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine.Interfaces
{
    public interface IBehaviourManager
    {
        void update();
        T createMind<T>(IEntity ent) where T : IBehaviour, new();
    }
}
