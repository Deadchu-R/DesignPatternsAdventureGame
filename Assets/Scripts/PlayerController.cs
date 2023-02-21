using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class PlayerController : Notifier
{
    public bool isDead = false;
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Player Stats")] [SerializeField]
    private float health = 100f;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private Camera cam;
    private Vector3 rotate;
    [SerializeField] private float camRotationSenestiviy = 1f;


    private void Start()
    {
        GameManager.Instance.PlayerHealth += health;
    }

    void Update()
    {
        if (!isDead) Inputs();
    }

    #region Inputs&Movement

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

        if (Input.GetButton("Fire2"))
        {
            CameraMouseController();
        }
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

    private void CameraMouseController()
    {
        float mouseX = Input.GetAxis("Mouse Y");
        float mouseY = Input.GetAxis("Mouse X");

        rotate = new Vector3(mouseX * camRotationSenestiviy, mouseY * camRotationSenestiviy, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
             Enemy enemy =collision.gameObject.GetComponent<Enemy>();
             health -= enemy.Damage;
             GameManager.Instance.PlayerHealth -= enemy.Damage;
             NotifyObservers(NotifyActions.PlayerDamaged);
        }
        NotifyObservers(NotifyActions.PlayerDamaged);
        if (health <= 0)
        {
            NotifyObservers(NotifyActions.PlayerDead);
            isDead = true;
        }
    }

}
