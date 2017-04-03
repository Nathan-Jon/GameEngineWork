using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Entities;
using EngineV2.Behaviours;
using EngineV2.Input;
using EngineV2.Input;


namespace EngineV2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Instance Variables
        //Constants
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Interfaces

        IEntity player;
        IEntity enemy;
        IEntityManager ent;
        ISceneManager scn;
        ICollisionManager col;
        InputManager inputMgr;
        IBehaviourManager behaviours;
        AnimationMgr animation;

        //Screen Size
        int screenWidth = 900;
        int screenHeight = 600;

        #endregion


        public Game1()
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
            inputMgr = new InputManager();
            ent = new EntityManager();
            scn = new SceneManager(this, inputMgr);
            col = new CollisionManager();
            player = ent.CreateEnt<Player>();
            enemy = ent.CreateEnt<Enemy>();
            behaviours = new BehaviourManager();

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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.setInputMgr(inputMgr);
            player.Initialize(Content.Load<Texture2D>("ChastingSprite"),new Vector2(200, 400));
            scn.Initalize(player, col, behaviours);
            col.Initalize(player, screenWidth, screenHeight);

            enemy.Initialize(Content.Load<Texture2D>("Enemy"), new Vector2(100, 200));
            scn.Initalize(enemy, col, behaviours);
            col.Initalize(enemy, screenWidth, screenHeight);
            behaviours.createMind<EnemyMind>(enemy);


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
