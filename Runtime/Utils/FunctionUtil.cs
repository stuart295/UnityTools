using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StuTools
{
    public static class FunctionUtil
    {

        public static void Delayed(MonoBehaviour context, Action func, float delay)
        {
            context.StartCoroutine(DelayedRoutine(func, delay));
        }

        private static IEnumerator DelayedRoutine(Action onComplete, float delay)
        {
            yield return new WaitForSeconds(delay);
            onComplete();
        }

    }
}