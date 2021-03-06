using System;
namespace csEngine.Core
{
    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public float length { get { return getLength(); } }

        public static Vector2 xAxis { get { return new Vector2(1, 0); } }
        public static Vector2 yAxis { get { return new Vector2(0, 1); } }

        public float this[int i] //Vector2[0] represents Vector2.x Vector2[1] is Vector2.y
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
                else
                {
                    throw new Exception();
                }
            }
        }

        public Vector2()//Vector without given x, y Values
        {
            this.x = zero().x;
            this.y = zero().y;
        }

        public Vector2(float x, float y) //Vector with given x, y Values
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 zero() //Vector with 0,0
        {
            return new Vector2(0, 0);
        }

        public Vector2(Vector2 other) //copies a other Vector
        {
            this.x = other.x;
            this.y = other.y;
        }

        private float getLength() //Calculates the length of a Vector
        {
            float squareLength = this.x * this.x + this.y * this.y;
            float length = (float)Math.Sqrt(squareLength);
            return length;
        }

        public void scale(float scaleFactor) //scales the Vector
        {
            this.x *= scaleFactor;
            this.y *= scaleFactor;
        }

        public void reverse() //reverses a Vector
        {
            this.x = -this.x;
            this.y = -this.y;
        }

        public bool unitize() //changes x, y of a vector that the length is 1
        {
            float length = this.getLength();
            if (length <= 0)
            {
                return false;
            }

            this.x /= length;
            this.y /= length;

            return true;
        }

        public void add(Vector2 other) //add a Vector2 to another one
        {
            this.x += other.x;
            this.y += other.y;
        }

        public static Vector2 addition(Vector2 a, Vector2 b) //adds two Vector2 togheter and returns a new Vector2
        {
            float newX = a.x + b.x;
            float newY = a.y + b.y;

            Vector2 newVector2 = new Vector2(newX, newY);

            return newVector2;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) //overrides the + operator to be able to do Vector2 + Vector2
        {
            return Vector2.addition(a, b);
        }

        public static Vector2 operator +(Vector2 a, float b) //adds a Number to a Vector
        {
            float newX = a.x + b;
            float newY = a.y + b;

            Vector2 newVector2 = new Vector2(newX, newY);

            return newVector2;
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)//overrides the * operator to be able to do Vector2 * Vector2
        {
            float x = a.x * b.x;
            float y = a.y * b.y;

            Vector2 vector2 = new Vector2(x, y);

            return vector2;
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)//overrides the / operator to be able to do Vector2 / Vector2
        {
            float x = a.x / b.x;
            float y = a.y / b.y;

            Vector2 vector2 = new Vector2(x, y);

            return vector2;
        }

        public static Vector2 operator /(Vector2 a, float b)//overrides the / operator to be able to do Vector2 / 3
        {
            float x = a.x / b;
            float y = a.y / b;

            Vector2 vector2 = new Vector2(x, y);

            return vector2;
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)//overrides the - operator to be able to do Vector2 - Vector2
        {
            float x = a.x - b.x;
            float y = a.y - b.y;

            Vector2 vector2 = new Vector2(x, y);

            return vector2;
        }

        public static Vector2 operator -(Vector2 a, float b) //subtract a Number to a Vector
        {
            float newX = a.x - b;
            float newY = a.y - b;

            Vector2 newVector2 = new Vector2(newX, newY);

            return newVector2;
        }

        public static Vector2 operator *(float a, Vector2 b) //overrides the * operator to be able to do 3 * Vector2
        {
            Vector2 vector2 = new Vector2(b);
            vector2.scale(a);
            return vector2;
        }

        public static Vector2 operator *(Vector2 b, float a) //overrides the * operator to be able to do 3 * Vector2
        {
            Vector2 vector2 = new Vector2(b);
            vector2.scale(a);
            return vector2;
        }

        public static Vector2 normalize(Vector2 other) //creates a new Vector with normalized x, y, z values
        {
            float factor = (float)Math.Sqrt((other.x * other.x) + (other.y * other.y));
            factor = 1f / factor;

            return new Vector2(other.x * factor, other.y * factor);
        }

        public Vector3 ToVector3(Vector2 vector2)
        {
            float x = vector2.x;
            float y = vector2.y;

            return new Vector3(x, y, 0);
        }

        public static Vector2 max(Vector2 a, Vector2 b)//gets the max for the collision detection
        {
            float x = MathsHelper.max(a.x, b.x);
            float y = MathsHelper.max(a.y, b.y);
            return new Vector2(x, y);
        }

        public static Vector2 min(Vector2 a, Vector2 b)//gets the min for the collision detection
        {
            float x = MathsHelper.min(a.x, b.x);
            float y = MathsHelper.min(a.y, b.y);
            return new Vector2(x, y);
        }

        public static float maxLength(Vector2 vector2)
        {
            return MathsHelper.max(vector2.x, vector2.y);
        }

        public static float minLength(Vector2 vector2)
        {
            return MathsHelper.min(vector2.x, vector2.y);
        }

        public static float dotProduct(Vector2 a) //returns a value of all x, y values multiplied 
        {
            return a.x + a.y;
        }

        public static float dotProduct(Vector2 a, Vector2 b) //returns a value of all x, y values multiplied 
        {
            return a.x * b.x + a.y * b.y;
        }

        public bool equals(Vector2 r)
        {
            return x == r.x && y == r.y;
        }

        public override string ToString() //If you want to print it as a string it shows like [1, 5]
        {
            return $"[{this.x}, {this.y}]";
        }
    }
}
