using System;
namespace csEngine.Core
{
    public class Transform
    {
        private Transform parent;
        private Matrix parentMatrix;

        private Vector3 pos;
        private Quaternion rot;
        private Vector3 scale;

        private Vector3 oldPos;
        private Quaternion oldRot;
        private Vector3 oldScale;

        public Vector3 getPos() { return pos; }
        public Quaternion getRot() { return rot; }
        public Vector3 getScale() { return scale; }

        public void setPos(Vector3 pos) { this.pos = pos; }
        public void setRot(Quaternion rot) { this.rot = rot; }
        public void setScale(Vector3 scale) { this.scale = scale; }

        public Vector3 getTransformedPos() { return getParentMatrix().transform(pos); }

        public Quaternion getTransformedRot()
        {
            Quaternion parentRotation = new Quaternion(0, 0, 0, 1);

            if(parent != null)
            {
                parentRotation = parent.getTransformedRot();
            }

            return parentRotation * rot;
        }

        public void setParent(Transform parent) { this.parent = parent; }

        public Transform()
        {
            pos = new Vector3();
            rot = new Quaternion(0, 0, 0, 1);
            scale = new Vector3(1, 1, 1);

            parentMatrix = new Matrix().initIdentity();
        }

        public void update()
        {
            if(oldPos != null)
            {
                oldPos = pos;
                oldRot = rot;
                oldScale = scale;
            }
            else
            {
                oldPos = pos + 1f;
                oldRot = rot * 0.5f;
                oldScale = scale + 1f;
            }
        }

        public void rotate(Vector3 axis, float angle)
        {
            rot = new Quaternion(axis, angle) * Quaternion.normalize(rot);
        }

        public void lookAt(Vector3 point, Vector3 up)
        {
            rot = getLookAtRotation(point, up);
        }

        public Quaternion getLookAtRotation(Vector3 point, Vector3 up)
        {
            return new Quaternion(new Matrix().initRotation(point - Vector3.normalize(pos), up));
        }

        public bool hasChanged()
        {
            if(parent != null && parent.hasChanged()) { return true; }
            if(!pos.equals(oldPos)) { return true; }
            if(!rot.equals(oldRot)) { return true; }
            if(!scale.equals(oldScale)) { return true; }

            return false;
        }

        public Matrix getTransformation()
        {
            Matrix translationMatrix = new Matrix().initTranslation(pos.x, pos.y, pos.z);
            Matrix rotationMatrix = rot.ToRotationMatrix();
            Matrix scaleMatrix = new Matrix().initScale(scale.x, scale.y, scale.z);

            return getParentMatrix().mul(translationMatrix.mul(rotationMatrix.mul(scaleMatrix)));
        }

        private Matrix getParentMatrix()
        {
            if(parent != null && parent.hasChanged())
            {
                parentMatrix = parent.getTransformation();
            }

            return parentMatrix;
        }
    }
}
