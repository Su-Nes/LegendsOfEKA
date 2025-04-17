using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControl : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float moveSpeed = 10f;
    private CharacterController characterController;
    private Animator animator;
    private Camera playerCamera;
    
    private Vector3 targetPosition, lookPosition;
    
    
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerCamera = Camera.main;
        
        targetPosition = transform.position;
    }


    private void Update()
    {
        if (!PlayerHealth.isAlive)
            return;
        
        if (Input.GetMouseButton(1))
        {
            targetPosition = GetTargetPosition();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LookAtFlat(GetTargetPosition());
            animator.SetTrigger("chop");
        }
        
        float distToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distToTarget > 0.1f)
        {
            Vector3 targetDirection = (targetPosition - transform.position).normalized;
            characterController.Move(targetDirection * (moveSpeed * Time.deltaTime));
            
            animator.SetBool("running", true);
            
            LookAtFlat(targetPosition);
        }
        else
        {
            animator.SetBool("running", false);
        }
    }

    private void LookAtFlat(Vector3 lookTarget)
    {
        lookPosition = lookTarget;
        lookPosition.y = transform.position.y;
        transform.LookAt(lookPosition);
    }

    private Vector3 GetTargetPosition()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 500f, layerMask, QueryTriggerInteraction.Collide))
        {
            return hit.point;
        }

        return transform.position;
    }
}
