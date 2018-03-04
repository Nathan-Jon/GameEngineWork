using EngineV2.Interfaces;
using EngineV2.Managers;
using EngineV2.Buttons;
using EngineV2.BackGround;

namespace EngineV2
{
    public sealed class ListWipe : IListWipe
    {

        //Variables
        private static ListWipe instance = null;
        private static object syncInstance = new object();

        public static IListWipe getListWipe
        {
            get
            {
                if (instance == null)
                {
                    lock (syncInstance)
                        if (instance == null)
                            instance = new ListWipe();
                }

                return instance;

            }

        }

        public void Clear()
        {
            EntityManager.Entities.Clear();
            BehaviourManager.behaviours.Clear();
            //SoundManager.InstanceList.Clear();
            //SoundManager.SoundEffects.Clear();
            ButtonList.menuButtons.Clear();
            BackGrounds.Backgrounds.Clear();


        }

    }
}
