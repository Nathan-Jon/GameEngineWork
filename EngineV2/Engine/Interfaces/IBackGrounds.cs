using Microsoft.Xna.Framework.Graphics;

namespace EngineV2.Interfaces
{
    public interface IBackGrounds
    {
        void Initialize(string BackgroundName, Texture2D Texture);
        void Draw(SpriteBatch spriteBatch);

    }
}
