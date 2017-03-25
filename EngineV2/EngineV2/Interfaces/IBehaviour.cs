using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2.Interfaces
{
    interface IBehaviour
    {
        void update();
        void Initialise(IEntity ent);
    }
}
