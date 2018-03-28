using System;
using Engine.Interfaces;
using Microsoft.Xna.Framework.Input;


namespace Engine.Input_Managment
{
    public class InputManager : IInputManager, IProvider
    {

    public event EventHandler<EventData> NewInput;
    public KeyboardState NewKey;

    //PRIVATE INSTANTIATER
    public InputManager()
    {

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
