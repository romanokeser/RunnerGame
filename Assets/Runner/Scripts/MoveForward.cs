using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _moveForce = 10f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(0, 0, 1) * _moveForce * Time.fixedDeltaTime;
        _rb.velocity = transform.forward * _moveForce;
        _rb.MovePosition(transform.position + moveDirection);
    }
    
}
