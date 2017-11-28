using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Scenes;

namespace EngineV2
{
    class Renderable : IRenderable
    {
        
        SpriteBatch spriteBatch;
        List<IScene> scenes;

        public void Initalise(List<IScene> sceneList, SpriteBatch sprite)
        {
            scenes = sceneList;
            spriteBatch = sprite;
        }
        
        public void Draw()
        {

            spriteBatch.Begin();
            if (SceneManager.mainmenu == true)
            {
                scenes[0].Draw(spriteBatch);
            }

            if (SceneManager.Level1 == true)
            {
                scenes[1].Draw(spriteBatch);
            }

            if (SceneManager.WinGame == true)
            {
                scenes[2].Draw(spriteBatch);
            }

            if (SceneManager.LoseScreen == true)
            {
                scenes[3].Draw(spriteBatch);
            }


            spriteBatch.End();

        }

    }
}
