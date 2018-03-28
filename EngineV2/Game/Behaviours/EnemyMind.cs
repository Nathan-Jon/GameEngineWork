using Engine.Interfaces;
using Engine.Physics;
using Engine.StateMachines;
using Engine.StateMachines.TestStates;
using Microsoft.Xna.Framework;
using ProjectHastings.Animations;

namespace ProjectHastings.Behaviours
{
    public class EnemyMind
    {
        private IMoveBehaviour move;
        private IPhysics body;
        private IStateMachine<IPhysics> stateMachine;

        public static float speed = 4;

        public EnemyMind()
        {
        }

        public void Initialise(IPhysics Ent)
        {
            body = Ent;
            //move = new xMoveBehaviour(body);
            stateMachine = new StateMachine<IPhysics>(Ent);

            stateMachine.AddState(new MoveLeft<IPhysics>(), "left");
            stateMachine.AddState(new MoveRight<IPhysics>(), "right");

            stateMachine.AddMethodTransition(right, "left", "right");
            stateMachine.AddMethodTransition(left, "right", "left");


        }

        bool left()
        {
            if (body.Position.X <= 0)
            {
                body.Position = new Vector2(1, body.Position.Y);
                return true;
            }
            return false;
        }

        bool right()
        {
            if (body.Position.X + 25 >= 850)
            {
                body.Position = new Vector2(824, body.Position.Y);
                return true;
            }
            return false;
        }

        public void Update()
        {
            
            stateMachine.Update();
        }

    }
}


