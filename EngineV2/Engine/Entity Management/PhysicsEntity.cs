using Engine.Entity_Management;
using Engine.Physics;
using Microsoft.Xna.Framework;

namespace Engine.Entity_Management
{
    public abstract class  PhysicsEntity : Entity, IPhysics
    {
        public virtual Vector2 Velocity { get; set; }
        public virtual Vector2 Acceleration { get; set; }
        public Vector2 Gravity { get; set; }
        public virtual bool GravityBool { get; set; }

        //Inverse mass to encourage multiplication and not diviision due to multiplication being faster
        protected float InverseMass = -1.5f;
        protected float Restitution = 1f;
        protected float Damping = 0.5f;

        protected PhysicsEntity()
        {
          Gravity = new Vector2(0,2);
        }

        protected PhysicsEntity(Vector2 grav)
        {
            Gravity = grav;
        }

        public virtual void ApplyForce(Vector2 force)
        {
            //Multiply force by the inversemass to obtain the acceleration value
            Acceleration += force * InverseMass;
        }
        public virtual void ApplyImpulse(Vector2 closingVelo)
        {
            //Apply Impulse by setting the velocy to the closing velocity by the Restitution of the entity
            Velocity = closingVelo * Restitution;
        }

        public virtual void UpdatePhysics()
        {
            Velocity += Acceleration;
            Velocity *= Damping;
            Position += Velocity;

            //Apply Gravity
            if (GravityBool)
            Acceleration = Gravity;
            else
            {
                Acceleration = new Vector2(0,0);
            }

        }





    }
}
