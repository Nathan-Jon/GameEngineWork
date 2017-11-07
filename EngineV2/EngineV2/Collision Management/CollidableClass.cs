using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Interfaces;

namespace EngineV2.Collision_Management
{
    sealed class CollidableClass : ICollidable
    {

        #region CREATE LISTS
        List<IEntity> CollidableObj = new List<IEntity>();
        List<IEntity> InteractiveObj = new List<IEntity>();
        List<IEntity> playerObjs = new List<IEntity>();
        List<IEntity> environmentObjs = new List<IEntity>();

        #endregion

        #region ADD TO LISTS
        public void isCollidableEntity(IEntity obj)
        {
            CollidableObj.Add(obj);
        }

        public void isInteractiveCollidable(IEntity obj)
        {
            InteractiveObj.Add(obj);
        }

        public void isPlayerEntity(IEntity obj)
        {
            playerObjs.Add(obj);
        }

        public void isEnvironmentCollidable(IEntity obj)
        {
            environmentObjs.Add(obj);
        }
        #endregion

        #region GET LISTS
        public List<IEntity> getEntityList()
        {
            return CollidableObj;
        }
        public List<IEntity> getInteractiveObj()
        {
            return InteractiveObj;
        }
        public List<IEntity> getPlayableObj()
        {
            return playerObjs;
        }
        public List<IEntity> getEnvironment()
        {
            return environmentObjs;
        }
        #endregion
    }
}
