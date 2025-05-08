using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startHealth = 100;
    [SerializeField] private float timeBetweenHits = 1f;
    [SerializeField] private Collider[] weaponColliders;
    [SerializeField] private float XPReward = 15f;
    private float lastHitTime;
    
    private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value < 0 ? 0 : value; if(currentHealth <= 0) {currentHealth = 0; Die(); } }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
    
    private void Start()
    {
        currentHealth = startHealth;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerWeapon") && Time.time - lastHitTime > timeBetweenHits) // remember this timing code
        {
            TakeDamage(5);
        }
    }

    public void EnableWeapons()
    {
        foreach(Collider col in weaponColliders)
            col.enabled = true;
    }

    public void DisableWeapons()
    {
        foreach(Collider col in weaponColliders)
            col.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead())
            return;
        
        GetComponent<Animator>().SetTrigger("hurt");
        lastHitTime = Time.time;
        CurrentHealth -= damage;
        print($"Current Health: {CurrentHealth}");
    }

    private void Die()
    {
        GetComponent<Animator>().SetBool("dead", true);
        PlayerXP.CallOnGetXP(XPReward);
        DisableWeapons();
    }
}
