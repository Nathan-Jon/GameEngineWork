using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Entities;
using EngineV2.Behaviours;
using EngineV2.Collision_Management;
using EngineV2.Input;
using EngineV2.Physics;
using EngineV2.BackGround;
using EngineV2.Input_Managment;


namespace EngineV2.Scenes
{
    class Scene1 :  IScene
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
        InputManager inputMgr;
        ISceneManager scn;
        IBehaviourManager behaviours;
        ISoundManager snd;
        PhysicsManager physicsMgr;
        IPhysicsObj physicsObj;
        private CollisionManagerSingleton ColMgr;

        public Scene1()
        {

#region Instantiate Managers
            inputMgr = InputManager.GetInputInstance;
            ent = EntityManager.getEntityManager;
            physicsObj = new PhysicsObj();

            physicsMgr = PhysicsManager.getPhysicsInstance;
            physicsMgr.setPhysicsList(physicsObj);

            scn = new SceneManager(Kernel.instance);

            behaviours = BehaviourManager.getBehaviourManager;
            snd = SoundManager.getSoundInstance;
            collider = new CollidableClass();
            ColMgr = CollisionManagerSingleton.GetColliderInstance;
            
            #endregion

#region Instantiate Scene Entites
            back = new BackGrounds(900, 600);
            
            thug = ent.CreateEnt<Thug>();
            crate = ent.CreateEnt<Crate>();



            //Walls
            wall = ent.CreateEnt<TriggerWall>();

            //Door
            Door = ent.CreateEnt<Door>();

            //Key
            key = ent.CreateEnt<Key>();

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

            //Ladders
            Ladder1 = ent.CreateEnt<SLadder>();
            Ladder2 = ent.CreateEnt<LLadder>();
            Ladder3 = ent.CreateEnt<LLadder>();
            
            player = ent.CreateEnt<Player>();
            thug = ent.CreateEnt<Thug>();
#endregion

        }

        public void LoadContent(ContentManager Content)
        {
            snd.Initialize(Content.Load<SoundEffect>("Level1Music"));
            snd.Initialize(Content.Load<SoundEffect>("Footsteps"));
            snd.Initialize(Content.Load<SoundEffect>("CratePushSFX"));
            snd.Initialize(Content.Load<SoundEffect>("ExitLevelSFX"));
            snd.Initialize(Content.Load<SoundEffect>("KeyPickupSFX"));
            snd.Initialize(Content.Load<SoundEffect>("LadderClimbSFX"));
            snd.CreateInstance();

            back.Initialize(Content.Load<Texture2D>("BackgroundTex1"));

            //PLAYER AND ENEMIES

            

            player.Initialize(Content.Load<Texture2D>("Chasting"), new Vector2(50, 558), collider, snd, physicsObj, behaviours);
            thug.Initialize(Content.Load<Texture2D>("Enemy"), new Vector2(630, 564), collider, snd, physicsObj, behaviours);
            
            //Ladders
            Ladder1.Initialize(Content.Load<Texture2D>("SLadderTex"), new Vector2(200, 110), collider, snd, physicsObj, behaviours);
            Ladder2.Initialize(Content.Load<Texture2D>("LLadderTex"), new Vector2(400, 107), collider, snd, physicsObj, behaviours);
            Ladder3.Initialize(Content.Load<Texture2D>("LLadderTex"), new Vector2(675, 107), collider, snd, physicsObj, behaviours);
            

            //Door
            Door.Initialize(Content.Load<Texture2D>("Door"), new Vector2(850, 555), collider, snd, physicsObj, behaviours);

            //Key
            key.Initialize(Content.Load<Texture2D>("Key"), new Vector2(850, -30), collider, snd, physicsObj, behaviours);
            
            //Platforms          
            platform1.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 595), collider, snd, physicsObj, behaviours);
            platform2.Initialize(Content.Load<Texture2D>("MPlatformTex"), new Vector2(695, 475), collider, snd, physicsObj, behaviours);
            platform3.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 355), collider, snd, physicsObj, behaviours);
            leverPlatformTarget.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(400, -10), collider, snd, physicsObj, behaviours);
            platform5.Initialize(Content.Load<Texture2D>("MPlatformTex"), new Vector2(-4, 107), collider, snd, physicsObj, behaviours);


            scn.Initalize(back, snd);


            //INTERACTIVE OBJECTS


            //Crates
            crate.Initialize(Content.Load<Texture2D>("crate"), new Vector2(10, 80), collider, snd, physicsObj, behaviours);

            //Pressure Plates
            pressurePlate.Initialize(Content.Load<Texture2D>("PPlateTex"), new Vector2(10, 355), collider, snd, physicsObj, behaviours);

            //Walls
            wall.Initialize(Content.Load<Texture2D>("Wall"), new Vector2(705, 357), collider, snd, physicsObj, behaviours);

            //Lever
            Lever1.Initialize(Content.Load<Texture2D>("Lever"), new Vector2(840, 450), collider, snd, physicsObj, behaviours);

            Scenegraph = EntityManager.Entities;
            Behaviours = BehaviourManager.behaviours;
        }

        public void update(GameTime gameTime)
        {

            if (SceneManager.Level1 == true)
            {
                inputMgr.update();
                ColMgr.update();


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
                    snd.Playsnd(0);
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
