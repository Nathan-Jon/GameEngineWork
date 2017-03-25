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
        IEntity Pug;
        IEntityManager ent;
        ISceneManager scn;
        ICollisionManager col;
        IInputManager imp;
        IBehaviourManager behaviours;

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
            scn = new SceneManager();
            col = new CollisionManager();
            imp = new InputManager();
            player = ent.CreateEnt<Player>();
            Pug = ent.CreateEnt<Enemy>();
            behaviours = new BehaviourManager();
            

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

            scn.addScn(Content.Load<Texture2D>("Brick"));
            scn.addScn(Content.Load<Texture2D>("DickButt"));

            player.setTexPos(Content.Load<Texture2D>("Chastings"), 200, 400);
            scn.Initalize(player, spriteBatch, col, behaviours, imp);
            col.Initalize(player, screenWidth, screenHeight);
            imp.Initialize(player);

            Pug.setTexPos(Content.Load<Texture2D>("Pug"), 100, 200);
            scn.Initalize(Pug, spriteBatch, col, behaviours, imp);
            col.Initalize(Pug, screenWidth, screenHeight);
            behaviours.createMind<EnemyMind>(Pug);
            
            
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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            scn.Update();
            
            
            // TODO: Add your update logic here
           
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);
            

            spriteBatch.Begin();
            scn.Draw();
            spriteBatch.End();
            
            // TODO: Add your drawing code here
            

            base.Draw(gameTime);
        }
    }
}
