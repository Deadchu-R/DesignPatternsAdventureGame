using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float health = 100f;
    public float Damage = 10f;
    [SerializeField] private Vector3 target;
        bool forward = true;
        private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    private void Move()
    {
        
        if (forward)
        {
         transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
         if (transform.position == target)
         {
             forward = false;
         }
        }
        else
        {
                transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);
                if (transform.position == _startPosition)
                {
                    forward = true;
                }
        }

    }
}
