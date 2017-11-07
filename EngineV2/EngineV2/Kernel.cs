using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Collision_Management;
using EngineV2.Physics;
using EngineV2.Input_Managment;
using EngineV2.Scenes;

namespace EngineV2
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
        CollisionManager col;
        ICollidable collider;
        InputManager inputMgr;
        PhysicsManager physicsMgr;
        IPhysicsObj physicsObj;

        List<IScene> SceneList = new List<IScene>();
        IScene scene;
        IScene mainmenu;
        IScene Wingame;

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

            instance = this;
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
            inputMgr = InputManager.GetInputInstance;
            col = new CollisionManager();
            physicsObj = new PhysicsObj();
            physicsMgr = new PhysicsManager(physicsObj);
            mainmenu = new MainMenu();
            SceneList.Add(mainmenu);
            scene = new Scene1();
            SceneList.Add(scene);
            Wingame = new WinScreen();
            SceneList.Add(Wingame);
            scn = new SceneManager(this, col, physicsMgr, SceneList);
            SceneManager.mainmenu = true;

            Components.Add((GameComponent)scn);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            mainmenu.LoadContent(Content);
            scene.LoadContent(Content);
            Wingame.LoadContent(Content);
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
