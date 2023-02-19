using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Very basic script that invokes listeners when another object collides with this gameobject.
/// </summary>
[RequireComponent(typeof(Collider))]
public class TriggerVolume : MonoBehaviour
{

    public UnityEvent<GameObject> onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        onTrigger?.Invoke(other.gameObject);
    }
}
