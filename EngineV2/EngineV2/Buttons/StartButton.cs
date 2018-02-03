using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineV2.Managers;
using EngineV2.Scenes;
using EngineV2.Interfaces;

namespace EngineV2.Buttons
{
    class StartButton : IButton
    {
        public Texture2D Texture;
        public static Vector2 Position;
        public Rectangle HitBox;



        public void Initialize(Texture2D tex, Vector2 Posn)
        {
            Texture = tex;
            Position = Posn;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);

        }

        public Vector2 GetButtonPos()
        {
            return Position;
        }

        public void update()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public Rectangle getHitbox()
        {
            return HitBox;
        }

        public void click()
        {
            SceneManager.mainmenu = false;
            SceneManager.TestLevel = true;
        }


    }
}
