using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EngineV2.Interfaces
{
    public interface IButton
    {
        void Initialize(Texture2D tex, Vector2 Posn);
        void Draw(SpriteBatch spriteBatch);
        Vector2 GetButtonPos();
        void update();
        Rectangle getHitbox();
        void click();
    }
}
