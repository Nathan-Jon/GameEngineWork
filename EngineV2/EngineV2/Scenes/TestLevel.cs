using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Entities;
using EngineV2.Behaviours;
using EngineV2.Collision_Management;
using EngineV2.Physics;
using EngineV2.BackGround;
using EngineV2.Input_Managment;


namespace EngineV2.Scenes
{
    class TestLevel :  IScene
    {
        List<IEntity> Scenegraph = new List<IEntity>();
        List<IBehaviour> Behaviours = new List<IBehaviour>();

        IEntity player;
        IEntity thug;
        IEntity crate;

        //Ladder
        IEntity Ladder1;
        IEntity Ladder2;
        IEntity Ladder3;

        //Door
        IEntity Door;

        //Key
        IEntity key;

        //Platforms
        IEntity platform1;
        IEntity platform2;
        IEntity platform3;
        IEntity leverPlatformTarget;
        IEntity platform5;

        //Levers
        IEntity Lever1;

        //Pressure Plates
        IEntity pressurePlate;
        
        //Walls
        IEntity wall;

        IEntityManager ent;
        IBackGrounds back;
        ICollidable collider;
        ISceneManager scn;
        IBehaviourManager behaviours;
        PhysicsManager physicsMgr;
        IPhysicsObj physicsObj;

        public TestLevel()
        {

#region Instantiate Managers
           
            ent = EntityManager.getEntityManager;
            physicsObj = new PhysicsObj();

            physicsMgr = PhysicsManager.getPhysicsInstance;
            physicsMgr.setPhysicsList(physicsObj);

            scn = new SceneManager(Kernel.instance);

            behaviours = BehaviourManager.getBehaviourManager;
            collider = new CollidableClass();
            
            #endregion

#region Instantiate Scene Entites
            back = new BackGrounds(900, 600);

            //Crate
            crate = ent.CreateEnt<Crate>();

            //Walls
            wall = ent.CreateEnt<TriggerWall>();

            //Door
            Door = ent.CreateEnt<Door>();

            //Key
            key = ent.CreateEnt<Key>();

            //Ladders
            Ladder1 = ent.CreateEnt<SLadder>();
            Ladder2 = ent.CreateEnt<LLadder>();
            Ladder3 = ent.CreateEnt<LLadder>();

            //Platforms
            platform1 = ent.CreateEnt<ScreenWidthPlatform>();
            platform2 = ent.CreateEnt<MPlatform>();
            platform3 = ent.CreateEnt<ScreenWidthPlatform>();
            leverPlatformTarget = ent.CreateEnt<TriggerPlatform>();
            platform5 = ent.CreateEnt<MPlatform>();

            //Lever
            Lever1 = ent.CreateEnt<Lever>();

            //Presure PLates
            pressurePlate = ent.CreateEnt<PressurePlate>();


            //Player and enemies
            player = ent.CreateEnt<Player>();
            thug = ent.CreateEnt<Thug>();
#endregion

        }

        public void LoadContent(ContentManager Content)
        {
            //Sounds
            SoundManager.getSoundInstance.Initialize(Content.Load<SoundEffect>("Level1Music"));
            SoundManager.getSoundInstance.Initialize(Content.Load<SoundEffect>("Footsteps"));
            SoundManager.getSoundInstance.Initialize(Content.Load<SoundEffect>("CratePushSFX"));
            SoundManager.getSoundInstance.Initialize(Content.Load<SoundEffect>("ExitLevelSFX"));
            SoundManager.getSoundInstance.Initialize(Content.Load<SoundEffect>("KeyPickupSFX"));
            SoundManager.getSoundInstance.Initialize(Content.Load<SoundEffect>("LadderClimbSFX"));
            SoundManager.getSoundInstance.CreateInstance();

            //BackGround
            back.Initialize(Content.Load<Texture2D>("BackgroundTex1"));

            //PLAYER AND ENEMIES
            player.Initialize(Content.Load<Texture2D>("Chasting"), new Vector2(50, 558), collider, physicsObj, behaviours);
            thug.Initialize(Content.Load<Texture2D>("Enemy"), new Vector2(630, 564), collider, physicsObj, behaviours);

            //Ladders
            Ladder1.Initialize(Content.Load<Texture2D>("SLadderTex"), new Vector2(200, 110), collider, physicsObj, behaviours);
            Ladder2.Initialize(Content.Load<Texture2D>("LLadderTex"), new Vector2(400, 107), collider, physicsObj, behaviours);
            Ladder3.Initialize(Content.Load<Texture2D>("LLadderTex"), new Vector2(675, 107), collider, physicsObj, behaviours);
            

            //Door
            Door.Initialize(Content.Load<Texture2D>("Door"), new Vector2(850, 555), collider, physicsObj, behaviours);

            //Key
            key.Initialize(Content.Load<Texture2D>("Key"), new Vector2(850, -30), collider, physicsObj, behaviours);
            
            //Platforms          
            platform1.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 595), collider, physicsObj, behaviours);
            platform2.Initialize(Content.Load<Texture2D>("MPlatformTex"), new Vector2(695, 475), collider, physicsObj, behaviours);
            platform3.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 355), collider, physicsObj, behaviours);
            leverPlatformTarget.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(400, -10), collider, physicsObj, behaviours);
            platform5.Initialize(Content.Load<Texture2D>("MPlatformTex"), new Vector2(-4, 107), collider, physicsObj, behaviours);


            scn.Initalize(back);


            //INTERACTIVE OBJECTS


            //Crates
            crate.Initialize(Content.Load<Texture2D>("crate"), new Vector2(10, 80), collider, physicsObj, behaviours);

            //Pressure Plates
            pressurePlate.Initialize(Content.Load<Texture2D>("PPlateTex"), new Vector2(10, 355), collider, physicsObj, behaviours);

            //Walls
            wall.Initialize(Content.Load<Texture2D>("Wall"), new Vector2(705, 357), collider, physicsObj, behaviours);

            //Lever
            Lever1.Initialize(Content.Load<Texture2D>("Lever"), new Vector2(840, 450), collider, physicsObj, behaviours);

            Scenegraph = EntityManager.Entities;
            Behaviours = BehaviourManager.behaviours;
        }

        public void update(GameTime gameTime)
        {

            if (SceneManager.Level1 == true)
            {
                InputManager.GetInputInstance.update();
                CollisionManager.GetColliderInstance.update();


                for (int i = 0; i < Scenegraph.Count; i++)
                {
                    Scenegraph[i].update(gameTime);
                }


                for (int i = 0; i < Behaviours.Count; i++)
                {

                    Behaviours[i].update();
                }
                
                if (SceneManager.Level1 == true)
                {
                    SoundManager.getSoundInstance.Playsnd(0, 0.5f);
                }


                physicsMgr.update();
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {

                back.Draw(spriteBatch);


                for (int i = 0; i < Scenegraph.Count; i++)
                {
                    Scenegraph[i].Draw(spriteBatch);
                }


        }


    }
}
