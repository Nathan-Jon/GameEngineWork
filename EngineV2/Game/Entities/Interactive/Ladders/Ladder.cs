using System.Collections.Generic;
using Engine.Collision_Management;
using Engine.Input_Managment;
using Engine.Interfaces;
using Engine.Managers;
using Engine.Service_Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectHastings.Entities.Interactive.Ladders
{
    /// <summary>
    /// Interactive object for the player allowing them to go up and down the y axis
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    class Ladder : GameEntity
    {
        #region Instance Variables

        public string tag = "Ladder";

        //Input Management
        private KeyboardState keyState;

        //Collision Management Variables
        private IEntity collisionObj;
        private ICollidable colliders;
        private List<IEntity> playerObj;

        IInputManager input = Locator.Instance.getProvider<InputManager>() as IInputManager;
        ICollisionManager coli = Locator.Instance.getProvider<CollisionManager>() as ICollisionManager;

        #endregion

        /// <summary>
        /// Initialise the Variables specific to this object
        /// </summary>
        public override void UniqueData()
        {
            input.AddListener(OnNewInput);
            coli.subscribe(onCollision);
            _Collisions.isInteractiveCollidable(this);
            CollidableObjs();
        }

        /// <summary>
        /// Initialise Keyboard Event Handler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;
        }

        /// <summary>
        /// Get the player Object list
        /// </summary>
        public override void CollidableObjs()
        {
            playerObj = _Collisions.getPlayableObj();
        }

        /// <summary>
        /// Call collision Evem
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        public virtual void onCollision(object source, CollisionEventData data)
        {
            collisionObj = data.objectCollider;

            for (int i = 0; i < playerObj.Count; i++)
            {
                if (Hitbox.Intersects(playerObj[i].Hitbox) && playerObj[i].Tag == "Player")
                {
                    Player.Player.canClimb = true;
                }

                Player.Player.canClimb = false;
            }


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
