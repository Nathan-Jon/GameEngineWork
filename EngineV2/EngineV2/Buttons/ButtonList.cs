using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;

namespace EngineV2.Buttons
{
    class ButtonList
    {
        IButton exit;
        IButton start;

        bool selected = false;
        InputManager input;
        private KeyboardState keyState;

        public static List<IButton> menuButtons= new List<IButton>();

        public ButtonList()
        {

        }

        public void Initalize(IButton but)
        {
            menuButtons.Add(but);
        }

    }
}
