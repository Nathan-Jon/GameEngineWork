using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Input;
using EngineV2.Collision_Management;
using EngineV2.Interfaces;

namespace EngineV2.Entities
{
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

        public override void Initialize(Texture2D Tex, Vector2 Posn, ICollidable _collider, ISoundManager snd, IPhysicsObj phys, IBehaviourManager behaviours)
        {
            Position = Posn;
            Texture = Tex;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public override void applyEventHandlers(InputManager inputManager, CollisionManager col)
        { }
        public override void accessPhysics(IPhysicsObj obj)
        { }
        public override void CollidableObjs()
        { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }
        public virtual void Move()
        {
            Position.X += 4;
        }
        public override void update()
        {
            Move();
        }
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

    }


}

