using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGravityOnHit : MonoBehaviour {
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rb.useGravity = true;
    }
}
