using System.Collections.Generic;
using Engine.Input_Managment;
using Engine.Interfaces;
using Engine.Managers;
using Engine.Service_Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectHastings.Scenes;

namespace ProjectHastings
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Kernel : Game
    {
        #region Instance Variables
        //Constants
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ISceneManager scn;
        ICollidable collider;
        IPhysicsObj physicsObj;

        IScene TestScene;
        IScene mainmenu;
        IScene Wingame;
        IScene LoseScreen;

        public static Kernel instance;


        //Screen Size
        int screenWidth = 900;
        int screenHeight = 600;

        #endregion


        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mainmenu = new MainMenu();
            TestScene = new TestLevel();
            Wingame = new WinGame();
            LoseScreen = new GameOver();
            scn = new SceneManager(this);


            Components.Add((GameComponent)scn);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            mainmenu.LoadContent(Content);
            TestScene.LoadContent(Content);
            Wingame.LoadContent(Content);
            LoseScreen.LoadContent(Content);

            scn.AddScene("Mainmenu", mainmenu);
            scn.AddScene("TestLevel", TestScene);
            scn.AddScene("WinGame", Wingame);
            scn.AddScene("LoseScreen", LoseScreen);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
