﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineV2
{
    public class InputManager : IInputManager
    {
        KeyboardState oldState;
        KeyboardState newState ;
        IEntity entity;


        public InputManager()
        {

        }

        public void Initialize(IEntity ent)
        {
            entity = ent;
            oldState = Keyboard.GetState();
            newState = Keyboard.GetState();
        }

        public void Update()
        {
            upmovement();
            downmovement();
            leftmovement();
            rightmovement();

        }

        public void upmovement()
        {
            if (newState.IsKeyDown(Keys.W))
            {
                if (!oldState.IsKeyDown(Keys.W))
                {
                    entity.setYPos(entity.getYPos() + -2);

                }
            }
            else if (oldState.IsKeyDown(Keys.W))
            {

            }
            
            //If below is uncommented, key cannot be held down for continous movement
            //oldState = newState;
        }
        public void downmovement()
        {

            if (newState.IsKeyDown(Keys.S))
            {
                if (!oldState.IsKeyDown(Keys.S))
                {
                    entity.setYPos(entity.getYPos() + 2);

                }
            }
            else if (oldState.IsKeyDown(Keys.S))
            {

            }

            //If below is uncommented, key cannot be held down for continous movement
            //oldState = newState;
        }
        public void leftmovement()
        {

            if (newState.IsKeyDown(Keys.A))
            {
                if (!oldState.IsKeyDown(Keys.A))
                {
                    entity.setXPos(entity.getXPos() + -2);

                }
            }
            else if (oldState.IsKeyDown(Keys.A))
            {

            }
            
            //If below is uncommented, key cannot be held down for continous movement
            //oldState = newState;
        }
        public void rightmovement()
        {
            if (newState.IsKeyDown(Keys.D))
            {
                if (!oldState.IsKeyDown(Keys.D))
                {
                    entity.setXPos(entity.getXPos() + 2);

                }
            }
            else if (oldState.IsKeyDown(Keys.D))
            {

            }

            //If below is uncommented, key cannot be held down for continous movement
            //oldState = newState;
        }
    }
    
}

