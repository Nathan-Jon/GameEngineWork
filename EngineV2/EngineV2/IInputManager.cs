using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineV2
{
    interface IInputManager
    {
        void Initialize(IEntity ent);
        void Update();
        void upmovement();
        void downmovement();
        void leftmovement();
        void rightmovement();
        void OnMouse();


    }
}
