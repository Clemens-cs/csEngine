using System;
namespace csEngine.Core
{
    public class Vector4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }

        public float length { get { return getLength(); } }

        public static Vector4 xAxis { get { return new Vector4(1f, 0, 0, 0); } }
        public static Vector4 yAxis { get { return new Vector4(0, 1f, 0, 0); } }
        public static Vector4 zAxis { get { return new Vector4(0, 0, 1f, 0); } }
        public static Vector4 wAxis { get { return new Vector4(0, 0, 0, 1f); } }

        public float this[int i] //Vector4[0] represents Vector4.x Vector4[1] is Vector4.y
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
                else if (i == 3)
                {
                    return this.w;
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
                else if (i == 3)
                {
                    this.w = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public Vector4()
        {
            this.x = zero().x;
            this.y = zero().y;
            this.z = zero().z;
            this.w = zero().w;
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4 zero()
        {
            return new Vector4(0, 0, 0, 0);
        }

        public Vector4(Vector2 other, float a, float b)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = a;
            this.w = b;
        }

        public Vector4(Vector3 other, float a)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
            this.w = a;
        }

        public Vector4(Vector4 other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
            this.w = other.w;
        }

        private float getLength() //Calculates the length of a Vector
        {
            float squareLength = this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;
            float length = (float)Math.Sqrt(squareLength);
            return length;
        }

        public void scale(float scaleFactor)
        {
            this.x *= scaleFactor;
            this.y *= scaleFactor;
            this.z *= scaleFactor;
            this.w *= scaleFactor;
        }

        public void reverse()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
            this.w = -this.w;
        }
        public bool unitize() //changes x, y, z, w of a vector that the length is 1
        {
            float length = this.getLength();
            if (length <= 0)
            {
                return false;
            }

            this.x /= length;
            this.y /= length;
            this.z /= length;
            this.w /= length;

            return true;
        }

        public void add(Vector4 other)
        {
            this.x += other.x;
            this.y += other.y;
            this.z += other.z;
            this.w += other.w;
        }

        public static Vector4 addition(Vector4 a, Vector4 b)
        {
            float newX = a.x + b.x;
            float newY = a.y + b.y;
            float newZ = a.z + b.z;
            float newW = a.w + b.w;

            return new Vector4(newX, newY, newZ, newW);
        }


        public static Vector4 operator +(Vector4 a, float b)
        {
            float newX = a.x + b;
            float newY = a.y + b;
            float newZ = a.z + b;
            float newW = a.w + b;

            return new Vector4(newX, newY, newZ, newW);
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return Vector4.addition(a, b);
        }

        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            float x = a.x * b.x;
            float y = a.y * b.y;
            float z = a.z * b.z;
            float w = a.w * b.w;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator *(float a, Vector4 b)
        {
            Vector4 vector4 = new Vector4(b);
            vector4.scale(a);
            return vector4;
        }

        public static Vector4 operator *(Vector4 b, float a)
        {
            Vector4 vector4 = new Vector4(b);
            vector4.scale(a);
            return vector4;
        }

        public static Vector4 operator /(Vector4 a, Vector4 b)
        {
            float x = a.x / b.x;
            float y = a.y / b.y;
            float z = a.z / b.z;
            float w = a.w / b.w;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator /(Vector4 a, float b)
        {
            float x = a.x / b;
            float y = a.y / b;
            float z = a.z / b;
            float w = a.w / b;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            float x = a.x - b.x;
            float y = a.y - b.y;
            float z = a.z - b.z;
            float w = a.w - b.w;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator -(Vector4 a, float b)
        {
            float newX = a.x - b;
            float newY = a.y - b;
            float newZ = a.z - b;
            float newW = a.w - b;

            return new Vector4(newX, newY, newZ, newW);
        }

        public static Vector4 normalize(Vector4 other) //creates a new Vector with normalized x, y, z, w values
        {
            float factor = (float)Math.Sqrt((other.x * other.x) + (other.y * other.y) + (other.z * other.z) + (other.w * other.w));
            factor = 1f / factor;

            return new Vector4(other.x * factor, other.y * factor, other.z * factor, other.w * factor);
        }

        public static float dotProduct(Vector4 a) //returns a value of all x, y, z, w values multiplied 
        {
            return a.x + a.y + a.z + a.w;
        }

        public static float dotProduct(Vector4 a, Vector4 b) //returns a value of all x, y, z, w values multiplied 
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
        public static Vector4 max(Vector4 a, Vector4 b)//gets the max for the collision detection
        {
            float x = MathsHelper.max(a.x, b.x);
            float y = MathsHelper.max(a.y, b.y);
            float z = MathsHelper.max(a.z, b.z);
            float w = MathsHelper.max(a.w, b.w);
            return new Vector4(x, y, z, w);
        }

        public static Vector4 min(Vector4 a, Vector4 b)//gets the min for the collision detection
        {
            float x = MathsHelper.min(a.x, b.x);
            float y = MathsHelper.min(a.y, b.y);
            float z = MathsHelper.min(a.z, b.z);
            float w = MathsHelper.min(a.w, b.w);
            return new Vector4(x, y, z, w);
        }

        public static float maxLength(Vector4 vector4)
        {
            return MathsHelper.max(vector4.x, MathsHelper.max(vector4.y, MathsHelper.max(vector4.z, vector4.w)));
        }

        public static float minLength(Vector4 vector4)
        {
            return MathsHelper.min(vector4.x, MathsHelper.min(vector4.y, MathsHelper.min(vector4.z, vector4.w)));
        }

        public Quaternion ToQuaternion()
        {
            return new Quaternion(this.x, this.y, this.z, this.w);
        }

        public override string ToString() //If you want to print it as a string it shows like [1, 5, 8, 0]
        {
            return $"[{this.x}, {this.y}, {this.z}, {this.w}]";
        }
    }
}
