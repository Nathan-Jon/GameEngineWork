using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    class CollisionManager : ICollisionManager
    {

        IEntity entity;
        int screenWidth, screenHeight;
        float facing = -1;
        public static Boolean Hit = false;
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

                if (EntitiesCols[i].getPos().X >= screenWidth)
                {
                    Behaviours.EnemyMind.speed = Behaviours.EnemyMind.speed * facing;
                    
                    
                }
                if (EntitiesCols[i].getPos().X <= 0)
                {
                    Behaviours.EnemyMind.speed = Behaviours.EnemyMind.speed * facing;
                }

                if (EntitiesCols[i].getPos().Y >= screenHeight)
                {
                    EntitiesCols[i].setYPos(565);
                }
                if (EntitiesCols[i].getPos().Y <= 0)
                {
                    EntitiesCols[i].setYPos(0);
                }
            }
        }

        public void hitEnt()
        { 
                if(EntitiesCols[0].getHitbox().Intersects(EntitiesCols[1].getHitbox()))
                {
                SceneManager.onScnEnts.Clear();
                }
            
        }

        public void hitobject()
        {

        }

    }
}
