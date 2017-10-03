using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Interfaces;

namespace EngineV2.Behaviours.Player_Behaviours
{
    interface IPlayerBehaviour
    {
        void initialise(IEntity ent);
    }
}
