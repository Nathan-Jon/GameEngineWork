using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Interfaces
{
    public interface IBehaviour
    {
        void update();
        void Initialise(IEntity ent);
    }
}
