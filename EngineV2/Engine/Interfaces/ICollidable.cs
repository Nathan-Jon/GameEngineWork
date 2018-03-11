using System;
using System.Collections.Generic;
using Engine.Interfaces;

namespace Engine.Interfaces
{
    
    public interface ICollidable
    {

        void isCollidableEntity(IEntity obj);
        void isInteractiveCollidable(IEntity obj);
        void isEnvironmentCollidable(IEntity obj);
        void isPlayerEntity(IEntity obj);

        List<IEntity> getCollidableList();
        List<IEntity> getInteractiveObj();
        List<IEntity> getEnvironment();
        List<IEntity> getPlayableObj();
    }
}
