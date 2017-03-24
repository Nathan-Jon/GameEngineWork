using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2.Behaviours
{
    class xMoveBehaviour : IMoveBehaviour
    {
        //Instance Variables
        private float speed = 1;
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
            body.setXPos(body.getXPos() + speed);
        }
    }
        #endregion
}

