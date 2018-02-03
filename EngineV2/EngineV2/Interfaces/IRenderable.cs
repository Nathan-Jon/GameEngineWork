﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineV2.Scenes;

namespace EngineV2.Interfaces
{
    interface IRenderable
    {
        void Initalise(IDictionary<string, IScene> scene, SpriteBatch sprite);
        void Draw();
    }
}
