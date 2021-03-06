using System;
using csEngine.Core;

namespace csEngine.Physics
{
    public class collider
    {
        public enum colliderTypes
        {
            sphere,
            box,
            plane
        }

        private colliderTypes type;
        public colliderTypes getType() { return type; }

        public virtual Vector3 getCenter() { return new Vector3(); }

        public collider(colliderTypes type)
        {
            this.type = type;
        }

        public virtual void Transform(Vector3 translation)
        {
            //this function will be overwritten in sphere, box and plane
        }

        public intersectData intersect(collider other)
        {
            if (type == colliderTypes.sphere && other.type == colliderTypes.sphere)//sphere sphere
            {
                boundingSphere sphere = (boundingSphere)this; //this to sphere (because its already a sphere)
                return sphere.sphereAndSphere((boundingSphere)other); //returns the sphereAndSphere function and casts other to it's collider   --> the same thing with all the other if else statements
            }
            else if (type == colliderTypes.sphere && other.type == colliderTypes.box)//sphere box
            {
                boundingSphere sphere = (boundingSphere)this;
                return sphere.sphereAndBox((boundingBox)other);
            }
            else if (type == colliderTypes.sphere && other.type == colliderTypes.plane)//sphere plane
            {
                boundingSphere sphere = (boundingSphere)this;
                return sphere.sphereAndPlane((boundingPlane)other);
            }
            else if (type == colliderTypes.box && other.type == colliderTypes.sphere)//box sphere
            {
                boundingBox box = (boundingBox)this;
                return box.boxAndSphere((boundingSphere)other);
            }
            else if (type == colliderTypes.box && other.type == colliderTypes.box)//box box
            {
                boundingBox box = (boundingBox)this;
                return box.boxAndBox((boundingBox)other);
            }
            else if (type == colliderTypes.box && other.type == colliderTypes.plane)//box plane
            {
                boundingBox box = (boundingBox)this;
                return box.boxAndPlane((boundingPlane)other);
            }
            else if (type == colliderTypes.plane && other.type == colliderTypes.sphere)//plane sphere
            {
                boundingPlane plane = (boundingPlane)this;
                return plane.planeAndSphere((boundingSphere)other);
            }
            else if (type == colliderTypes.plane && other.type == colliderTypes.box)//plane box
            {
                boundingPlane plane = (boundingPlane)this;
                return plane.planeAndBox((boundingBox)other);
            }
            else if (type == colliderTypes.plane && other.type == colliderTypes.plane)//plane plane
            {
                boundingPlane plane = (boundingPlane)this;
                return plane.planeAndPlane((boundingPlane)other);
            }
            else //if no collider matches the requirements
            {
                Console.WriteLine("Collider was not implimented!");
                throw new NotImplementedException();
            }
        }
    }
}
