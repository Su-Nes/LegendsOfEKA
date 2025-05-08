using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private Collider[] weaponColliders;

    
    private void Awake()
    {
        AttackEnd();
    }
    
    public void AttackStart()
    {
        foreach(Collider col in weaponColliders)
            col.enabled = true;
    }

    public void AttackEnd()
    {
        foreach(Collider col in weaponColliders)
            col.enabled = false;
    }
}
