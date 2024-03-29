﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;

namespace Engine.Managers
{
    public sealed class BehaviourManager: IBehaviourManager, IProvider
    {

        public BehaviourManager()
        {

        }

        public static List<IBehaviour> behaviours = new List<IBehaviour>();

        public void update()
        {
            for (int i = 0;i < behaviours.Count; i++)
            {
                behaviours[i].update();
            }
        }

        public T createMind<T>(IEntity ent) where T : IBehaviour, new()
        {
            T Mind = new T();
            Mind.Initialise(ent);
            behaviours.Add(Mind);
            return Mind;
        }

        public void removeMind(IBehaviour mind)
        {
            behaviours.Remove(mind);
        }
    }
}