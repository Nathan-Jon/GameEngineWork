using System;
using Microsoft.Xna.Framework.Input;


namespace Engine.Input_Managment
{
    public sealed class InputManager
    {

        private static InputManager instance = null;
        private static object syncInstance = new object();

        public event EventHandler<EventData> NewInput;
        public KeyboardState NewKey;

        //PRIVATE INSTANTIATER
        private InputManager()
        { }


        //RETURN INSTANCE
        public static InputManager GetInputInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new InputManager();
                    }
                }
                return instance;
            }
        }


        //Raise the event
        public void OnNewInput(object source, KeyboardState data)
        {
            EventData args = new EventData(data);
            NewInput(this, args);
            NewKey = args.newKey;
        }

        public void AddListener(EventHandler<EventData> handler)
        {
            //Add Event Handlers
            NewInput += handler;
        }

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
