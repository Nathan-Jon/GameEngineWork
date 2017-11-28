using System;
using EngineV2.Input;
using Microsoft.Xna.Framework.Input;
using KeyboardState = Microsoft.Xna.Framework.Input.KeyboardState;


namespace EngineV2.Input_Managment
{
    public sealed class InputManager
    {


        private static InputManager instance = null;
        private static object syncInstance = new object();

        public event EventHandler<EventData> NewInput;
        public KeyboardState NewKey;

        private InputManager()
        { }

        /// <summary>
        /// Returns an instance of the InputManager
        /// </summary>
        public static InputManager GetInputInstance
        {
            get
            {
                if (instance == null)
                {
                    //Ensures only one class can access this if statement at a time
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new InputManager();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Collects the data and raises the event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public void OnNewInput(object source, KeyboardState data)
        {
            EventData args = new EventData(data);
            NewInput(this, args);
            NewKey = args.newKey;
        }

        /// <summary>
        /// Subscribes a class to the event handler
        /// </summary>
        /// <param name="handler"></param>
        public void AddListener(EventHandler<EventData> handler)
        {
            //Add Event Handlers
            NewInput += handler;
        }

        /// <summary>
        /// updates the keyboard state
        /// </summary>
        public void update()
        {
            NewKey = Keyboard.GetState();

            if (NewInput != null)
            {
                OnNewInput(this, NewKey);
            }
        }



    }
}
