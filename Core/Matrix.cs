﻿using System;
namespace csEngine.Core
{
    public class Matrix
    {
        private float[][] m;

        public Matrix()
        {
            m = new float[4][];
        }

        public Matrix initIdentity()
        {
            m[0][0] = 1; m[0][1] = 0; m[0][2] = 0; m[0][3] = 0;
            m[1][0] = 0; m[1][1] = 1; m[1][2] = 0; m[1][3] = 0;
            m[2][0] = 0; m[2][1] = 0; m[2][2] = 1; m[2][3] = 0;
            m[3][0] = 0; m[3][1] = 0; m[3][2] = 0; m[3][3] = 1;

            return this;
        }

        public Matrix initTranslation(float x, float y, float z)
        {
            m[0][0] = 1; m[0][1] = 0; m[0][2] = 0; m[0][3] = x;
            m[1][0] = 0; m[1][1] = 1; m[1][2] = 0; m[1][3] = y;
            m[2][0] = 0; m[2][1] = 0; m[2][2] = 1; m[2][3] = z;
            m[3][0] = 0; m[3][1] = 0; m[3][2] = 0; m[3][3] = 1;

            return this;
        }

        public Matrix initRotation(float x, float y, float z)
        {
            Matrix rx = new Matrix();
            Matrix ry = new Matrix();
            Matrix rz = new Matrix();

            x = (float)MathsHelper.toRadians(x);
            y = (float)MathsHelper.toRadians(y);
            z = (float)MathsHelper.toRadians(z);

            rz.m[0][0] = (float)Math.Cos(z); rz.m[0][1] = -(float)Math.Sin(z); rz.m[0][2] = 0; rz.m[0][3] = 0;
            rz.m[1][0] = (float)Math.Sin(z); rz.m[1][1] = (float)Math.Cos(z); rz.m[1][2] = 0; rz.m[1][3] = 0;
            rz.m[2][0] = 0; rz.m[2][1] = 0; rz.m[2][2] = 1; rz.m[2][3] = 0;
            rz.m[3][0] = 0; rz.m[3][1] = 0; rz.m[3][2] = 0; rz.m[3][3] = 1;

            rx.m[0][0] = 1; rx.m[0][1] = 0; rx.m[0][2] = 0; rx.m[0][3] = 0;
            rx.m[1][0] = 0; rx.m[1][1] = (float)Math.Cos(x); rx.m[1][2] = -(float)Math.Sin(x); rx.m[1][3] = 0;
            rx.m[2][0] = 0; rx.m[2][1] = (float)Math.Sin(x); rx.m[2][2] = (float)Math.Cos(x); rx.m[2][3] = 0;
            rx.m[3][0] = 0; rx.m[3][1] = 0; rx.m[3][2] = 0; rx.m[3][3] = 1;

            ry.m[0][0] = (float)Math.Cos(y); ry.m[0][1] = 0; ry.m[0][2] = -(float)Math.Sin(y); ry.m[0][3] = 0;
            ry.m[1][0] = 0; ry.m[1][1] = 1; ry.m[1][2] = 0; ry.m[1][3] = 0;
            ry.m[2][0] = (float)Math.Sin(y); ry.m[2][1] = 0; ry.m[2][2] = (float)Math.Cos(y); ry.m[2][3] = 0;
            ry.m[3][0] = 0; ry.m[3][1] = 0; ry.m[3][2] = 0; ry.m[3][3] = 1;

            m = rz.mul(ry.mul(rx)).getM();

            return this;
        }

        public Matrix initScale(float x, float y, float z)
        {
            m[0][0] = x; m[0][1] = 0; m[0][2] = 0; m[0][3] = 0;
            m[1][0] = 0; m[1][1] = y; m[1][2] = 0; m[1][3] = 0;
            m[2][0] = 0; m[2][1] = 0; m[2][2] = z; m[2][3] = 0;
            m[3][0] = 0; m[3][1] = 0; m[3][2] = 0; m[3][3] = 1;

            return this;
        }

        public Matrix initPerspective(float fov, float aspectRatio, float zNear, float zFar)
        {
            float tanHalfFOV = (float)Math.Tan(fov / 2);
            float zRange = zNear - zFar;

            m[0][0] = 1.0f / (tanHalfFOV * aspectRatio); m[0][1] = 0; m[0][2] = 0; m[0][3] = 0;
            m[1][0] = 0; m[1][1] = 1.0f / tanHalfFOV; m[1][2] = 0; m[1][3] = 0;
            m[2][0] = 0; m[2][1] = 0; m[2][2] = (-zNear - zFar) / zRange; m[2][3] = 2 * zFar * zNear / zRange;
            m[3][0] = 0; m[3][1] = 0; m[3][2] = 1; m[3][3] = 0;


            return this;
        }

        public Matrix initOrthographic(float left, float right, float bottom, float top, float near, float far)
        {
            float width = right - left;
            float height = top - bottom;
            float depth = far - near;

            m[0][0] = 2 / width; m[0][1] = 0; m[0][2] = 0; m[0][3] = -(right + left) / width;
            m[1][0] = 0; m[1][1] = 2 / height; m[1][2] = 0; m[1][3] = -(top + bottom) / height;
            m[2][0] = 0; m[2][1] = 0; m[2][2] = -2 / depth; m[2][3] = -(far + near) / depth;
            m[3][0] = 0; m[3][1] = 0; m[3][2] = 0; m[3][3] = 1;

            return this;
        }

        public Matrix initRotation(Vector3 forward, Vector3 up)
        {
            Vector3 f = Vector3.normalize(forward);

            Vector3 r = Vector3.normalize(up);
            r = Vector3.crossProduct(r, f);

            Vector3 u = Vector3.crossProduct(f, r);

            return initRotation(f, u, r);
        }

        public Matrix initRotation(Vector3 forward, Vector3 up, Vector3 right)
        {
            Vector3 f = forward;
            Vector3 r = right;
            Vector3 u = up;

            m[0][0] = r.x; m[0][1] = r.y; m[0][2] = r.z; m[0][3] = 0;
            m[1][0] = u.x; m[1][1] = u.y; m[1][2] = u.z; m[1][3] = 0;
            m[2][0] = f.x; m[2][1] = f.y; m[2][2] = f.z; m[2][3] = 0;
            m[3][0] = 0; m[3][1] = 0; m[3][2] = 0; m[3][3] = 1;

            return this;
        }

        public Vector3 transform(Vector3 r)
        {
            return new Vector3(m[0][0] * r.x + m[0][1] * r.y + m[0][2] * r.z + m[0][3],
                               m[1][0] * r.x + m[1][1] * r.y + m[1][2] * r.z + m[1][3],
                               m[2][0] * r.x + m[2][1] * r.y + m[2][2] * r.z + m[2][3]);
        }

        public Matrix mul(Matrix r)
        {
            Matrix res = new Matrix();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res.set(i, j, m[i][0] * r.get(0, j) +
                            m[i][1] * r.get(1, j) +
                            m[i][2] * r.get(2, j) +
                            m[i][3] * r.get(3, j));
                }
            }

            return res;
        }

        public float[][] getM()
        {
            float[][] res = new float[4][];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    res[i][j] = m[i][j];

            return res;
        }

        public float get(int x, int y)
        {
            return m[x][y];
        }

        public void setM(float[][] m)
        {
            this.m = m;
        }

        public void set(int x, int y, float value)
        {
            m[x][y] = value;
        }
    }
}