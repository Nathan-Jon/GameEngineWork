using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2
{
    class CollisionManager : ICollisionManager
    {

        public static float mFacingdirection = 1;
        IEntity entity;

        public CollisionManager()
        {

        }

        public void Initalize(IEntity ent)
        {
            entity = ent;
        }

        public void Update()
        {
            OutofBounds();
        }

        public void OutofBounds()
        {

            if (entity.getXPos() >= 750 || entity.getXPos() <= 0)
            {
                mFacingdirection = mFacingdirection * -1;
            }
        }

        public void hitEnt()
        {

        }

        public void hitobject()
        {

        }

    }
}
