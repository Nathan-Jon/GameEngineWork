using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using EngineV2.Input;
using EngineV2.Input_Managment;
using EngineV2.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace EngineV2.Behaviours.Player_Behaviours
{
    class PlayerMind: IBehaviour
    {
        private IEntity body;
        private IMoveBehaviour moveXBehaviour;

        private KeyboardState keyState;
        private InputManager inputMgr;

        private InputSingleton singleInput;

        private int speed = 4;

        public PlayerMind()
        {
            
        }
        public  void Initialise(IEntity ent)
        {
            body = ent;
            moveXBehaviour = new xMoveBehaviour(body);
            singleInput = InputSingleton.GetInputInstance;
            singleInput.AddListener(OnNewInput);
        }

        public virtual void OnNewInput(object source, EventData data)
        {
            keyState = data.newKey;

            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {

                speed = 4;
                body.setXPos(body.getPos().X + speed);
            }

            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {

                speed = -4;
                body.setXPos(body.getPos().X + speed);
            }
        }

        public void update()
        {
        //    body.setXPos(body.getPos().X + speed);

        }
    }
}
