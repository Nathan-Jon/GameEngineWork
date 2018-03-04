using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input_Managment;
using EngineV2.Interfaces;

namespace EngineV2.Buttons
{
    public class ButtonList
    {
        IButton exit;
        IButton start;

        bool selected = false;
        private InputManager input;
        private KeyboardState keyState;

        public static List<IButton> menuButtons= new List<IButton>();

        public void Initalize(IButton but)
        {
            menuButtons.Add(but);
        }

    }
}
