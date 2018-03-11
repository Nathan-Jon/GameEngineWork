using Microsoft.Xna.Framework.Audio;

namespace Engine.Interfaces
{
    public interface ISoundManager
    {
        void Initialize(string soundname, SoundEffect snd);
        void CreateInstance();
        void Playsnd(string soundName, float Volume);
        void Stopsnd(string soundName);
        
    }
}
