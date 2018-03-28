using System.Collections.Generic;
using Engine.Collision_Management;
using Engine.Input_Managment;
using Engine.Interfaces;
using Engine.Managers;
using Engine.Service_Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectHastings.Entities.Interactive
{
    class Crate : GameEntity
    {
        public string tag = "Crate";
        private float moveDirec = 3;
        private bool moveObject = false;
        private bool canMove = true;
        private bool crateContact = false;

        //Physics
        public bool gravity = true;


        //Input Management
        private KeyboardState keyState;

        //Collision Management
        private IEntity collisionObj;
        //Lists
        private List<IEntity> player;
        private List<IEntity> environment;

        IInputManager input = Locator.Instance.getProvider<InputManager>() as IInputManager;
        ICollisionManager coli = Locator.Instance.getProvider<CollisionManager>() as ICollisionManager;
        ISoundManager sound = Locator.Instance.getProvider<SoundManager>() as ISoundManager;

        public override void UniqueData()
        {
            input.AddListener(OnNewInput);
            coli.subscribe(onCollision);
            CollidableObjs();
            _Collisions.isInteractiveCollidable(this);
            //  _PhysicsObj.hasPhysics(this);
        }

        /// <summary>
        /// Event Handler for Keyboard Input
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
            if (crateContact && keyState.IsKeyDown(Keys.H) || crateContact && keyState.IsKeyDown(Keys.E))
            {

                moveObject = true;

                if (crateContact && keyState.IsKeyDown(Keys.D) || moveObject && keyState.IsKeyDown(Keys.Right))
                {
                    Position += new Vector2(3, 0);
                    sound.Playsnd("Crate", 0.2f);
                }
                if (crateContact && keyState.IsKeyDown(Keys.A) || moveObject && keyState.IsKeyDown(Keys.Left))
                {
                    Position += new Vector2(-3, 0);
                    sound.Playsnd("Crate", 0.2f);
                }

            }

            if (crateContact == false)
            {
                sound.Stopsnd("Crate");
            }
        }

        /// <summary>
        /// Get the lists of collidabl objects
        /// </summary>
        public override void CollidableObjs()
        {
            //interactiveObjs = colliders.getEntityList();
            player = _Collisions.getPlayableObj();
            environment = _Collisions.getEnvironment();
        }

        /// <summary>
        /// Send Event to collision Event Manager
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;
            gravity = true;

            #region wall collisions

            if (Position.X <= 0)
            {
                Position += new Vector2(3, 0);
            }
            if (Hitbox.X >= 850)
            { Position -= new Vector2(3, 0); }
            if (Position.Y >= 570)
            {
                gravity = false;
                Position -= new Vector2(2, 0);
            }
            #endregion

            #region Player Collision
            for (int i = 0; i < player.Count; i++)
            {
                if (Hitbox.Intersects((player[i].Hitbox)))
                {
                    //if (player[i].Tag == "Player")
                    //{ crateContact = true; }
                    //else if (player[i].Tag != "Player")
                    //{ crateContact = false; }

                    crateContact = true;
                }
                else
                { crateContact = false; }

            }
            for (int i = 0; i < environment.Count; i++)
            {
                if (Hitbox.Intersects(environment[i].Hitbox))
                {
                    gravity = false;
                }
            }
            #endregion
        }

        /// <summary>
        /// Draws the entty based on the texture and position obtained from the animation class
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }

        /// <summary>
        /// Called Every Frame
        /// </summary>
        /// <param name="game"></param>
        public override void Update(GameTime game)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }
    }
}
