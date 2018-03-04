﻿using KeyboardState = Microsoft.Xna.Framework.Input.KeyboardState;

namespace EngineV2.Input
{
    interface InputPublisher
    {
        void OnNewInput(object source, KeyboardState data);
    }
}