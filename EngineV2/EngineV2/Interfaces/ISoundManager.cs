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
        void Initialize(SoundEffect Snd);
        void CreateInstance();
        void Playsnd(int sndno, float Volume);
        void Stopsnd(int sndno);
        
    }
}
