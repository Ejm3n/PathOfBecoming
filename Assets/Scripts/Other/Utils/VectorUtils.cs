using UnityEngine;

namespace VectorUtils
{
    public static class VectorUtils
    {
        public static Vector2 Turn(this Vector2 vector, float angleDeg)
        {
            /* 
             * 2d turn matrix:
             * cos(rad) -sin(rad)
             * sin(rad) cos(rad) 
             */
            float angleRad = Mathf.Deg2Rad * angleDeg;
            float sin = Mathf.Sin(angleRad);
            float cos = Mathf.Cos(angleRad);
            float x = vector.x * cos - vector.y * sin;
            float y = vector.x * sin + vector.y * cos;
            return new Vector2(x, y);
        }
    }
}