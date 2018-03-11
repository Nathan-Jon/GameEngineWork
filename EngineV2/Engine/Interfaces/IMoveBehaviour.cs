using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Interfaces
{
    public interface IMoveBehaviour
    {
        void move(IEntity ent, float speed);
    }
}
