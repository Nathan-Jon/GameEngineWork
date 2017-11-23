using EngineV2.Input;
using EngineV2.Input_Managment;
using EngineV2.Interfaces;
using Microsoft.Xna.Framework.Input;
using EngineV2.Animations;
using EngineV2.Entities;


namespace EngineV2.Behaviours.Player_Behaviours
{
    class PlayerMind: IBehaviour
    {
        private IEntity body;

        private KeyboardState keyState;
        private InputManager inputMgr;

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
            inputMgr = InputManager.GetInputInstance;
            inputMgr.AddListener(OnNewInput);
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
              //  sound.Playsnd(5);

            }
            if (Player.canClimb && keyState.IsKeyDown(Keys.S) || Player.canClimb && keyState.IsKeyDown(Keys.Down))
            {
                speed = 2.5f;
                body.setYPos(body.getPos().Y + speed);
                Player.Animate = true;
                Player.row = 2;
                //sound.Playsnd(5);
            }
        }

        public void update()
        {

        }

    }
}
