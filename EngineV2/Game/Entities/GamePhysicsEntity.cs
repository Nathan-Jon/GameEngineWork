using Engine.Entity_Management;
using Engine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectHastings.Entities
{
    /// <summary>
    /// Game Entity Class, To be inherited by game entities, adding them to the scene
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    public class GamePhysicsEntity : PhysicsEntity
    {
        public override string Tag { get; set; }
        public override Vector2 Position { get; set; }
        public override Texture2D Texture { get; set; }
        public override Rectangle Hitbox { get; set; }
        public int row;

        public bool onTerrain;
        public float speed;

        //References to the Managers
        public IBehaviourManager _BehaviourManager;
        public ICollidable _Collisions;


        public override void Initialize(Texture2D tex, Vector2 posn, ICollidable _collider, IBehaviourManager behaviours)
        {
            GravityBool = false;
            Position = posn;
            Texture = tex;
            _Collisions = _collider;
            _BehaviourManager = behaviours;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            UniqueData();
        }   //Initialises the objects, catching references to the managers
        public override void UniqueData()
        {
            CollidableObjs();
        }                    // Used to apply the specific variables such as animations onto the entity
        public override void CollidableObjs()
        { }                //Used to get the Lists for the collidable Objects
        public virtual void Move()
        {
            Position += new Vector2(4,0);
        }                           //Move Method used for testing entities
        public override void Update(GameTime game)
        {
            Move();
        }           //Update method, called every fram

        #region get/sets
        public override int getRows()
        {
            return row;
        }

        public override float Direction { get; set; }

        public override void setRow(int rows)
        {
            row = rows;
        }
        #endregion
    }


}


