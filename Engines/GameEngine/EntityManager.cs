using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine
{
    class EntityManager : IEntity
    {
        public Texture2D Object;
        public Vector2 Locn;
        public static Vector2 Locn2;
        float facing = 1;


        public EntityManager()
        {

        }
        void IEntity.setPos(float Xpos, float Ypos)
        {
            Locn.X = Xpos;
            Locn.Y = Ypos;
            Locn2.X = Locn.X;
            Locn2.Y = Locn.Y;
        }
        void IEntity.setTex(Texture2D tex)
        {
            Object = tex;
        }
        public Vector2 getPos
        {
            get { return Locn; }
        }
        public Texture2D getTex
        {
            get { return Object; }
        }
        void IEntity.move()
        {
            Locn.X += 4*facing;
        }
        void IEntity.Input()
        {
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.W))
            {
                Locn.Y += -1;
            }
            if (state.IsKeyDown(Keys.S))
            {
                Locn.Y += 1;
            }
        }
        void IEntity.Draw(SpriteBatch spriteBatch)
        {
            //Draws the object on screen
            spriteBatch.Draw(getTex, getPos, Color.AntiqueWhite);
        }

        void IEntity.CollisionDetection()
        {
            //Side Of Screen//

            if (getPos.X >= 850)
            {
                //Locn.X = 850;
                facing = facing * -1;
            }
            if (getPos.X <= 0)
            {
                //Locn.X = 0;
                facing = facing * -1;
            }
            if (getPos.Y >= 550)
            {
                Locn.Y = 550;
            }
            if (getPos.Y <= 0)
            {
                Locn.Y = 0;
            }

        }

        void IEntity.Hitbox()
        {


        }


    }
}
