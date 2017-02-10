using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    interface ISceneManager
    {
        void Startup();
        void ChangeScene();
        void UnloadScene();
        void AddEntity();
    }
}
