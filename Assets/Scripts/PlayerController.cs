using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public bool isDead = false;
    [SerializeField] private Rigidbody _rigidbody;
    [Header("Player Stats")]
    [SerializeField] private float health = 100f;
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxSpeed = 2f;

    private void Start()
    {
        GameManager.Instance.PlayerHealth += health;
    }

    void Update()
    {
        Inputs();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 velocity = _rigidbody.velocity;
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        _rigidbody.AddForce(direction * speed, ForceMode.Impulse);
            if (velocity.magnitude > maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
            }
    
    }


private void Inputs()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Move();
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }


        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
       
    }

    private void Jump()
    {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10f;
            if (health <= 0)
            {
                isDead = true;
            }
        }
    }
}