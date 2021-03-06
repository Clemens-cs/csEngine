using System;
namespace csEngine.Core
{
    public class Quaternion
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }

        public static readonly Quaternion identity = new Quaternion(0, 0, 0, 1);

        public float length { get { return getLength(); } }

        public Quaternion()
        {
            this.x = zero().x;
            this.y = zero().y;
            this.z = zero().z;
            this.w = zero().w;
        }


        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Quaternion(Vector3 other, float w)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
            this.w = w;
        }

        public Quaternion(Vector4 other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
            this.w = other.w;
        }

        public Quaternion(Matrix rot)
        {
            float trace = rot.get(0, 0) + rot.get(1, 1) + rot.get(2, 2);

            if (trace > 0)
            {
                float s = 0.5f / (float)Math.Sqrt(trace + 1.0f);
                w = 0.25f / s;
                x = (rot.get(1, 2) - rot.get(2, 1)) * s;
                y = (rot.get(2, 0) - rot.get(0, 2)) * s;
                z = (rot.get(0, 1) - rot.get(1, 0)) * s;
            }
            else
            {
                if (rot.get(0, 0) > rot.get(1, 1) && rot.get(0, 0) > rot.get(2, 2))
                {
                    float s = 2.0f * (float)Math.Sqrt(1.0f + rot.get(0, 0) - rot.get(1, 1) - rot.get(2, 2));
                    w = (rot.get(1, 2) - rot.get(2, 1)) / s;
                    x = 0.25f * s;
                    y = (rot.get(1, 0) + rot.get(0, 1)) / s;
                    z = (rot.get(2, 0) + rot.get(0, 2)) / s;
                }
                else if (rot.get(1, 1) > rot.get(2, 2))
                {
                    float s = 2.0f * (float)Math.Sqrt(1.0f + rot.get(1, 1) - rot.get(0, 0) - rot.get(2, 2));
                    w = (rot.get(2, 0) - rot.get(0, 2)) / s;
                    x = (rot.get(1, 0) + rot.get(0, 1)) / s;
                    y = 0.25f * s;
                    z = (rot.get(2, 1) + rot.get(1, 2)) / s;
                }
                else
                {
                    float s = 2.0f * (float)Math.Sqrt(1.0f + rot.get(2, 2) - rot.get(0, 0) - rot.get(1, 1));
                    w = (rot.get(0, 1) - rot.get(1, 0)) / s;
                    x = (rot.get(2, 0) + rot.get(0, 2)) / s;
                    y = (rot.get(1, 2) + rot.get(2, 1)) / s;
                    z = 0.25f * s;
                }
            }

            float length = (float)Math.Sqrt(x * x + y * y + z * z + w * w);
            x /= length;
            y /= length;
            z /= length;
            w /= length;
        }

        public Quaternion zero()
        {
            return new Quaternion(0, 0, 0, 0);
        }

        public void add(Quaternion other)
        {
            this.x += other.x;
            this.y += other.y;
            this.z += other.z;
            this.w += other.w;
        }

        public static Quaternion addition(Quaternion a, Quaternion b)
        {
            float newX = a.x + b.x;
            float newY = a.y + b.y;
            float newZ = a.z + b.z;
            float newW = a.w + b.w;

            return new Quaternion(newX, newY, newZ, newW);
        }

        public static Quaternion operator +(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion = new Quaternion();
            quaternion.x = quaternion1.x + quaternion2.x;
            quaternion.y = quaternion1.y + quaternion2.y;
            quaternion.z = quaternion1.z + quaternion2.z;
            quaternion.w = quaternion1.w + quaternion2.w;
            return quaternion;
        }

        public static Quaternion operator -(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion = new Quaternion();
            quaternion.x = quaternion1.x - quaternion2.x;
            quaternion.y = quaternion1.y - quaternion2.y;
            quaternion.z = quaternion1.z - quaternion2.z;
            quaternion.w = quaternion1.w - quaternion2.w;
            return quaternion;

        }

        public static Quaternion operator /(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion = new Quaternion();
            float x = quaternion1.x;
            float y = quaternion1.y;
            float z = quaternion1.z;
            float w = quaternion1.w;
            float num14 = (((quaternion2.x * quaternion2.x) + (quaternion2.y * quaternion2.y)) + (quaternion2.z * quaternion2.z)) + (quaternion2.w * quaternion2.w);
            float num5 = 1f / num14;
            float num4 = -quaternion2.x * num5;
            float num3 = -quaternion2.y * num5;
            float num2 = -quaternion2.z * num5;
            float num = quaternion2.w * num5;
            float num13 = (y * num2) - (z * num3);
            float num12 = (z * num4) - (x * num2);
            float num11 = (x * num3) - (y * num4);
            float num10 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.x = ((x * num) + (num4 * w)) + num13;
            quaternion.y = ((y * num) + (num3 * w)) + num12;
            quaternion.z = ((z * num) + (num2 * w)) + num11;
            quaternion.w = (w * num) - num10;
            return quaternion;
        }

        public static Quaternion operator *(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion = new Quaternion();
            float x = quaternion1.x;
            float y = quaternion1.y;
            float z = quaternion1.z;
            float w = quaternion1.w;
            float num4 = quaternion2.x;
            float num3 = quaternion2.y;
            float num2 = quaternion2.z;
            float num = quaternion2.w;
            float num12 = (y * num2) - (z * num3);
            float num11 = (z * num4) - (x * num2);
            float num10 = (x * num3) - (y * num4);
            float num9 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.x = ((x * num) + (num4 * w)) + num12;
            quaternion.y = ((y * num) + (num3 * w)) + num11;
            quaternion.z = ((z * num) + (num2 * w)) + num10;
            quaternion.w = (w * num) - num9;
            return quaternion;
        }

        public static Quaternion operator *(Quaternion quaternion1, float scaleFactor)
        {
            Quaternion quaternion = new Quaternion();
            quaternion.x = quaternion1.x * scaleFactor;
            quaternion.y = quaternion1.y * scaleFactor;
            quaternion.z = quaternion1.z * scaleFactor;
            quaternion.w = quaternion1.w * scaleFactor;
            return quaternion;
        }

        public static Quaternion operator *(Quaternion a, Vector3 r)
        {
            float _x =  a.w * r.x + a.y * r.z - a.z * r.z;
            float _y =  a.w * r.y + a.z * r.x - a.x * r.z;
            float _z =  a.w * r.z + a.x * r.y - a.y * r.x;
            float _w = -a.x * r.x - a.y * r.y - a.z * r.z;
            return new Quaternion(_x, _y, _z, _w);
        }

        public static Quaternion concatenate(Quaternion value1, Quaternion value2)
        {
            float x1 = value1.x;
            float y1 = value1.y;
            float z1 = value1.z;
            float w1 = value1.w;

            float x2 = value2.x;
            float y2 = value2.y;
            float z2 = value2.z;
            float w2 = value2.w;

            Quaternion quaternion = new Quaternion();

            quaternion.x = (x2 * w1) + (x1 * w2) + ((y2 * z1) - (z2 * y1));
            quaternion.y = ((y2 * w1) + (y1 * w2)) + ((z2 * x1) - (x2 * z1));
            quaternion.z = (z2 * w1) + (z1 * w2) + ((x2 * y1) - (y2 * x1));
            quaternion.w = (w2 * w1) - (((x2 * x1) + (y2 * y1)) + (z2 * z1));

            return quaternion;
        }

        public void reverse()//reverses only x, y, z  not w
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public static Quaternion reverse(Quaternion a) //reverses only x, y, z
        {
            return new Quaternion(-a.x, -a.y, -a.z, a.w);
        }

        public Quaternion reverse2()
        {
            return new Quaternion(-this.x, -this.y, -this.z, this.w);
        }

        private float getLength() //Calculates the length 
        {
            float squareLength = this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;
            float length = (float)Math.Sqrt(squareLength);
            return length;
        }

        public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle) //new Quaternion from the angle of the axis
        {
            float half = angle * 0.5f;
            float sin = (float)Math.Sin(half);
            float cos = (float)Math.Cos(half);
            return new Quaternion(axis.x * sin, axis.y * sin, axis.z * sin, cos);
        }

        public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll) //new Quarternion from yaw, pitch and roll angles
        {
            float halfRoll = roll * 0.5f;
            float halfPitch = pitch * 0.5f;
            float halfYaw = yaw * 0.5f;

            float sinRoll = (float)Math.Sin(halfRoll);
            float cosRoll = (float)Math.Cos(halfRoll);
            float sinPitch = (float)Math.Sin(halfPitch);
            float cosPitch = (float)Math.Cos(halfPitch);
            float sinYaw = (float)Math.Sin(halfYaw);
            float cosYaw = (float)Math.Cos(halfYaw);

            return new Quaternion((cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll),
                                  (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll),
                                  (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll),
                                  (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll));
        }

        public static float dotProduct(Quaternion quaternion1, Quaternion quaternion2)
        {
            return ((((quaternion1.x * quaternion2.x) + (quaternion1.y * quaternion2.y)) + (quaternion1.z * quaternion2.z)) + (quaternion1.w * quaternion2.w));
        }

        public static Quaternion lerp(Quaternion quaternion1, Quaternion quaternion2, float amount) //returns a spherical linear blend between two Quarternions
        {
            float num = amount;
            float num2 = 1f - num;
            Quaternion quaternion = new Quaternion();
            float num5 = (((quaternion1.x * quaternion2.x) + (quaternion1.y * quaternion2.y)) + (quaternion1.z * quaternion2.z)) + (quaternion1.w * quaternion2.w);
            if (num5 >= 0f)
            {
                quaternion.x = (num2 * quaternion1.x) + (num * quaternion2.x);
                quaternion.y = (num2 * quaternion1.y) + (num * quaternion2.y);
                quaternion.z = (num2 * quaternion1.z) + (num * quaternion2.z);
                quaternion.w = (num2 * quaternion1.w) + (num * quaternion2.w);
            }
            else
            {
                quaternion.x = (num2 * quaternion1.x) - (num * quaternion2.x);
                quaternion.y = (num2 * quaternion1.y) - (num * quaternion2.y);
                quaternion.z = (num2 * quaternion1.y) - (num * quaternion2.z);
                quaternion.w = (num2 * quaternion1.w) - (num * quaternion2.w);
            }
            float num4 = (((quaternion.x * quaternion.x) + (quaternion.y * quaternion.y)) + (quaternion.z * quaternion.z)) + (quaternion.w * quaternion.w);
            float num3 = 1f / ((float)Math.Sqrt((double)num4));
            quaternion.x *= num3;
            quaternion.y *= num3;
            quaternion.z *= num3;
            quaternion.w *= num3;
            return quaternion;
        }

        public Quaternion nLerp(Quaternion dest, float lerpFactor, bool shortest)
        {
            Quaternion correctedDest = dest;

            if(shortest && Quaternion.dotProduct(this, dest) < 0)
            {
                correctedDest = new Quaternion(-dest.x, -dest.y, -dest.z, -dest.w);
            }

            return (correctedDest - (this)) * lerpFactor + Quaternion.normalize(this);
        }

        public Quaternion sLerp(Quaternion dest, float lerpFactor, bool shortest)
        {
            float epsilon = 1e3f;

            float cos = Quaternion.dotProduct(this, dest);
            Quaternion correctedDest = dest;

            if (shortest)
            {
                cos = -cos;
                correctedDest = new Quaternion(-dest.x, -dest.y, -dest.z, -dest.w);
            }

            if (Math.Abs(cos) >= 1 - epsilon)
                return nLerp(correctedDest, lerpFactor, false);

            float sin = (float)Math.Sqrt(1.0f - cos * cos);
            float angle = (float)Math.Atan2(sin, cos);
            float invSin = 1.0f / sin;

            float srcFactor = (float)Math.Sin((1.0f - lerpFactor) * angle) * invSin;
            float destFactor = (float)Math.Sin((lerpFactor) * angle) * invSin;

            return ((this * srcFactor) + correctedDest) * destFactor;
        }

        public static Quaternion slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)//returns a spherical linear blend between two Quarternions
        {
            float num2;
            float num3;
            Quaternion quaternion = new Quaternion();
            float num = amount;
            float num4 = (((quaternion1.x * quaternion2.x) + (quaternion1.y * quaternion2.y)) + (quaternion1.z * quaternion2.z)) + (quaternion1.w * quaternion2.w);
            bool flag = false;
            if (num4 < 0f)
            {
                flag = true;
                num4 = -num4;
            }
            if (num4 > 0.999999f)
            {
                num3 = 1f - num;
                num2 = flag ? -num : num;
            }
            else
            {
                float num5 = (float)Math.Acos((double)num4);
                float num6 = (float)(1.0 / Math.Sin((double)num5));
                num3 = ((float)Math.Sin((double)((1f - num) * num5))) * num6;
                num2 = flag ? (((float)-Math.Sin((double)(num * num5))) * num6) : (((float)Math.Sin((double)(num * num5))) * num6);
            }
            quaternion.x = (num3 * quaternion1.x) + (num2 * quaternion2.x);
            quaternion.y = (num3 * quaternion1.y) + (num2 * quaternion2.y);
            quaternion.z = (num3 * quaternion1.z) + (num2 * quaternion2.z);
            quaternion.w = (num3 * quaternion1.w) + (num2 * quaternion2.w);
            return quaternion;
        }

        public static Quaternion normalize(Quaternion quaternion)//normalizes the Quarternion
        {
            Quaternion result = new Quaternion();
            float num = 1f / ((float)Math.Sqrt((quaternion.x * quaternion.x) + (quaternion.y * quaternion.y) + (quaternion.z * quaternion.z) + (quaternion.w * quaternion.w)));
            result.x = quaternion.x * num;
            result.y = quaternion.y * num;
            result.z = quaternion.z * num;
            result.w = quaternion.w * num;
            return result;
        }

        public Quaternion conjugate() //the same as reverse
        {
            return reverse(this);
        }

        public Matrix ToRotationMatrix()
        {
            Vector3 forward = new Vector3(2f * (this.x * this.z - this.w * this.y), 2f * (this.y * this.z + this.w * this.x), 1f - 2f * (this.x + this.x + this.y + this.y));
            Vector3 up = new Vector3(2f * (this.x * this.y + this.w * this.z), 1f - 2f * (this.x * this.x + this.z * this.z), 2f * (this.y * this.z - this.w * this.x));
            Vector3 right = new Vector3(1f - 2f * (this.y * this.y + this.z * this.z), 2f * (this.x * this.y - this.w * this.z), 2f * (this.x * this.z + this.w * this.y));

            return new Matrix().initRotation(forward, up, right);
        }

        public Vector3 GetForward()
        {
            return new Vector3(0, 0, 1).rotate(this);
        }

        public Vector3 GetBack()
        {
            return new Vector3(0, 0, -1).rotate(this);
        }

        public Vector3 GetUp()
        {
            return new Vector3(0, 1, 0).rotate(this);
        }

        public Vector3 GetDown()
        {
            return new Vector3(0, -1, 0).rotate(this);
        }

        public Vector3 GetRight()
        {
            return new Vector3(1, 0, 0).rotate(this);
        }

        public Vector3 GetLeft()
        {
            return new Vector3(-1, 0, 0).rotate(this);
        }

        public bool equals(Quaternion r)
        {
            return x == r.x && y == r.y && z == r.z && w == r.w;
        }

        public Vector4 ToVector4()
        {
            return new Vector4(this.x, this.y, this.z, this.w);
        }

        public override string ToString() //If you want to print it as a string it shows like [1, 5, 8, 0]
        {
            return $"[{this.x}, {this.y}, {this.z}, {this.w}]";
        }
    }
}
