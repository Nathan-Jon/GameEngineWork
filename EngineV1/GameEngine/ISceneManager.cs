using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine
{
    interface ISceneManager
    {
        void Initialize(Texture2D tex, int wid, int hei);
        void ChangeScene(Texture2D nextscn);
        void RemoveScene(int scnnum);
        void Draw(SpriteBatch spritebatch, int scnnum);
    }
}
