using Microsoft.Xna.Framework.Graphics;

namespace Engine.Interfaces
{
    public interface IBackGrounds
    {
        void Initialize(string BackgroundName, Texture2D Texture);
        void Draw(SpriteBatch spriteBatch);

    }
}
