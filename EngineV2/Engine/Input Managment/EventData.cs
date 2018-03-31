using System;
using Microsoft.Xna.Framework.Input;


namespace Engine.Input_Managment
{
    public class KeyEventData : EventArgs
    {
        public KeyboardState _newKey;
        

        public KeyEventData(KeyboardState state)
        {
            _newKey = state;
        }
    }

    public class MouseEventData : EventArgs
    {
        public MouseState _newMouse;

        public MouseEventData(MouseState state)
        {
            _newMouse = state;
        }
    }
}