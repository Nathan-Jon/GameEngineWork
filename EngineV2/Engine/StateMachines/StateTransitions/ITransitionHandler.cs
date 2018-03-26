using System;

namespace Engine.StateMachines.StateTranstions
{
    /// <summary>
    /// Interface for the Transition Handler Class
    /// </summary>
    internal interface ITransitionHandler
    {

        /// <summary>
        /// Store a Transiion with a Method Condition
        /// </summary>
        /// <param name="stateTarget"></param>
        /// <param name="method"></param>
        /// <param name="expectedResult"></param>
        void StoreMethodTransition(string stateTarget, Func<bool> method, bool expectedResult);

        /// <summary>
        /// Look to see whether Transition Method parameters have been met
        /// </summary>
        /// <returns></returns>
        string CheckMethodTransition();
    }
}
