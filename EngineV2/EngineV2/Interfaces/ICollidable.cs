using System;
using System.Collections.Generic;
using EngineV2.Interfaces;

namespace EngineV2.Interfaces
{
    
    public interface ICollidable
    {

        void isCollidable(IEntity obj);
        List<IEntity> getList();

    }
}
