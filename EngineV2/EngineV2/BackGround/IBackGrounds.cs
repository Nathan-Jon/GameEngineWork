using Microsoft.Xna.Framework.Graphics;

namespace EngineV2.BackGround
{
    interface IBackGrounds
    {
        void Initialize(Texture2D tex);
        void Draw(SpriteBatch spriteBatch);

    }
}
