using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StuTools
{
    public class TransformUtil 
    {
        
        public static void DestroyChildren(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }


    }

}