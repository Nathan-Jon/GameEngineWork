using Microsoft.Xna.Framework;

namespace Engine.Physics
{

    public interface IPhysics
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        Vector2 Gravity { get; set; }
        bool GravityBool { get; set; }

        void ApplyForce(Vector2 force);
        void ApplyImpulse(Vector2 closingVelo);
        void UpdatePhysics();

    }
}
