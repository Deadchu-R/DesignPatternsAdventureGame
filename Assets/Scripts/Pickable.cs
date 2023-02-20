using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] int scoreWorth = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        Debug.Log("hello you picked up a pickable");
            GameManager.Instance.Score += scoreWorth;
            Destroy(gameObject);
        }
    }
}
