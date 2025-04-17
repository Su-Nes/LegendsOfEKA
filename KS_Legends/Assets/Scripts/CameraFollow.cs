using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 5;
    
    private Vector3 offset;
    
    
    private void Start()
    {
        offset = transform.position - target.position;
    }
    
    private void Update()
    {
        Vector3 targetCameraPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, Time.deltaTime * smoothTime);
    }
}
