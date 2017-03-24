using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineV2.Behaviours;

namespace EngineV2.Minds
{
    class EnemyMind : IBehaviour
    {
        private IMoveBehaviour move;
        private IEntity body;

        public float speed = 6;

        public EnemyMind()
        {
        }

        public void Initialise(IEntity Ent)
        {
            body = Ent;
            move = new xMoveBehaviour(body);
        }

        public void update()
        {
            move.move(body,speed);
        }
    }
}
