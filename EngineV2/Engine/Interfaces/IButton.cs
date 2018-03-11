using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Interfaces
{
    public interface IButton
    {
        void Initialize(Texture2D tex, Vector2 Posn);
        void Draw(SpriteBatch spriteBatch);
        void update();
        Rectangle HitBox { get; set; }
        void click();
    }
}
