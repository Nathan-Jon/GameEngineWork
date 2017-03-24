using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2.Behaviours
{
    class xMoveBehaviour : IMoveBehaviour
    {
        //Instance Variables
        private float baseSpeed = 1;
        private float facingDirection = -1;

        //Instance Constants
        private IEntity body;



        #region Constructor

        // Initialise Class Variables
        public xMoveBehaviour(IEntity Ent)
        {
            body = Ent;
        }
        #endregion

        #region Behaviour

        //move - change the entities xPos, adding the speed float to it
        public void move(IEntity body, float speed)
        {
            body.setXPos(body.getXPos() + speed);
        }
    }
        #endregion
}

