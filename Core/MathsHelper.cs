using System;
using csEngine.Physics;
namespace csEngine.Core
{
    public class MathsHelper
    {
        public const float E = 2.7182818284590452f;
        public const float Log10E = 0.4342945f;
        public const float Log2E = 1.442695f;
        public const float Pi = 3.14159274f;
        public const float PiOver2 = 1.57079637f;
        public const float PiOver4 = 0.7853982f;
        public const float TwoPi = 6.28318548f;
        public const float Tau = TwoPi; //The same as TwoPi

        public static float catmullRom(float value1, float value2, float value3, float value4, float amount)
        {
            double amountSquared = amount * amount;
            double amountCubed = amountSquared * amount;
            return (float)(0.5 * (2.0 * value2 +
                (value3 - value1) * amount +
                (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }

        public static float hermite(float value1, float tangent1, float value2, float tangent2, float amount)
        {
            double v1 = value1, v2 = value2, t1 = tangent1, t2 = tangent2, s = amount, result;
            double sCubed = s * s * s;
            double sSquared = s * s;

            if (amount == 0f)
                result = value1;
            else if (amount == 1f)
                result = value2;
            else
                result = (2 * v1 - 2 * v2 + t2 + t1) * sCubed +
                    (3 * v2 - 3 * v1 - 2 * t1 - t2) * sSquared +
                    t1 * s +
                    v1;
            return (float)result;
        }

        public static float clamp(float value, float min, float max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;

            return value;
        }

        public static float lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        public static float lerpPrecise(float value1, float value2, float amount)
        {
            return ((1 - amount) * value1) + (value2 * amount);
        }

        public static float max(float value1, float value2)
        {
            return value1 > value2 ? value1 : value2;
        }

        public static float min(float value1, float value2)
        {
            return value1 < value2 ? value1 : value2;
        }

        public static float smoothStep(float value1, float value2, float amount) // It is expected that 0 < amount < 1 if amount < 0, return value1 if amount > 1, return value2
        {
            float result = MathsHelper.clamp(amount, 0f, 1f);
            result = MathsHelper.hermite(value1, 0f, value2, 0f, result);

            return result;
        }

        public static float toDegrees(float radians)
        {
            return (float)(radians * 57.295779513082320876798154814105);
        }

        public static float toRadians(float degrees)
        {
            return (float)(degrees * 0.017453292519943295769236907684886);
        }

        public static float wrapAngle(float angle)
        {
            if ((angle > -Pi) && (angle <= Pi))
                return angle;
            angle %= TwoPi;
            if (angle <= -Pi)
                return angle + TwoPi;
            if (angle > Pi)
                return angle - TwoPi;
            return angle;
        }

        public static bool osPowerOfTwo(int value)
        {
            return (value > 0) && ((value & (value - 1)) == 0);
        }

        public static float sqDistanceBetweenPointboundingBox(Vector3 point, boundingBox aabb)
        {
            float sqDist = new float();
            for (int i = 0; i < 3; i++)
            {
                float v = point[i];
                if (v < aabb.getMin()[i]) sqDist += (aabb.getMin()[i] - v) * (aabb.getMin()[i] - v);
                if (v > aabb.getMax()[i]) sqDist += (v - aabb.getMax()[i] * (v - aabb.getMax()[i]));
            }
            return sqDist;
        }
    }
}
