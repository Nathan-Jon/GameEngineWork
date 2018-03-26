using System;

namespace Engine.StateMachines.StateTranstions
{
    internal class MethodTransition
    {
        //Target State 
        public  string TargetState { get; }

        // stores the method needed for the transition check
        private  Func<bool> CallMethod;

        //Hold the target value
        private bool TargetBool;

        /// <summary>
        /// Costructor for method Transitions
        /// </summary>
        /// <param name="stateTarget"></param>
        /// <param name="methodCall"></param>
        /// <param name="targetBool"></param>
        public MethodTransition(string stateTarget, Func<bool> methodCall, bool targetBool)
        {
            TargetState = stateTarget;
            CallMethod = methodCall;
            TargetBool = targetBool;
        }

        /// <summary>
        /// Look to see whether or not the transition is a valid value
        /// </summary>
        /// <returns></returns>
        public bool CheckTransition()
        { 
            var response = CallMethod.Invoke(); //Invoke the method from the CallMethod
            return response == TargetBool; //
        }
    }
}
