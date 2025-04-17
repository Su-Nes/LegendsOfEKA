using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent navMeshAgent;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GetComponent<Animator>().SetBool("isMoving", true);
    }

    private void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
