using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A simple interface for basic damage management.
/// </summary>
public interface IDamagable 
{
    public bool Dead => Health <= 0f; 
    public float Health { get; set; }
    public float MaxHealth { get; set; }

    public void Kill();

    public virtual void TakeDamage(float damage, Vector3 position)
    {
        Health = Mathf.Max(0, Health - damage);

        if (Health <= 0) Kill();
    }


}
