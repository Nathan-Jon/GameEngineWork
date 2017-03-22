using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2
{
    class CollisionManager : ICollisionManager
    {

        IEntity entity;
        int screenWidth, screenHeight;

        public CollisionManager()
        {

        }

        public void Initalize(IEntity ent, int scnWid,int scnHei)
        {
            entity = ent;
            screenWidth = scnWid;
            screenHeight = scnHei;
        }

        public void Update()
        {
            OutofBounds();
        }

        public void OutofBounds()
        {

            if (entity.getXPos() >= 750)
            {
                entity.setXPos(750);
            }
            if (entity.getXPos() <= 0)
            {
                entity.setXPos(0);
            }

            if (entity.getYPos() >= 450)
            {
                entity.setYPos(450);
            }
            if (entity.getYPos() <= 0)
            {
                entity.setYPos(0);
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
