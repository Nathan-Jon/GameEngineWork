using Engine.Interfaces;
using Engine.Managers;
using Engine.Buttons;
using Engine.BackGround;

namespace Engine
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
