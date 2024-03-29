using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using Random = UnityEngine.Random;

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

        public static GameObject MouseRaycast(out Vector3 hitPoint)
        {
            return MouseRaycast(~(new LayerMask()), Mathf.Infinity, out hitPoint);
        }

        public static GameObject MouseRaycast()
        {
            Vector3 hitPoint;
            return MouseRaycast(~(new LayerMask()), Mathf.Infinity, out hitPoint);
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


        /// <summary>
        /// Raycasts against UI elements.
        /// </summary>
        /// <param name="eventSystem"></param>
        /// <returns>A list of UI gameobjects hit by the raycast</returns>
        public static List<GameObject> UIRaycast(EventSystem eventSystem)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(eventSystem);
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            eventDataCurrentPosition.position = mousePos;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            return results.Select(res => res.gameObject).ToList();
        }


        /// <summary>
        /// Raycasts against UI elements.
        /// </summary>
        /// <returns>A list of UI gameobjects hit by the raycast</returns>
        public static List<GameObject> UIRaycast()
        {
            return UIRaycast(EventSystem.current);
        }


        /// <summary>
        /// Returns a random position within a ring defined by an inner and outer radius.
        /// </summary>
        public static Vector3 RandomPosInRing(float innerRadius, float outerRadius)
        {
            Vector2 dir = Random.insideUnitCircle.normalized;
            float radius = Random.Range(innerRadius, outerRadius);

            return new Vector3(dir.x, 0, dir.y) * radius;

        }

        /// <summary>
        /// Checks whether the distance between two points is closer than a given threshold.
        /// </summary>
        public static bool IsCloserThan(Vector3 pointA, Vector3 pointB, float distance)
        {
            return (pointB - pointA).sqrMagnitude < distance * distance;
        }

        /// <summary>
        /// Checks whether the distance between two points is greater than a given threshold.
        /// </summary>
        public static bool IsFurtherThan(Vector3 pointA, Vector3 pointB, float distance)
        {
            return (pointB - pointA).sqrMagnitude > distance * distance;
        }
    }
}