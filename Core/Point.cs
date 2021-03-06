using System;
namespace csEngine.Core
{
    public class Point
    {
        public float x;
        public float y;
        public float z;

        public Point()
        {
            this.x = zero().x;
            this.y = zero().y;
            this.z = zero().z;
        }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point zero()
        {
            return new Point(0, 0, 0);
        }

        public Point(Point other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        public Point(Vector3 other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        public float distanceTo(Point other)
        {
            float distanceX = other.x - this.x;
            float distanceY = other.y - this.y;
            float distanceZ = other.z - this.z;

            float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ);

            return distance;
        }

        public Vector3 toVector3(Point point)
        {
            Vector3 vector3 = new Vector3();
            vector3.x = point.x;
            vector3.y = point.y;
            vector3.z = point.z;
            return vector3;
        }

        public override string ToString()
        {
            return "(" + this.x + ", " + this.y + ", " + this.z + ")";
        }
    }
}
