using System;
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
        KeyboardState newState;
        MouseState newMouse;
        MouseState oldMouse;
        IEntity entity;


        public InputManager()
        {

        }

        public void Initialize(IEntity ent)
        {
            entity = ent;
            oldState = Keyboard.GetState();
            oldMouse = Mouse.GetState();
            
        }

        public void Update()
        {
            upmovement();
            downmovement();
            leftmovement();
            rightmovement();
            OnMouse();

        }

        public void upmovement()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.W) || newState.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.W) || !oldState.IsKeyDown(Keys.Up))
                {
                    entity.setYPos(entity.getYPos() + -2);
                }
            }

            
            //If below is uncommented, key cannot be held down for continous movement
            oldState = newState;
        }
        public void downmovement()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.S) || newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.S) || !oldState.IsKeyDown(Keys.Down))
                {
                    entity.setYPos(entity.getYPos() + 2);
                }
            }


            //If below is uncommented, key cannot be held down for continous movement
            oldState = newState;
        }
        public void leftmovement()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.A) || newState.IsKeyDown(Keys.Left))
            {
                if (!oldState.IsKeyDown(Keys.A) || !oldState.IsKeyDown(Keys.Left))
                {
                    entity.setXPos(entity.getXPos() + -2);
                }
            }

            
            //If below is uncommented, key cannot be held down for continous movement
            //oldState = newState;
        }
        public void rightmovement()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.D) || newState.IsKeyDown(Keys.Right))
            {
                if (!oldState.IsKeyDown(Keys.D) || !oldState.IsKeyDown(Keys.Right))
                {
                    entity.setXPos(entity.getXPos() + 2);
                }
            }


            //If below is uncommented, key cannot be held down for continous movement
            oldState = newState;
        }
        public void OnMouse()
        {

            newMouse = Mouse.GetState();
            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                if (oldMouse.LeftButton == ButtonState.Released)
                {
                    entity.setYPos(entity.getYPos() + -2);
                } 
            }

            //oldMouse = newMouse;
        }
    }
    
}

