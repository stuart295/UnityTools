using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuTools
{

    /// <summary>
    /// A util for common raycast tasks
    /// </summary>
    public static class RaycastUtil
    {

        //Raycasts from the mouse position against a horizontal plane with the specified height
        public static Vector3 MousePlaneRaycast(float height = 0f)
        {
            Plane worldPlane = new Plane(Vector3.up, new Vector3(0, height, 0));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter;
            if (worldPlane.Raycast(ray, out enter))
            {
                return ray.GetPoint(enter);
            }
            return Vector3.zero;
        }

        public static GameObject MouseRaycast(int layerMask, float maxDistance)
        {
            Vector3 hitPoint;
            return MouseRaycast(layerMask, maxDistance, out hitPoint);
        }

        public static GameObject MouseRaycast(int layerMask, float maxDistance, out Vector3 hitPoint)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
            {
                hitPoint = hit.point;
                return hit.collider.gameObject;
            }

            hitPoint = Vector3.zero;
            return null;
        }
    }
}