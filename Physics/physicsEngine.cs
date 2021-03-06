using System;
using System.Collections.Generic;
using csEngine.Core;

namespace csEngine.Physics
{
    public class physicsEngine
    {
        public List<physicsObject> allPObjects = new List<physicsObject>();

        public physicsObject getPhysicsObject(int index) { return allPObjects[index]; }
        public int getNumberPObjects() { return allPObjects.Capacity; }
        public int getNumberOfThisPObject(physicsObject physicsObject) { return allPObjects.IndexOf(physicsObject); }

        public void addObject(physicsObject pObject)
        {
            allPObjects.Add(pObject);
        }

        public void removeObject(physicsObject pObject)
        {
            allPObjects.Remove(pObject);
        }

        public void removeObjectByIndex(physicsObject physicObject)
        {
            int index = getNumberOfThisPObject(physicObject);
            allPObjects.RemoveAt(index);
        }

        void simulate(float delta)
        {
            for (int i = 0; i < allPObjects.Capacity; i++)
            {
                allPObjects[i].integrate(delta);
            }
        }

        void handleCollisions()
        {
            for (int i = 0; i < allPObjects.Capacity; i++)
            {
                for (int j = i + 1; j < allPObjects.Capacity; j++)
                {
                    intersectData data = allPObjects[i].getCollider().intersect(allPObjects[j].getCollider());

                    if (data.getDoesIntersect())
                    {
                        Vector3 direction = Vector3.normalize(data.getDirection());

                        Vector3 normal = Vector3.normalize(allPObjects[i].getVelocity());
                        Vector3 otherDirection = new Vector3(direction - (normal * (Vector3.dotProduct(direction, normal) * 2)));

                        allPObjects[i].setVelocity(new Vector3(allPObjects[i].getVelocity() - (otherDirection * Vector3.dotProduct(allPObjects[i].getVelocity(), otherDirection) * 2)));
                        allPObjects[j].setVelocity(new Vector3(allPObjects[j].getVelocity() - (direction * Vector3.dotProduct(allPObjects[j].getVelocity(), direction) * 2)));
                    }
                }
            }
        }
    }
}
