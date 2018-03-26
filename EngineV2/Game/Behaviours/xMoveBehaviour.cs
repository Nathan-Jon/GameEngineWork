using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Interfaces;
using Microsoft.Xna.Framework;

namespace ProjectHastings.Behaviours
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
            body.Position += new Vector2(speed, 0);
        }
    }
        #endregion
}

