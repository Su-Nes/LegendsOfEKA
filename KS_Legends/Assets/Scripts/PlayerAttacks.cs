using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private Collider weaponCollider;

    
    private void Awake()
    {
        weaponCollider.enabled = false;
    }
    
    public void AttackStart()
    {
        weaponCollider.enabled = true;    
    }

    public void AttackEnd()
    {
        weaponCollider.enabled = false;
    }
}
