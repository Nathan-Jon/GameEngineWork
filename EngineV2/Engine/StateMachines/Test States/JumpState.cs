using System;
using Engine.Physics;

namespace Engine.StateMachines.TestStates
{
    class JumpState<T>: IState<T> where T : IPhysics
    {

        public bool success { get; }

        public void Enter(T entity)
        {
            entity.GravityBool = false;
            Console.WriteLine("SUCCESS ON ENTERING JUMP STATE");
        }

        public void Update(T entity)
        {
          //  throw new NotImplementedException();
        }

        public void Exit(T entity)
        {
            Console.WriteLine("Leaving Jump state");

        }
    }
}
