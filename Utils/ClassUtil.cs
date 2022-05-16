using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StuTools
{
    public static class ClassUtil 
    {
        public static T CreateItem<T>(string className, object[] args = null)
        {
            Type type = Type.GetType(className, true);
            return (T)Activator.CreateInstance(type, args);
        }
    }
}
