using EngineV2.Interfaces;

namespace EngineV2.Behaviours
{
    class EnemyMind : IBehaviour
    {
        private IMoveBehaviour move;
        private IEntity body;

        public static float speed = 4;

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
