using System;
namespace csEngine.Core
{
    public class Vector3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public float length { get { return getLength(); } }

        public static Vector3 xAxis { get { return new Vector3(1, 0, 0); } }
        public static Vector3 yAxis { get { return new Vector3(0, 1, 0); } }
        public static Vector3 zAxis { get { return new Vector3(0, 0, 1); } }

        public float this[int i] //Vector3[0] represents Vector3.x Vector3[1] is Vector3.y
        {
            get
            {
                if (i == 0)
                {
                    return this.x;
                }
                else if (i == 1)
                {
                    return this.y;
                }
                else if (i == 2)
                {
                    return this.z;
                }
                else
                {
                    throw new Exception();
                }
            }
            set
            {
                if (i == 0)
                {
                    this.x = value;
                }
                else if (i == 1)
                {
                    this.y = value;
                }
                else if (i == 2)
                {
                    this.z = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public Vector3()
        {
            this.x = zero().x;
            this.y = zero().y;
            this.z = zero().z;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 zero()
        {
            return new Vector3(0, 0, 0);
        }

        public Vector3(Vector2 other, float a)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = a;
        }

        public Vector3(Vector3 other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        private float getLength() //Calculates the length of a Vector
        {
            float squareLength = this.x * this.x + this.y * this.y + this.z * this.z;
            float length = (float)Math.Sqrt(squareLength);
            return length;
        }

        public void scale(float scaleFactor) //scales the Vector
        {
            this.x *= scaleFactor;
            this.y *= scaleFactor;
            this.z *= scaleFactor;
        }

        public void reverse() //reverses a Vector
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public bool unitize() //changes x, y, z of a vector that the length is 1
        {
            float length = this.getLength();
            if (length <= 0)
            {
                return false;
            }

            this.x /= length;
            this.y /= length;
            this.z /= length;

            return true;
        }

        public void add(Vector3 other)
        {
            this.x += other.x;
            this.y += other.y;
            this.z += other.z;
        }

        public static Vector3 addition(Vector3 a, Vector3 b)
        {
            float newX = a.x + b.x;
            float newY = a.y + b.y;
            float newZ = a.z + b.z;

            Vector3 newVector3 = new Vector3(newX, newY, newZ);

            return newVector3;
        }

        public static Vector3 operator +(Vector3 a, float b)
        {
            float newX = a.x + b;
            float newY = a.y + b;
            float newZ = a.z + b;

            Vector3 newVector3 = new Vector3(newX, newY, newZ);

            return newVector3;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return Vector3.addition(a, b);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            float x = a.x * b.x;
            float y = a.y * b.y;
            float z = a.z * b.z;

            Vector3 vector3 = new Vector3(x, y, z);

            return vector3;
        }

        public static Vector3 operator *(float a, Vector3 b)
        {
            Vector3 vector3 = new Vector3(b);
            vector3.scale(a);
            return vector3;
        }

        public static Vector3 operator *(Vector3 b, float a)
        {
            Vector3 vector3 = new Vector3(b);
            vector3.scale(a);
            return vector3;
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            float x = a.x / b.x;
            float y = a.y / b.y;
            float z = a.z / b.z;

            Vector3 vector3 = new Vector3(x, y, z);

            return vector3;
        }

        public static Vector3 operator /(Vector3 a, float b)
        {
            float x = a.x / b;
            float y = a.y / b;
            float z = a.z / b;

            Vector3 vector3 = new Vector3(x, y, z);

            return vector3;
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            float x = a.x - b.x;
            float y = a.y - b.y;
            float z = a.z - b.z;

            Vector3 vector3 = new Vector3(x, y, z);

            return vector3;
        }

        public static Vector3 operator -(Vector3 a, float b)
        {
            float newX = a.x - b;
            float newY = a.y - b;
            float newZ = a.z - b;

            Vector3 newVector3 = new Vector3(newX, newY, newZ);

            return newVector3;
        }

        public static Vector3 normalize(Vector3 other) //creates a new Vector with normalized x, y, z values
        {
            float factor = (float)Math.Sqrt((other.x * other.x) + (other.y * other.y) + (other.z * other.z));
            factor = 1f / factor;

            return new Vector3(other.x * factor, other.y * factor, other.z * factor);
        }

        public static float dotProduct(Vector3 a) //returns a value of all x, y, z values multiplied 
        {
            return a.x + a.y + a.z;
        }

        public static float dotProduct(Vector3 a, Vector3 b) //returns a value of all x, y, z values multiplied 
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3 crossProduct(Vector3 a, Vector3 b) //if you have a Vector in x and y Direction, you get a Vector in the z direction)
        {
            float x = a.y * b.z - a.z * b.y;
            float y = a.z * b.x - a.x * b.z;
            float z = a.x * b.y - a.y * b.x;

            return new Vector3(x, y, z);
        }

        public Vector3 rotate(Vector3 axis, float angle)
        {
            float sinAngle = (float)Math.Sin(-angle);
            float cosAngle = (float)Math.Cos(-angle);

            return Vector3.crossProduct(axis * sinAngle + (this * cosAngle + (axis * (Vector3.dotProduct(this, axis * (1 - cosAngle))))), this);
        }

        public Vector3 rotate(Vector4 rotation)
        {
            Quaternion conjugate = rotation.ToQuaternion();
            conjugate.reverse();

            Quaternion w = rotation.ToQuaternion() * conjugate * this;

            return new Vector3(w.x, w.y, w.z);
        }

        public Vector3 rotate(Quaternion rotation)
        {
            Quaternion conjugate = rotation.reverse2();

            Quaternion w = rotation * conjugate * this;

            return new Vector3(w.x, w.y, w.z);
        }

        public static Vector3 max(Vector3 a, Vector3 b)//gets the max for the collision detection
        {
            float x = MathsHelper.max(a.x, b.x);
            float y = MathsHelper.max(a.y, b.y);
            float z = MathsHelper.max(a.z, b.z);
            return new Vector3(x, y, z);
        }

        public static Vector3 min(Vector3 a, Vector3 b)//gets the min for the collision detection
        {
            float x = MathsHelper.min(a.x, b.x);
            float y = MathsHelper.min(a.y, b.y);
            float z = MathsHelper.min(a.z, b.z);
            return new Vector3(x, y, z);
        }

        public static float maxLength(Vector3 vector3)
        {
            return MathsHelper.max(vector3.x, MathsHelper.max(vector3.y, vector3.z));
        }

        public static float minLength(Vector3 vector3)
        {
            return MathsHelper.min(vector3.x, MathsHelper.min(vector3.y, vector3.z));
        }

        public bool equals(Vector3 r)
        {
            return x == r.x && y == r.y && z == r.z;
        }

        public override string ToString() //If you want to print it as a string it shows like [1, 5, 8]
        {
            return $"[{this.x}, {this.y}, {this.z}]";
        }
    }
}
