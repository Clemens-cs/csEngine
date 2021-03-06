using System;
using csEngine.Core;

namespace csEngine.Physics
{
    public class physicsObject
    {
        private Vector3 position;
        private Vector3 oldPosition;
        private Vector3 velocity;
        private collider _collider;

        public Vector3 getPosition() { return position; }
        public Vector3 getOldPosition() { return oldPosition; }
        public Vector3 getVelocity() { return velocity; }
        public collider getCollider()
        {
            Vector3 translation = position - oldPosition;
            oldPosition = position;
            _collider.Transform(translation);

            return _collider;
        }

        public void setVelocity(Vector3 velocity)
        {
            this.velocity = velocity;
        }

        public physicsObject(collider _collider, Vector3 velocity)
        {
            this.position = _collider.getCenter();
            this.oldPosition = _collider.getCenter();
            this.velocity = velocity;
            this._collider = _collider;
        }

        public physicsObject(physicsObject other)
        {
            position = other.position;
            oldPosition = other.oldPosition;
            velocity = other.velocity;
            _collider = other._collider;
        }

        public void integrate(float delta)
        {
            position += delta * velocity;
        }
    }
}
