using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Entities;
using EngineV2.Behaviours;

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
        IInputManager imp;
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
            ent = new EntityManager();
            scn = new SceneManager(this);
            col = new CollisionManager();
            imp = new InputManager();
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


            player.setTexPos(Content.Load<Texture2D>("ChastingSprite"),new Vector2(200, 400));
            scn.Initalize(player, col, behaviours, imp);
            col.Initalize(player, screenWidth, screenHeight);
            imp.Initialize(player);

            enemy.setTexPos(Content.Load<Texture2D>("Enemy"), new Vector2(100, 200));
            scn.Initalize(enemy, col, behaviours, imp);
            col.Initalize(enemy, screenWidth, screenHeight);
            behaviours.createMind<EnemyMind>(enemy);


            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        ///// <summary>
        ///// Allows the game to run logic such as updating the world,
        ///// checking for collisions, gathering input, and playing audio.
        ///// </summary>
        ///// <param name="gameTime">Provides a snapshot of timing values.</param>
        //protected override void Update(GameTime gameTime)
        //{
        //    

        //    scn.Update();
            

        //    // TODO: Add your update logic here



        //    base.Update(gameTime);
        //}

        ///// <summary>
        ///// This is called when the game should draw itself.
        ///// </summary>
        ///// <param name="gameTime">Provides a snapshot of timing values.</param>
        //protected override void Draw(GameTime gameTime)
        //{
        //    GraphicsDevice.Clear(Color.AntiqueWhite);

        //    scn.Draw();


        //    base.Draw(gameTime);
        //}
    }
}
