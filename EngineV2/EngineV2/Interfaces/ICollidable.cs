using System;
using System.Collections.Generic;
using EngineV2.Interfaces;

namespace EngineV2.Interfaces
{
    
    public interface ICollidable
    {

        void isCollidableEntity(IEntity obj);
        void isInteractiveCollidable(IEntity obj);
        List<IEntity> getEntityList();
        List<IEntity> getInteractiveObj();

    }
}
