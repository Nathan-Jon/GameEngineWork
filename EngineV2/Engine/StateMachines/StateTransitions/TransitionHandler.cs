using System;
using System.Collections.Generic;

namespace Engine.StateMachines.StateTranstions
{
    /// <summary>
    /// Stores the transition Conditions for a stateMachine
    /// </summary>
    internal class TransitionHandler : ITransitionHandler
    {

        //Store all of the method transitions in a list - MethodTransitionHolder
        IList<MethodTransition> MethodTransitions;

        public string TargetOnSuccess { get; set; }

        //Store the state we want to move into - StateTarget

        /// <summary>
        /// Initialise the variables
        /// </summary>
        public TransitionHandler()
        {
            MethodTransitions = null;
            TargetOnSuccess = null;
        }

        /// <summary>
        /// Store Transition Method for Methods
        /// Looks to see is if the conditions have been met for the transition to occur 
        /// </summary>
        /// <param name="stateTarget"></param>
        /// <param name="method"></param>
        /// <param name="expectedResult"></param>
        public void StoreMethodTransition(string stateTarget, Func<bool> method, bool expectedResult)
        {
            //If there are no items in the methodTransition List - Initialise it
            if (MethodTransitions == null)
                MethodTransitions = new List<MethodTransition>();

            MethodTransitions.Add( new MethodTransition(stateTarget, method, expectedResult));
        }


        /// <summary>
        /// Look to see if the Method conditions have been met
        /// </summary>
        /// <returns></returns>
        public string CheckMethodTransition()
        {
            //Perform Null check
            if (MethodTransitions == null)
                return null;
            
            //check whether or not the method conditions have been met
            foreach (MethodTransition transition in MethodTransitions)
            {
                //If the method conditions have been met
                if (transition.CheckTransition()) 
                    //Return the transitions target state
                    return transition.TargetState; 
            }

            return null;
        }

        //Store Transition Method for Boolean
        //Looks to see if Boolean is true
        //Check to see whether the boolean is valid

        //Store Transition Method for Keyboard Input
        //Looks to see if a Keyboard event has been triggered
        //Check to see whether the the input method is valid

        //Store Transition Method for Mouse Input
        //Looks to see whether a mouse click event has been triggered
        //Check to see whether the the mouse click is valid

        //Store Transition Method for Collisions
        //Looks to see whether the entities have collided


    }
}
