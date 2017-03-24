using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    interface IEntityManager
    {
        T CreateEnt<T>() where T : IEntity, new();  
        void AddEnt(IEntity Ent);
        void RemoveEnt(IEntity Ent);
        

    }
}
