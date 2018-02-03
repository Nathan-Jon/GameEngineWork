using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace EngineV2.Interfaces
{
    public interface ISoundManager
    {
        void Initialize(string soundname, SoundEffect snd);
        void CreateInstance();
        void Playsnd(string soundName, float Volume);
        void Stopsnd(string soundName);
        
    }
}
