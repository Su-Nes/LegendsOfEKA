using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private EnemyHealth health;
    [SerializeField] private float attackCooldown = 2f;
    private float lastAttackTime;
    private NavMeshAgent navMeshAgent;
    private Animator animator;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health.IsDead())
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isMoving", false);
            return;
        }
        
        animator.SetBool("isMoving", navMeshAgent.velocity.magnitude > .5f);
        navMeshAgent.SetDestination(target.position);

        if (Vector3.Distance(transform.position, target.position) < 2.5f)
        {
            navMeshAgent.isStopped = true;
            if (Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
            }
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
    }

    private void Attack()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        
        animator.SetTrigger("attack");
        lastAttackTime = Time.time;
    }
}
