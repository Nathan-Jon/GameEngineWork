using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Interfaces;

namespace EngineV2.Behaviours
{
    class xMoveBehaviour : IMoveBehaviour
    {
        //Instance Variables
        private float facingDirection = -1;

        //Instance Constants
        private IEntity body;

        #region Constructor
        public xMoveBehaviour(IEntity Ent)
        {
            body = Ent;
        }
        #endregion

        #region Behaviour
        public void move(IEntity body, float speed)
        {
            body.setXPos(body.getPos().X + speed);
        }
    }
        #endregion
}

