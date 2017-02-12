using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine
{
    class Input
    {
        public static void input()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.W))
            {
                EntityManager.Locn2.Y += -1;
            }
            if (state.IsKeyDown(Keys.S))
            {
                EntityManager.Locn2.Y += 1;
            }
            
        }

    }
}
