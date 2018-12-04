using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAround : MonoBehaviour {
    public float moveFrequency = 0.1f;
    public float moveForceMultiplier = 1f;
    private Rigidbody _rb;
    private Vector3 _initPos;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _initPos = transform.position;
    }

    private void Start()
    {
        _rb.AddForce(Random.insideUnitCircle * moveForceMultiplier, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (Random.value < moveFrequency)
        {
            _rb.AddForce(transform.InverseTransformVector(_initPos) * moveForceMultiplier, ForceMode.Impulse);
        }
    }

}
