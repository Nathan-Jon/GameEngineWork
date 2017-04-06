using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2.Interfaces
{
    interface ICollisionManager
    {
        void Initalize(IEntity ent, int scnWid, int scnHei, IAnimationMgr animation);
        void Update();
        void OutofBounds();
        void hitEnt();
        void hitobject();
    }
}
