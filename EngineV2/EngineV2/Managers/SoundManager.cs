using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    class SoundManager : ISoundManager
    {
        List<SoundEffect> SoundEffects = new List<SoundEffect>();
        List<SoundEffectInstance> InstanceList = new List<SoundEffectInstance>();
        SoundEffectInstance instance;
        

        public void Initialize(SoundEffect snd)
        {
            SoundEffects.Add(snd);
            
        }

        public void CreateInstance()
        {
            for (int i = 0; i < SoundEffects.Count; i++)
            {   
                instance = SoundEffects[i].CreateInstance();
                InstanceList.Add(instance);
            }
            
            
        }

        public void Playsnd(int sndno)
        {
            InstanceList[sndno].IsLooped = true;
            InstanceList[sndno].Play();
        }

        public void Stopsnd(int sndno)
        {
            InstanceList[sndno].Stop();
        }

        public void Volume(int sndno, float Volumenum)
        {
            InstanceList[sndno].Volume = Volumenum;
        }
    }
}
