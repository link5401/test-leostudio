using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    // Update is called once per frame
    private void Awake()
    {
        _offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        Vector3 targetPosiion = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosiion, ref _currentVelocity, smoothTime);
    }
}