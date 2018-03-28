using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Engine.Interfaces;

namespace Engine.Managers
{
    public sealed class SoundManager : ISoundManager, IProvider
    {
        public static IDictionary<string, SoundEffect> SoundEffects = new Dictionary<string, SoundEffect>();
        public static IDictionary<string, SoundEffectInstance> InstanceList = new Dictionary<string, SoundEffectInstance>();
        SoundEffectInstance AudioInstance;

        public SoundManager()
        {

        }


        public void Initialize(string soundname, SoundEffect snd)
        {
            SoundEffects.Add(soundname, snd);
            
        }

        public void CreateInstance()
        {

            foreach (var songName in SoundEffects.ToArray())
            {
                AudioInstance = SoundEffects[songName.Key].CreateInstance();
                InstanceList.Add(songName.Key ,AudioInstance);
                
            }
            SoundEffects.Clear();
        }

        public void Playsnd(string soundName, float Volumenum)
        {
            InstanceList[soundName].IsLooped = true;
            InstanceList[soundName].Play();
            InstanceList[soundName].Volume = Volumenum;
        }

        public void Stopsnd(string soundName)
        {
            InstanceList[soundName].Stop();
        }

    }
}
