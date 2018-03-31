using Engine.Interfaces;
using Engine.Managers;
using Engine.Buttons;
using Engine.BackGround;

namespace Engine.ClearList
{
    public sealed class ListWipe : IListWipe, IProvider
    {

        //Variables

        public void Clear()
        {
            EntityManager.Entities.Clear();
            BehaviourManager.behaviours.Clear();
            //SoundManager.InstanceList.Clear();
            //SoundManager.SoundEffects.Clear();
            ButtonList.Buttons.Clear();
            BackGrounds.Backgrounds.Clear();


        }

    }
}
