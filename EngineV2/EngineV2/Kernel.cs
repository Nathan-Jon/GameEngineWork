using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Entities;
using EngineV2.Behaviours;
using EngineV2.Collision_Management;
using EngineV2.Input;
using EngineV2.Physics;
using EngineV2.BackGround;
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

        //Interfaces

        //Environment
        IEntity platform;
        IEntity platform1;

        //AI
        IEntity enemy;

        //Player
        IEntity player;

        // Interactables
        IEntity crate;

        //Managers
        IEntityManager ent;
        ISceneManager scn;
        CollisionManager col;
        ICollidable collider;
        InputManager inputMgr;
        IBehaviourManager behaviours;
        IAnimationMgr animation;
        ISoundManager snd;
        PhysicsManager physicsMgr;
        IPhysicsObj physicsObj;
        IBackGrounds back;
        IScene scene;

        public static Kernel instance;
        public static bool StartGame = false;

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
            inputMgr = new InputManager();
            col = new CollisionManager();
            physicsObj = new PhysicsObj();
            physicsMgr = new PhysicsManager(physicsObj);
            scene = new Scene1();
            scn = new SceneManager(this, inputMgr, col, physicsMgr, scene);

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
            scene.LoadContent(Content);
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
