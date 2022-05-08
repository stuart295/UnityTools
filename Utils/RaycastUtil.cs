using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A util for common raycast tasks
/// </summary>
public static class RaycastUtil 
{

    //Raycasts from the mouse position against a horizontal plane with the specified height
    public static Vector3 MousePlaneRaycast(float height=0f) {
        Plane worldPlane = new Plane(Vector3.up, new Vector3(0, height, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter;
        if (worldPlane.Raycast(ray, out enter)) {
            return ray.GetPoint(enter);
        }
        return Vector3.zero;
    }



}
