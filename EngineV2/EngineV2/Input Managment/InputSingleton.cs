using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using EngineV2.Input;
using Microsoft.Xna.Framework.Input;
using KeyboardState = Microsoft.Xna.Framework.Input.KeyboardState;


namespace EngineV2.Input_Managment
{
    public sealed class InputSingleton
    {

        private static InputSingleton instance = null;
        private static object syncInstance = new object();

        public event EventHandler<EventData> NewInput;
        public KeyboardState NewKey;

        //PRIVATE INSTANTIATER
        private InputSingleton()
        { }


        //RETURN INSTANCE
        public static InputSingleton GetInputInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new InputSingleton();
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
