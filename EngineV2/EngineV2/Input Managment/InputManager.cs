using System;
using Microsoft.Xna.Framework.Input;
using KeyboardState = Microsoft.Xna.Framework.Input.KeyboardState;

namespace EngineV2.Input
{
    public class InputManager : InputPublisher, InputSubscriber
    {

        public event EventHandler<EventData> NewInput;
        public KeyboardState NewKey;
        public KeyboardState oldInput;

        //Raise the event
        public virtual void OnNewInput(object source, KeyboardState data)
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

            if (oldInput != NewKey && NewInput != null)
            {
                OnNewInput(this, NewKey);
            }
        }
    }
}


