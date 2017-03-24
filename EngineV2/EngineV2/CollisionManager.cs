using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    class CollisionManager : ICollisionManager
    {

        IEntity entity;
        int screenWidth, screenHeight;
        public List<IEntity> EntitiesCols = new List<IEntity>();



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
            hitEnt();
        }

        public void OutofBounds()
        {
            for (int i = 0; i < EntitiesCols.Count; i++)
            {

                if (EntitiesCols[i].getXPos() >= 875)
                {
                    EntitiesCols[i].setXPos(875);
                }
                if (EntitiesCols[i].getXPos() <= 0)
                {
                    EntitiesCols[i].setXPos(0);
                }

                if (EntitiesCols[i].getYPos() >= 565)
                {
                    EntitiesCols[i].setYPos(565);
                }
                if (EntitiesCols[i].getYPos() <= 0)
                {
                    EntitiesCols[i].setYPos(0);
                }
            }
        }

        public void hitEnt()
        { 
                if(EntitiesCols[0].getHitbox().Intersects(EntitiesCols[1].getHitbox()))
                {
                    EntitiesCols[1].setXPos(400);
                }
            
        }

        public void hitobject()
        {

        }

    }
}
