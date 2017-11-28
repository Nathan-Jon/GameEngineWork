using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    public sealed class SoundManager : ISoundManager
    {
        List<SoundEffect> SoundEffects = new List<SoundEffect>();
        List<SoundEffectInstance> InstanceList = new List<SoundEffectInstance>();
        SoundEffectInstance AudioInstance;


        private static ISoundManager instance = null;
        private static object syncInstance = new object();

        public SoundManager()
        {

        }

        /// <summary>
        /// Returns an instance of the ISoundManager
        /// </summary>
        public static ISoundManager getSoundInstance
        {
            get
            {
                if(instance == null)
                {
                    //Ensures only one class can access this if statement at a time
                    lock (syncInstance)
                    {
                        if (instance == null)
                            instance = new SoundManager();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Stores a SoundEffect in the SoundEffects list
        /// </summary>
        /// <param name="snd"></param>
        public void Initialize(SoundEffect snd)
        {
            SoundEffects.Add(snd);
            
        }

        /// <summary>
        /// Converts the SoundEffects to a class of type AudioInstance and stores them in a list called InstanceList
        /// </summary>
        public void CreateInstance()
        {
            for (int i = 0; i < SoundEffects.Count; i++)
            {
                AudioInstance = SoundEffects[i].CreateInstance();
                InstanceList.Add(AudioInstance);
            }
            
            
        }

        /// <summary>
        /// Starts the Audio from the instance list, setting the audio so it loops while setting the volume of said Audio
        /// </summary>
        /// <param name="sndno"></param>
        /// <param name="Volumenum"></param>
        public void Playsnd(int sndno, float Volumenum)
        {
            InstanceList[sndno].IsLooped = true;
            InstanceList[sndno].Play();
            InstanceList[sndno].Volume = Volumenum;
        }


        /// <summary>
        /// Stops specific Audio in the list from playing
        /// </summary>
        /// <param name="sndno"></param>
        public void Stopsnd(int sndno)
        {
            InstanceList[sndno].Stop();
        }

    }
}
