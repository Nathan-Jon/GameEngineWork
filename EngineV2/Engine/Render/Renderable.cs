using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;
using Engine.Managers;

namespace Engine.Render
{
    class Renderable : IRenderable
    {
        
        SpriteBatch spriteBatch;
        IDictionary<string, IScene> scenes = new Dictionary<string, IScene>();

        public void Initalise(IDictionary<string, IScene> sceneList, SpriteBatch sprite)
        {
            scenes = sceneList;
            spriteBatch = sprite;
        }
        
        public void Draw()
        {

            spriteBatch.Begin();
            if (SceneManager.mainmenu == true)
            {
                scenes["Mainmenu"].Draw(spriteBatch);
            }

            if (SceneManager.TestLevel == true)
            {
                scenes["TestLevel"].Draw(spriteBatch);
            }

            if (SceneManager.WinGame == true)
            {
                scenes["WinGame"].Draw(spriteBatch);
            }

            if (SceneManager.LoseScreen == true)
            {
                scenes["LoseScreen"].Draw(spriteBatch);
            }


            spriteBatch.End();

        }

    }
}
