using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StuTools
{
    public static class VectorUtil
    {
        public static Vector3 UpdateElement(Vector3 vector, int element, float newVal)
        {
            Vector3 result = Vector3.zero;
            for (int i = 0; i < 3; i++)
            {
                result[i] = (i == element) ? newVal : vector[i];
            }
            return result;
        }


        public static Quaternion UpdateEulerElement(Quaternion rot, int element, float newVal)
        {
            Vector3 eulerVec = rot.eulerAngles;
            return Quaternion.Euler(UpdateElement(eulerVec, element, newVal));
        }

        /// <summary>
        /// Converts a vector3 to a vector2 while aligning v3.z with v2.y
        /// </summary>
        /// <param name="vec3"></param>
        /// <returns>A vector3 with the correct orientation</returns>
        public static Vector2 Vec3ToVec2(Vector3 vec3)
        {
            return new Vector2(vec3.x, vec3.z);
        }

        /// <summary>
        /// Converts a vector2 to a vector3 while aligning v2.y with v3.z
        /// </summary>
        /// <param name="vec2"></param>
        /// <returns>A vector3 with the correct orientation</returns>
        public static Vector3 Vec2ToVec3(Vector2 vec2)
        {
            return new Vector3(vec2.x, 0, vec2.y);
        }


        public static bool AproxEquals(Vector3 v1, Vector3 v2, float threshold = 0.1f)
        {
            return Vector3.Distance(v1, v2) <= threshold;
        }

        public static Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Vector3 degrees)
        {
            Vector3 dir = point - pivot;
            dir = Quaternion.Euler(degrees) * dir;
            point = dir + pivot;
            return point;
        }

        public static Vector2Int RotateAroundPivot(Vector2Int point, Vector2Int pivot, float degrees)
        {
            Vector3 rotated = RotateAroundPivot(new Vector3(point.x, 0f, point.y), new Vector3(pivot.x, 0f, pivot.y), new Vector3(0f, degrees, 0f));
            return new Vector2Int((int)rotated.x, (int)rotated.z);

        }


        /// <summary>
        /// Returns the coordinates of neighbouring cells in a grid.
        /// </summary>
        /// <param name="grid">A 2D grid array of <typeparamref name="T"/> representing the grid</param>
        /// <param name="pos">The position in the grid to find neighbours for.</param>
        /// <returns>An IEnumerable of Vector2Ints</returns>
        public static IEnumerable<Vector2Int> GetNeighbours<T>(T[,] grid, Vector2Int pos)
        {
            for (int i = 0; i < 4; i++)
            {

                Vector2Int offset = new Vector2Int((int)Mathf.Sin(i * (Mathf.PI / 2f)), (int)Mathf.Cos(i * (Mathf.PI / 2f)));

                int x = pos.x + offset.x;
                int y = pos.y + offset.y;

                if (x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1)) continue;

                yield return new Vector2Int(x, y);
            }

        }


    }
}
