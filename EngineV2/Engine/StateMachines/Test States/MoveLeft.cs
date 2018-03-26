using System;
using Engine.Physics;
using Microsoft.Xna.Framework;

namespace Engine.StateMachines.TestStates
{
    public class MoveLeft<T> : IState<T> where T: IPhysics
    {
        public bool success { get; }

        public void Enter(T entity)
        {
            entity.ApplyForce(new Vector2(5,0));
        }

        public void Update(T entity)
        {
            entity.ApplyForce(new Vector2(-5, 0));
        }

        public void Exit(T entity)
        {
            Console.WriteLine("Living life to the fullest");
        }
    }
}
