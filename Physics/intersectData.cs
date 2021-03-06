using System;
using csEngine.Core;

namespace csEngine.Physics
{
    public class intersectData
    {
        private bool doesIntersect;
        private Vector3 direction;

        public intersectData(bool doesIntersect, Vector3 direction)
        {
            this.doesIntersect = doesIntersect;
            this.direction = direction;
        }

        public bool getDoesIntersect() { return doesIntersect; }
        public Vector3 getDirection() { return direction; }
        public float getDistance() { return direction.length; }
    }
}
