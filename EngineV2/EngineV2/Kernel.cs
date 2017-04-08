using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Entities;
using EngineV2.Behaviours;
using EngineV2.Collision_Management;
using EngineV2.Input;


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

        IEntity player;
        IEntity enemy;
        IEntityManager ent;
        ISceneManager scn;
        CollisionManager col;
        ICollidable collider;
        InputManager inputMgr;
        IBehaviourManager behaviours;
        IAnimationMgr animation;
        ISoundManager snd;

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
            inputMgr = new InputManager();
            ent = new EntityManager();
            col = new CollisionManager();
            scn = new SceneManager(this, inputMgr, col);
            player = ent.CreateEnt<Player>();
            enemy = ent.CreateEnt<Enemy>();
            behaviours = new BehaviourManager();
            animation = new AnimationMgr();
            snd = new SoundManager();
            collider = new CollidableClass();

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

            snd.Initialize(Content.Load<SoundEffect>("background"), Content);

            player.applyEventHandlers(inputMgr, col);
            enemy.applyEventHandlers(inputMgr, col);

            player.Initialize(Content.Load<Texture2D>("Chasting"),new Vector2(200, 400), collider, snd);
            enemy.Initialize(Content.Load<Texture2D>("Enemy"), new Vector2(100, 200),collider, snd);
            
            animation.Initialize(player, 3, 3);
            animation.Initialize(enemy, 3, 3);
            
            scn.Initalize(player,behaviours, animation);
            scn.Initalize(enemy,behaviours, animation);

            collider.isCollidable(player);
            collider.isCollidable(enemy);


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
