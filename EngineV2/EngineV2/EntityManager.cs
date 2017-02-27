﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    class EntityManager : IEntityManager
    {
        List<IEntity> Entities;
        
        
        //Create Entities.. ADhoc aprroach/Generics
        
        public void CreateEnt<T>(ref T rqdclass)
        {
            T temp;
            temp = rqdclass;

        }

        public void AddEnt(IEntity Ent)
        {
            Entities.Add(Ent);
        }

        public void RemoveEnt(IEntity Ent)
        {
            Entities.Remove(Ent);
        }

    }
}