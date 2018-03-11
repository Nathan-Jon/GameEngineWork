using System;
using Microsoft.Xna.Framework.Input;


namespace Engine.Input_Managment
{
    public class EventData : EventArgs
    {
        public KeyboardState newKey;
        

        public EventData(KeyboardState state)
        {
            newKey = state;
        }
    }
}