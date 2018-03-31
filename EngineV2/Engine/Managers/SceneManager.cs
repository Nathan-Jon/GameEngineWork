using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;
using Engine.Render;
using Engine.Service_Locator;

namespace Engine.Managers
{
    public class SceneManager : DrawableGameComponent, ISceneManager
    {

        public IDictionary<string, IScene> CurrentScene;
        public IDictionary<string, IScene> AllScenes;
        private IRenderable render;
        private SpriteBatch sprt;

        public SceneManager(Game game) : base(game)
        {
            render = new Renderable();
            CurrentScene = new Dictionary<string, IScene>();
            AllScenes = new Dictionary<string, IScene>();
            sprt = new SpriteBatch(GraphicsDevice);
        }

        public void AddScene(string name, IScene scenes)
        {
            if (CurrentScene.Count == 0 && AllScenes.Count == 0)  
            {
               CurrentScene.Add(name, scenes);
            }
            else
            {
                AllScenes.Add(name, scenes);
            }
        }

        public void ChangeScene (string name)
        {
            if (!CurrentScene.ContainsKey(name))
            {
                CurrentScene[name] = AllScenes[name];
                AllScenes.Remove(name);
            }
        }

        public void RemoveScene(string name)
        {
            CurrentScene.Remove(name);
        }
        public override void Update(GameTime gameTime) 
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            Game.Exit();

            

            IList<IScene> scene = CurrentScene.Values.ToList();
            foreach (IScene screen in scene)
            {
                screen.update(gameTime);
                render.Draw(screen, sprt);
            }

            base.Update(gameTime);

        }



    }
}
