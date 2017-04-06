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

        public void isCollidable(IEntity obj)
        {
            CollidableObj.Add(obj);
        }

        public List<IEntity> getList()
        {
            return CollidableObj;
        }
    }
}
