using System;


namespace Engine.Input_Managment
{
    interface InputSubscriber
    {
        void AddListener(EventHandler<EventData> handler);
    }
}
