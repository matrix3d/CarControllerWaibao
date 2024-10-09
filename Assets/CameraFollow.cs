using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    public Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        HandleTranslation(false);
        HandleRotation(false);
    }
   
    private void HandleTranslation(bool isfly)
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition,isfly?1:( translateSpeed * Time.deltaTime));
    }
    private void HandleRotation(bool isfly)
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, isfly?1:( rotationSpeed * Time.deltaTime));
    }

    public void fly()
    {
        HandleTranslation(true);
        HandleRotation(true);
    }
}
