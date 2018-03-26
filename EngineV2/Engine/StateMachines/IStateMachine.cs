using System;

namespace Engine.StateMachines
{
    /// <summary>
    /// Interface for State Machine. Used for Adding States an calling the Update
    /// </summary>
    public interface IStateMachine<T>
    {
        void AddState(IState<T> state, string id); //Add States to the state Machine Dictionary

        void AddMethodTransition(Func<bool> methodVal, string stateFrom, string targetState);
        void AddMethodTransition(Func<bool> methodVal, string stateFrom, string targetState, bool successVal);

        void Update();  //Update Methods

    }
}
