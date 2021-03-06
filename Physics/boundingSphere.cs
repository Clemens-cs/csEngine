using System;
using csEngine.Core;

namespace csEngine.Physics
{
    public class boundingSphere : collider
    {
        private Vector3 center;
        private float radius;

        public override Vector3 getCenter() { return center; }
        public float getRadius() { return radius; }

        public boundingSphere(Vector3 center, float radius) : base(colliderTypes.sphere)
        {
            this.center = center;
            this.radius = radius;
        }

        public override void Transform(Vector3 translation)
        {
            center += translation;
        }

        public intersectData sphereAndSphere(boundingSphere other) //intersectData between a sphere and a sphere
        {
            float radiusDistance = this.radius + other.radius;
            Vector3 direction = other.center - this.center;
            float centerDistance = direction.length;
            direction /= centerDistance;

            float distance = centerDistance - radiusDistance;

            return new intersectData(distance < 0, direction * distance);
        }

        public intersectData sphereAndBox(boundingBox other) //intersectData between a sphere and a box
        {
            float sqDist = MathsHelper.sqDistanceBetweenPointboundingBox(this.center, other);

            return new intersectData(sqDist <= this.radius * this.radius, Vector3.zero()); //direction is not working
        }

        public intersectData sphereAndPlane(boundingPlane other) //intersectData between a sphere and a plane
        {
            float distanceFromSphereCenter = Math.Abs(Vector3.dotProduct(center + other.getNormal()) + other.getDistance());
            float distanceFromSphere = distanceFromSphereCenter - radius;

            return new intersectData(distanceFromSphere < 0, other.getNormal() * distanceFromSphere);
        }
    }
}
