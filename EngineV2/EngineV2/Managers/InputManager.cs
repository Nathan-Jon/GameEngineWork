using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineV2.Interfaces;

namespace EngineV2.Managers
{
    public class InputManager : IInputManager
    {
        KeyboardState oldState;
        KeyboardState newState;
        MouseState newMouse;
        MouseState oldMouse;
        IEntity entity;
        public List<IEntity> Entitiesimp = new List<IEntity>();


        public InputManager()
        {

        }

        public void Initialize(IEntity ent)
        {
            entity = ent;
            Entitiesimp.Add(entity);
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
                if (!oldState.IsKeyDown(Keys.W) && !oldState.IsKeyDown(Keys.Up))
                {
                    for(int i = 0; i < Entitiesimp.Count; i++)
                    {
                        Entitiesimp[i].setYPos(entity.getPos().Y + -2);
                    }
                    
                }
            }

        }
        public void downmovement()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.S) || newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.S) && !oldState.IsKeyDown(Keys.Down))
                {
                    for (int i = 0; i < Entitiesimp.Count; i++)
                    {
                        Entitiesimp[i].setYPos(entity.getPos().Y + 2);
                    }
                }
            }

        }
        public void leftmovement()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.A) || newState.IsKeyDown(Keys.Left))
            {
                if (!oldState.IsKeyDown(Keys.A) && !oldState.IsKeyDown(Keys.Left))
                {
                    for (int i = 0; i < Entitiesimp.Count; i++)
                    {
                        Entitiesimp[i].setXPos(entity.getPos().X + -2);
                    }
                }
            }

            
        }
        public void rightmovement()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.D) || newState.IsKeyDown(Keys.Right))
            {
                if (!oldState.IsKeyDown(Keys.D) && !oldState.IsKeyDown(Keys.Right))
                {
                    for (int i = 0; i < Entitiesimp.Count; i++)
                    {
                        Entitiesimp[i].setXPos(entity.getPos().X + 2);
                    }
                }
            }

        }
        public void OnMouse()
        {

            newMouse = Mouse.GetState();
            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                if (oldMouse.LeftButton == ButtonState.Released)
                {
                    for (int i = 0; i < Entitiesimp.Count; i++)
                    {
                        Entitiesimp[i].setYPos(entity.getPos().Y + -2);
                    }
                } 
            }

            //If below is uncommented, key cannot be held down for continous movement
            //oldMouse = newMouse;
        }
    }
    
}

