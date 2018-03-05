using System;
using Microsoft.Xna.Framework.Input;


namespace EngineV2.Input
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