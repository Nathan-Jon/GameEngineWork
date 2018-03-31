using System;
using Engine.Interfaces;
using Microsoft.Xna.Framework.Input;


namespace Engine.Input_Managment
{
    public class InputManager : IInputManager, IProvider
    {

    public event EventHandler<KeyEventData> NewKeyInput;
    public event EventHandler<MouseEventData> NewMouseInput;
    public KeyboardState NewKey;
    public MouseState NewMouse;

    //Public INSTANTIATER
    public InputManager()
    {

    }

    //Raise the event
    public void OnNewKeyInput(object source, KeyboardState data)
    {
        KeyEventData args = new KeyEventData(data);
            NewKeyInput(this, args);
            NewKey = args._newKey;
    }

    public void AddKeyListener(EventHandler<KeyEventData> handler)
    {
        //Add Event Handlers
        NewKeyInput += handler;
    }

    public void OnNewMouseInput(object source, MouseState data)
    {
        MouseEventData args = new MouseEventData(data);
        NewMouseInput(this, args);
        NewMouse = args._newMouse;
    }

        public void AddMouseListener(EventHandler<MouseEventData> handler)
        {
            NewMouseInput += handler;
        }

    

    public void Update()
    {
        NewKey = Keyboard.GetState();
        NewMouse = Mouse.GetState();

        if (NewKeyInput != null)
        {
            OnNewKeyInput(this, NewKey);
        }

        if (NewMouseInput != null)
        {
            OnNewMouseInput(this, NewMouse);
        }
    }



    }
}
