using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2.Interfaces
{
    interface IMoveBehaviour
    {
        void move(IEntity ent, float speed);
    }
}
