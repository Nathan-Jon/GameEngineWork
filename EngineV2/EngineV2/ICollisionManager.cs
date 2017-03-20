using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2
{
    interface ICollisionManager
    {
        void Initalize(IEntity ent);
        void Update();
        void OutofBounds();
        void hitEnt();
        void hitobject();
    }
}
