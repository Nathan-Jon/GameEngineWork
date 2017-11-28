using System;
namespace EngineV2.Input
{
    interface InputSubscriber
    {
        /// <summary>
        /// subscribes a class to the event handler
        /// </summary>
        /// <param name="handler"></param>
        void AddListener(EventHandler<EventData> handler);
    }
}
