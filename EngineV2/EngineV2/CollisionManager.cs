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
        public List<IEntity> EntitiesCols = new List<IEntity>();

        public CollisionManager()
        {

        }

        public void Initalize(IEntity ent, int scnWid,int scnHei)
        {
            entity = ent;
            EntitiesCols.Add(entity);
            screenWidth = scnWid;
            screenHeight = scnHei;
        }

        public void Update()
        {
            OutofBounds();
        }

        public void OutofBounds()
        {
            for (int i = 0; i < EntitiesCols.Count; i++)
            {

                if (EntitiesCols[i].getXPos() >= 750)
                {
                    EntitiesCols[i].setXPos(750);
                }
                if (EntitiesCols[i].getXPos() <= 0)
                {
                    EntitiesCols[i].setXPos(0);
                }

                if (EntitiesCols[i].getYPos() >= 450)
                {
                    EntitiesCols[i].setYPos(450);
                }
                if (EntitiesCols[i].getYPos() <= 0)
                {
                    EntitiesCols[i].setYPos(0);
                }
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
