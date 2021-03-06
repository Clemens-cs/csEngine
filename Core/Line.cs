using System;
namespace csEngine.Core
{
    public class Line
    {
        public float startX, startY, startZ;
        public float endX, endY, endZ;

        public Line(Point start, Point end)
        {
            this.startX = start.x;
            this.startY = start.y;
            this.startZ = start.z;

            this.endX = end.x;
            this.endY = end.y;
            this.endZ = end.z;
        }

        public Line(Point start, Vector3 direction)
        {
            this.startX = start.x;
            this.startY = start.y;
            this.startZ = start.z;

            this.endX = start.x + direction.x;
            this.endY = start.y + direction.y;
            this.endZ = start.z + direction.z;
        }

        public float getLength()
        {
            float distanceX = this.endX - this.startX;
            float distanceY = this.endY - this.startY;
            float distanceZ = this.endZ - this.startZ;

            float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ);

            return distance;
        }

        public override string ToString()
        {
            return "Line (" + this.startX + ", " + this.startY + ", " + this.startZ + ") to (" + this.endX + ", " + this.endY + ", " + this.endZ + ")";
        }
    }
}
