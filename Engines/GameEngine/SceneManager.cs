using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameEngine
{
    public class SceneManager : ISceneManager

    {
        List<Texture2D> screens;
        bool isinitialized = false;
        int height;
        int width;

        void ISceneManager.Initialize(Texture2D tex, int wid, int hei)
        {
            screens = new List<Texture2D>();
            
            width = wid;
            height = hei;
            screens.Add(tex);
            isinitialized = true;
        }


        void ISceneManager.ChangeScene(Texture2D nextscn)
        {
            screens.Add(nextscn);
        }

        void ISceneManager.RemoveScene(int scnnum)
        {
            screens.Remove(screens[scnnum]);
        }

        void ISceneManager.Draw(SpriteBatch spriteBatch, int scnnum)
        {
            if (isinitialized)
            {
             //spriteBatch.Draw(screens[i], new Rectangle(0, 0, width, height), Color.AntiqueWhite);
                spriteBatch.Draw(screens[0], new Rectangle(0, 0, width, height), Color.AntiqueWhite);

            }
            

        }

    }
}
