using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Aim : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    [SerializeField] private Transform playerTransform;
    
    private Vector3 targetPosition;
    
    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material.color = Color.red;
    }

    private void Update()
    {
        // вращает луч, относительно нуля на системе координат, НЕ ПРАВИЛЬНО
        
        //targetPosition = (playerTransform.position + playerTransform.forward) * 50f; 
        
        targetPosition = playerTransform.position + playerTransform.up * Mathf.Cos(playerTransform.rotation.eulerAngles.z * Mathf.Deg2Rad) 
                                                  + playerTransform.up * Mathf.Sin(playerTransform.rotation.eulerAngles.z * Mathf.Deg2Rad) * 50f;
        
        lineRenderer.SetPosition(0, playerTransform.position); 
        lineRenderer.SetPosition(1, targetPosition);
    }
}
