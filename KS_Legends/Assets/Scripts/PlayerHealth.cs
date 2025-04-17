using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startHealth = 100;
    [SerializeField] private float timeBetweenHits = 1f;
    private float lastHitTime;
    
    private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value < 0 ? 0 : value; if(currentHealth <= 0) {currentHealth = 0; Die(); } }
    }
    
    public static bool isAlive = true;

    private void Start()
    {
        currentHealth = startHealth;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyWeapon") && Time.time - lastHitTime > timeBetweenHits) // remember this timing code
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive)
            return;
        
        GetComponent<Animator>().SetTrigger("hurt");
        lastHitTime = Time.time;
        CurrentHealth -= damage;
        print($"Current Health: {CurrentHealth}");
    }

    private void Die()
    {
        GetComponent<Animator>().SetBool("dead", true);
        isAlive = false;
    }
}
