using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float FollowSpeed;
    public float length;
    public Transform target;

    private Vector3 defaultPosition;

    public bool hasTarget { get{return target != null;} }

    
    private void Start() 
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update()
    {
        if (hasTarget)
        {
            // Kalkulasi posisi fokus target
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + ( targetToCameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
        }
    }
    public void FollowTarget(Transform targetTransform, float targetLength) 
    {
        StopAllCoroutines();
        target = targetTransform;
        length = targetLength;
    }
    public void GoBackToDefault() 
    {
        target = null;
        StopAllCoroutines();
        // gerakan ke posisi default
        StartCoroutine(MovePosition(defaultPosition, 5));
    }
    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while(timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));
            // memindahkan posisi kamera bertahap

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = target;
    }
}
