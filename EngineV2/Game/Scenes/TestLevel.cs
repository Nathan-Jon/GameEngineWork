using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Engine.Interfaces;
using Engine.Managers;
using ProjectHastings.Entities;
using ProjectHastings.Behaviours;
using Engine.Collision_Management;
using Engine.Input;
using Engine.Physics;
using Engine.BackGround;
using Engine.Input_Managment;


namespace ProjectHastings.Scenes
{
    class TestLevel : IScene
    {
        List<IEntity> Scenegraph = new List<IEntity>();
        List<IBehaviour> Behaviours = new List<IBehaviour>();

        //Managers
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

            back = new BackGrounds(900, 600);

        }

        public void LoadContent(ContentManager Content)
        {
            //Sounds
            SoundManager.getSoundInstance.Initialize("Level1BackgroundMusic" , Content.Load<SoundEffect>("Level1BackgroundMusic"));
            SoundManager.getSoundInstance.Initialize("Walk" , Content.Load<SoundEffect>("Footsteps"));
            SoundManager.getSoundInstance.Initialize("Crate", Content.Load<SoundEffect>("CratePushSFX"));
            SoundManager.getSoundInstance.Initialize("Exit", Content.Load<SoundEffect>("ExitLevelSFX"));
            SoundManager.getSoundInstance.Initialize("Key", Content.Load<SoundEffect>("KeyPickupSFX"));
            SoundManager.getSoundInstance.Initialize("Ladder", Content.Load<SoundEffect>("LadderClimbSFX"));
            SoundManager.getSoundInstance.CreateInstance();

            //BackGround
            back.Initialize("Background" ,Content.Load<Texture2D>("BackgroundTex1"));

            //Ladders
            IEntity Ladder1 = ent.CreateEnt<Ladder>(Content.Load<Texture2D>("SLadderTex"), new Vector2(200, 110), collider, physicsObj, behaviours);
            IEntity Ladder2 = ent.CreateEnt<Ladder>(Content.Load<Texture2D>("LLadderTex"), new Vector2(400, 107), collider, physicsObj, behaviours);
            IEntity Ladder3 = ent.CreateEnt<Ladder>(Content.Load<Texture2D>("LLadderTex"), new Vector2(675, 107), collider, physicsObj, behaviours);


            //Door
            IEntity Door = ent.CreateEnt<Door>(Content.Load<Texture2D>("Door"), new Vector2(850, 555), collider, physicsObj, behaviours);

            //Key
            IEntity key = ent.CreateEnt<Key>(Content.Load<Texture2D>("Key"), new Vector2(850, -30), collider, physicsObj, behaviours);

            //Platforms          
            IEntity platform1 = ent.CreateEnt<Platform>(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 595), collider, physicsObj, behaviours);
            IEntity platform2 = ent.CreateEnt<Platform>(Content.Load<Texture2D>("MPlatformTex"), new Vector2(695, 475), collider, physicsObj, behaviours);
            IEntity platform3 = ent.CreateEnt<Platform>(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(0, 355), collider, physicsObj, behaviours);
            IEntity leverPlatformTarget = ent.CreateEnt<TriggerPlatform>(Content.Load<Texture2D>("XLPlatformTex"), new Vector2(400, -10), collider, physicsObj, behaviours);
            IEntity platform5 = ent.CreateEnt<Platform>(Content.Load<Texture2D>("MPlatformTex"), new Vector2(-4, 107), collider, physicsObj, behaviours);
            //INTERACTIVE OBJECTS

            //Crates
            IEntity crate = ent.CreateEnt<Crate>(Content.Load<Texture2D>("crate"), new Vector2(10, 80), collider, physicsObj, behaviours);

            //Pressure Plates
            IEntity pressurePlate = ent.CreateEnt<PressurePlate>(Content.Load<Texture2D>("PPlateTex"), new Vector2(10, 355), collider, physicsObj, behaviours);

            //Walls
            IEntity wall = ent.CreateEnt<TriggerWall>(Content.Load<Texture2D>("Wall"), new Vector2(705, 357), collider, physicsObj, behaviours);

            //Lever
            IEntity Lever1 = ent.CreateEnt<Lever>(Content.Load<Texture2D>("Lever"), new Vector2(840, 450), collider, physicsObj, behaviours);

            //The Player
            IEntity player = ent.CreateEnt<Player>(Content.Load<Texture2D>("Chasting"), new Vector2(50, 100), collider, physicsObj, behaviours);

            //Enemies
            IEntity thug = ent.CreateEnt<Thug>(Content.Load<Texture2D>("Thug"), new Vector2(630, 564), collider, physicsObj, behaviours);

            Scenegraph = EntityManager.Entities;
            Behaviours = BehaviourManager.behaviours;
        }

        public void update(GameTime gameTime)
        {

            if (SceneManager.TestLevel == true)
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
