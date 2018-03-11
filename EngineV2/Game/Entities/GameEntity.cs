using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Interfaces;
using Engine.Entity_Management;

namespace ProjectHastings.Entities
{
    /// <summary>
    /// Game Entity Class, To be inherited by game entities, adding them to the scene
    /// Author: Nathan Roberson & Carl Chalmers
    /// Date of Change: 03/02/18
    /// Version: 0.4
    /// </summary>
    class GameEntity : Entity
    {
        public string tag = "";
        public Texture2D Texture;
        public Vector2 Position;
        public Rectangle HitBox;
        public int row;
        public bool gravity = false;
        public bool onTerrain;
        public float speed;

        //References to the Managers
        public IBehaviourManager _BehaviourManager;
        public ICollidable _Collisions;
        public IPhysicsObj _PhysicsObj;

        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            _Collisions = _collider;
            _PhysicsObj = phys;
            _BehaviourManager = behaviours;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            UniqueData();
        }   //Initialises the objects, catching references to the managers
        public override void UniqueData()
        {
            CollidableObjs();
        }                    // Used to apply the specific variables such as animations onto the entity
        public override void accessPhysics(IPhysicsObj obj)
        { }  //Get access to the objects in the physics list
        public override void CollidableObjs()
        { }                //Used to get the Lists for the collidable Objects
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }   //Draws the entity onto the scene
        public virtual void Move()
        {
            Position.X += 4;
        }                           //Move Method used for testing entities
        public override void update(GameTime game)
        {
            Move();
        }           //Update method, called every fram



        #region get/sets
        public override Vector2 getPos()
        {
            return Position;
        }
        public override Texture2D getTex()
        {
            return Texture;
        }
        public override int getRows()
        {
            return row;
        }
        public override Rectangle getHitbox()
        {
            return HitBox;
        }
        public override bool getGrav()
        {
            return gravity;
        }
        public override string getTag()
        {
            return tag;
        }
        public override float getDirection()
        {
            return speed;
        }
        public override void setXPos(float Xpos)
        {
            Position.X = Xpos;

        }
        public override void setYPos(float Ypos)
        {
            Position.Y = Ypos;

        }
        public override void setRow(int rows)
        {
            row = rows;
        }
        public override void setGrav(bool active)
        {
            gravity = active;
        }
        #endregion
    }


}


