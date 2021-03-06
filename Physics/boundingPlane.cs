using System;
using csEngine.Core;

namespace csEngine.Physics
{
    public class boundingPlane : collider
    {
        private Vector3 normal;
        private float distance;

        public Vector3 getNormal() { return normal; }
        public float getDistance() { return distance; }

        public override Vector3 getCenter() { return normal; }//normal functions as the center, which is basicly the position
        public override void Transform(Vector3 translation)
        {
            normal += translation;
        }

        public boundingPlane(Vector3 normal, float distance) : base(colliderTypes.plane)
        {
            this.normal = normal;
            this.distance = distance;
        }

        public boundingPlane normalized()
        {
            float length = normal.length;
            return new boundingPlane(normal / length, distance / length);
        }

        public intersectData planeAndSphere(boundingSphere other) //intersectData between a plane and a sphere
        {
            float distanceFromSphereCenter = Math.Abs(Vector3.dotProduct(other.getCenter() + normal) + distance);
            float distanceFromSphere = distanceFromSphereCenter - other.getRadius();

            return new intersectData(distanceFromSphere < 0, normal * distanceFromSphere);
        }

        public intersectData planeAndBox(boundingBox other) //intersectData between a plane and a box
        {
            return new intersectData(false, Vector3.zero());
        }

        public intersectData planeAndPlane(boundingPlane other) //intersectData between a plane and a plane
        {
            return new intersectData(false, Vector3.zero());
        }
    }
}
