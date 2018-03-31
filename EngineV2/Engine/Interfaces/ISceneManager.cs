using Microsoft.Xna.Framework;

namespace Engine.Interfaces
{
    public interface ISceneManager
    {
        void Update(GameTime gameTime);
        void AddScene(string name, IScene scenes);
        void ChangeScene(string name);
        void RemoveScene(string name);
    }
}
