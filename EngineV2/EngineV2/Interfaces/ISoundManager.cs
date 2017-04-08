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
        void Initialize(SoundEffect Snd, ContentManager Content);
        void Playsnd(int sndno);
        void Stopsnd(int sndno);
        void CreateInstance();
    }
}
