﻿using Engine.Input_Managment;
using Engine.Interfaces;
using Microsoft.Xna.Framework.Input;
using ProjectHastings.Animations;
using ProjectHastings.Entities;
using Engine.Managers;


namespace ProjectHastings.Behaviours.Player_Behaviours
{
    class PlayerMind: IBehaviour
    {
        private IEntity body;

        private KeyboardState keyState;
        private Player player;
        private PlayerAnimation ani;


        private float speed = 2.5f;

        public PlayerMind()
        {
            
        }

        public  void Initialise(IEntity ent)
        {
            body = ent;
            ani = new PlayerAnimation();
            InputManager.GetInputInstance.AddListener(OnNewInput);
        }

        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;

            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {

                speed = 2.5f;
                body.setXPos(body.getPos().X + speed);
                Player.Animate = true;
                Player.row = 1;
                
            }

            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {

                speed = -2.5f;
                body.setXPos(body.getPos().X + speed);
                Player.Animate = true;
                Player.row = 0;
            }

            if (Player.canClimb && keyState.IsKeyDown(Keys.W) || Player.canClimb && keyState.IsKeyDown(Keys.Up))
            {
                speed = -2.5f;
                body.setYPos(body.getPos().Y + speed);
                Player.Animate = true;
                Player.row = 2;
                SoundManager.getSoundInstance.Playsnd("Ladder", 0.3f);

            }
            if (Player.canClimb && keyState.IsKeyDown(Keys.S) || Player.canClimb && keyState.IsKeyDown(Keys.Down))
            {
                speed = 2.5f;
                body.setYPos(body.getPos().Y + speed);
                Player.Animate = true;
                Player.row = 2;
                SoundManager.getSoundInstance.Playsnd("Ladder", 0.3f);
            }
        }

        public void update()
        {

        }

    }
}
