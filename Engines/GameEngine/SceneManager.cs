using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine
{
    class SceneManager : ISceneManager
    {
        public Texture2D startscene;
        public Texture2D nextscene;
        int width, height;

        public SceneManager()
        {
            
        }
         
        void ISceneManager.Startup(Texture2D scn, int wid, int hei)
        {
            startscene = scn;
            width = wid;
            height = hei;
            
        }
        void ISceneManager.ChangeScene(Texture2D change)
        {
            nextscene = change;
        }
        
        void ISceneManager.UnloadScene()
        {
            
        }
        
        void ISceneManager.AddEntity()
        { 
        
        }

        void ISceneManager.Drawstartscn(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(getstartScene, new Rectangle(0, 0, width, height), Color.AntiqueWhite);
        }
        void ISceneManager.Drawnextscn(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(nextscene, new Rectangle(0, 0, width, height), Color.AntiqueWhite);
        }

        void ISceneManager.GameOver()
        {

        }

        public Texture2D getstartScene
        {
            get { return startscene; }
        }

    }
}
