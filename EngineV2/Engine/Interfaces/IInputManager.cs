using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Engine.Input_Managment;
using Microsoft.Xna.Framework.Input;

namespace Engine.Interfaces
{
    public interface IInputManager
    {
        void OnNewKeyInput(object source, KeyboardState data);
        void OnNewMouseInput(object source, MouseState data);

        void AddKeyListener(EventHandler<KeyEventData> handler);
        void AddMouseListener(EventHandler<MouseEventData> handler);

        void Update();
    }
}
