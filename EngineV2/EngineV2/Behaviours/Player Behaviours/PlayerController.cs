using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Input;
using EngineV2.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace EngineV2.Behaviours.Player_Behaviours
{
    class PlayerController
    {
        private KeyboardState keyState;
        private InputManager inputMgr;

        private IEntity body;
        private float speed = 4;

        public void Initialise(IEntity entity)
        {
            body = entity;
        }

        public void move()
        {
            body.setXPos(body.getPos().X + speed);
        }
        
        //public virtual void OnnNewInput(object source, EventData data)
        //{
        //    keyState = data.newKey;

        //    if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
        //    {

        //        speed = -4;
        //        body.setXPos(body.getPos().X + speed);
        //       // body.Animate = true;
        //       //row = 0;
        //       //sound.Playsnd(1);
        //    }
        //}
    }
}
