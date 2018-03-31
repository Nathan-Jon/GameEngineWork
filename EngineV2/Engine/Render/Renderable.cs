using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Interfaces;
using Engine.Managers;

namespace Engine.Render
{
    class Renderable : IRenderable
    {

        public void Draw(IScene scene, SpriteBatch sprite)
        {

            sprite.Begin();
            
            scene.Draw(sprite);

            sprite.End();

        }

    }
}
