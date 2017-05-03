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


namespace EngineV2.Scenes
{
    class Scene1 :  IScene
    {
        List<IEntity> Scenegraph = new List<IEntity>();
        List<IBehaviour> Behaviours = new List<IBehaviour>();
        public static List<IAnimationMgr> Animation = new List<IAnimationMgr>();

        IEntity player;
        IEntity enemy;
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
        CollisionManager col;
        ICollidable collider;
        InputManager inputMgr;
        ISceneManager scn;
        IBehaviourManager behaviours;
        IAnimationMgr animation;
        ISoundManager snd;
        PhysicsManager physicsMgr;
        IPhysicsObj physicsObj;

        public Scene1()
        {

            inputMgr = new InputManager();
            ent = new EntityManager();
            back = new BackGrounds(900, 600);
            col = new CollisionManager();
            physicsObj = new PhysicsObj();
            physicsMgr = new PhysicsManager(physicsObj);
            scn = new SceneManager(Kernel.instance, inputMgr, col, physicsMgr);
            player = ent.CreateEnt<Player>();
            enemy = ent.CreateEnt<Enemy>();
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

            behaviours = new BehaviourManager();
            animation = new AnimationMgr();
            snd = new SoundManager();
            collider = new CollidableClass();
        }

        public void LoadContent(ContentManager Content)
        {
            snd.Initialize(Content.Load<SoundEffect>("background"));
            snd.Initialize(Content.Load<SoundEffect>("Footsteps"));
            snd.Initialize(Content.Load<SoundEffect>("CratePushSFX"));
            snd.Initialize(Content.Load<SoundEffect>("ExitLevelSFX"));
            snd.Initialize(Content.Load<SoundEffect>("KeyPickupSFX"));
            snd.Initialize(Content.Load<SoundEffect>("LadderClimbSFX"));
            snd.CreateInstance();

            back.Initialize(Content.Load<Texture2D>("BackgroundTex1"));

            //PLAYER AND ENEMIES

            player.applyEventHandlers(inputMgr, col);
            enemy.applyEventHandlers(inputMgr, col);
            

            player.Initialize(Content.Load<Texture2D>("Chasting"), new Vector2(50, 558), collider, snd, physicsObj, behaviours);
            enemy.Initialize(Content.Load<Texture2D>("Enemy"), new Vector2(630, 564), collider, snd, physicsObj, behaviours);
            
            //Ladders
            Ladder1.applyEventHandlers(inputMgr, col);
            Ladder2.applyEventHandlers(inputMgr, col);
            Ladder3.applyEventHandlers(inputMgr, col);


            Ladder1.Initialize(Content.Load<Texture2D>("SLadderTex"), new Vector2(200, 110), collider, snd, physicsObj, behaviours);
            Ladder2.Initialize(Content.Load<Texture2D>("LLadderTex"), new Vector2(400, 107), collider, snd, physicsObj, behaviours);
            Ladder3.Initialize(Content.Load<Texture2D>("LLadderTex"), new Vector2(675, 107), collider, snd, physicsObj, behaviours);
            

            //Door
            Door.applyEventHandlers(inputMgr, col);

            Door.Initialize(Content.Load<Texture2D>("Door"), new Vector2(850, 555), collider, snd, physicsObj, behaviours);

            //Key
            key.applyEventHandlers(inputMgr, col);

            key.Initialize(Content.Load<Texture2D>("Key"), new Vector2(850, -30), collider, snd, physicsObj, behaviours);
            
            //Platforms
            platform1.applyEventHandlers(inputMgr, col);
            platform2.applyEventHandlers(inputMgr, col);
            platform3.applyEventHandlers(inputMgr, col);
            leverPlatformTarget.applyEventHandlers(inputMgr, col);
            platform5.applyEventHandlers(inputMgr, col);
            
            platform1.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 595), collider, snd, physicsObj, behaviours);
            platform2.Initialize(Content.Load<Texture2D>("MPlatformTex"), new Vector2(695, 475), collider, snd, physicsObj, behaviours);
            platform3.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 355), collider, snd, physicsObj, behaviours);
            leverPlatformTarget.Initialize(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(400, -10), collider, snd, physicsObj, behaviours);
            platform5.Initialize(Content.Load<Texture2D>("MPlatformTex"), new Vector2(-4, 107), collider, snd, physicsObj, behaviours);


            //Animation
            animation.Initialize(player, 3, 3);
            animation.Initialize(enemy, 3, 3);
            

            scn.Initalize(animation, back, snd);


            //INTERACTIVE OBJECTS


            //Crates
            crate.applyEventHandlers(inputMgr, col);

            crate.Initialize(Content.Load<Texture2D>("crate"), new Vector2(10, 80), collider, snd, physicsObj, behaviours);

            //Pressure Plates
            pressurePlate.applyEventHandlers(inputMgr, col);

            pressurePlate.Initialize(Content.Load<Texture2D>("PPlateTex"), new Vector2(10, 355), collider, snd, physicsObj, behaviours);

            //Walls
            wall.applyEventHandlers(inputMgr, col);

            wall.Initialize(Content.Load<Texture2D>("Wall"), new Vector2(705, 357), collider, snd, physicsObj, behaviours);

            //Lever

            Lever1.applyEventHandlers(inputMgr, col);

            Lever1.Initialize(Content.Load<Texture2D>("Lever"), new Vector2(840, 450), collider, snd, physicsObj, behaviours);

            Scenegraph = EntityManager.Entities;
            Behaviours = BehaviourManager.behaviours;
            Animation.Add(animation);
        }

        public void update(GameTime gameTime)
        {

            if (SceneManager.Level1 == true)
            {
                inputMgr.update();
                col.update();

                for (int i = 0; i < Scenegraph.Count; i++)
                {
                    Scenegraph[i].update();
                }

                for (int i = 0; i < Animation.Count; i++)
                {

                    Animation[i].Update(gameTime);
                }

                for (int i = 0; i < Behaviours.Count; i++)
                {

                    Behaviours[i].update();
                }


                physicsMgr.update();
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {

                back.Draw(spriteBatch);


                for (int i = 2; i < Scenegraph.Count; i++)
                {
                    Scenegraph[i].Draw(spriteBatch);
                }

                for (int i = 0; i < Animation.Count; i++)
                {
                    Animation[i].Draw(spriteBatch);
                }

        }


    }
}
