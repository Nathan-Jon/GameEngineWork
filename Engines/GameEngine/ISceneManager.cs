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
        void Startup(Texture2D scn, int wid, int hei);
        void ChangeScene(Texture2D change);
        void UnloadScene();
        void AddEntity();
        void Drawscn(SpriteBatch spriteBatch);
        void Drawnextscn(SpriteBatch spriteBatch);
        void GameOver();
    }
}
