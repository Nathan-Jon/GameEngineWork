using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Interfaces;

namespace EngineV2.Collision_Management
{
    class CollidableClass : ICollidable
    {
        List<IEntity> CollidableObj = new List<IEntity>();
        List<IEntity> InteractiveObj = new List<IEntity>();

        public void isCollidableEntity(IEntity obj)
        {
            CollidableObj.Add(obj);
        }

        public void isInteractiveCollidable(IEntity obj)
        {
            InteractiveObj.Add(obj);
        }

    public List<IEntity> getEntityList()
        {
            return CollidableObj;
        }

        public List<IEntity> getInteractiveObj()
        {
            return InteractiveObj; 
        }
    }
}
