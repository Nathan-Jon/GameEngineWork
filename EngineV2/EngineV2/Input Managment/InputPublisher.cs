using KeyboardState = Microsoft.Xna.Framework.Input.KeyboardState;

namespace EngineV2.Input
{
    interface InputPublisher
    {
        /// <summary>
        /// Detects changes to be raised int he Event Handler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        void OnNewInput(object source, KeyboardState data);
    }
}
