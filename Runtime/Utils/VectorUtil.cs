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


    }
}
