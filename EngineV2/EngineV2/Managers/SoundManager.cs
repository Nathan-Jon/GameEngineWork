using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    class SoundManager : ISoundManager
    {
        List<SoundEffect> SoundEffects;
        

        public void Initialize(SoundEffect snd, ContentManager Content)
        {
            
            Content.RootDirectory = "Content";
            SoundEffects = new List<SoundEffect>();
            SoundEffects.Add(snd);
            SoundEffects[0].Play();
        }

        public void update()
        {

        }

    }
}
