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
        void OnNewInput(object source, KeyboardState data);
        void AddListener(EventHandler<EventData> handler);
        void update();
    }
}
