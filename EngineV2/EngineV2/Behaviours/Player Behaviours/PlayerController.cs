using EngineV2.Input_Managment;
using EngineV2.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace EngineV2.Behaviours.Player_Behaviours
{
    class PlayerController
    {
        private KeyboardState keyState;
        private InputManager inputMgr;

        private IEntity body;
        private float speed = 4;

        public void Initialise(IEntity entity)
        {
            body = entity;
        }

        public void move()
        {
            body.setXPos(body.getPos().X + speed);
        }
    }
}
