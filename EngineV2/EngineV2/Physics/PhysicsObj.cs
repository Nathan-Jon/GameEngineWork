using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Interfaces;

namespace EngineV2.Physics
{
    class PhysicsObj : IPhysicsObj
    {
        List<IEntity> isNewtonian = new List<IEntity>();

        public void hasPhysics(IEntity obj)
        {
            isNewtonian.Add(obj);
        }

        public void gravity()
        {

            for (int i = 0; i < isNewtonian.Count; i++)
            {
                if( isNewtonian[i].getGrav() == true)
                    {
                    isNewtonian[i].setYPos(isNewtonian[i].getPos().Y + 3);
                    }
            }
        }
        public List<IEntity> getPhysicsList()
        {
            return isNewtonian;
        }


    }
}

