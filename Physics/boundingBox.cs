using System;
using csEngine.Core;

namespace csEngine.Physics
{
    public class boundingBox : collider
    {
        private Vector3 min;
        private Vector3 max;

        public Vector3 getMin() { return min; }
        public Vector3 getMax() { return max; }

        public override Vector3 getCenter() { return min; } //min functions as the position

        public override void Transform(Vector3 translation)
        {
            min += translation;
            max += translation;
        }

        public boundingBox(Vector3 min, Vector3 max) : base(colliderTypes.box)
        {
            this.min = min;
            this.max = max;
        }

        public intersectData boxAndSphere(boundingSphere other) //intersectData between a box and a sphere
        {
            float sqDist = MathsHelper.sqDistanceBetweenPointboundingBox(other.getCenter(), this);
            return new intersectData(sqDist <= other.getRadius() * other.getRadius(), Vector3.zero()); //distance is not working
        }

        public intersectData boxAndBox(boundingBox other) //intersectData between a box and a box
        {
            Vector3 distances1 = other.getMin() - max;
            Vector3 distances2 = min - other.getMax();

            Vector3 distance = new Vector3(
                MathsHelper.max(distances1.x, distances2.x),
                MathsHelper.max(distances1.y, distances2.y),
                MathsHelper.max(distances1.z, distances2.z));

            float maxDistance = MathsHelper.max(distance.x, (MathsHelper.max(distance.y, distance.z)));
            return new intersectData(maxDistance < 0, distance);
        }

        public intersectData boxAndPlane(boundingPlane other) //intersectData between a box and a plane
        {
            return new intersectData(false, Vector3.zero());
        }
    }
}
