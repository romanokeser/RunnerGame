using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * moveForce;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(transform.forward * moveForce, ForceMode.Force);
    }
}
