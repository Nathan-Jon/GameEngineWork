

namespace Engine.StateMachines
{
    /// <summary>
    /// Interface required for all State Classes
    /// </summary>
    public interface IState<T>
    {
        bool success { get; }

        void Enter(T entity);    //Called Upon Entrance of State
        void Update(T entity);   //Update method of state
        void Exit(T entity);     //Called upon Exiting of state
    }
}
