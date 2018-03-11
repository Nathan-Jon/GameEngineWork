using Microsoft.Xna.Framework.Input;



namespace Engine.Input
{
    interface InputPublisher
    {
        void OnNewInput(object source, KeyboardState data);
    }
}
