using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Notifier
{
    public int ScoreWorth = 1;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Score += ScoreWorth;
            NotifyObservers(NotifyActions.PickablePickedUp);
            Destroy(gameObject);
        }
    }
}
