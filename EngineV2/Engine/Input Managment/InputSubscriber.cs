using System;
namespace EngineV2.Input
{
    interface InputSubscriber
    {
        void AddListener(EventHandler<EventData> handler);
    }
}
