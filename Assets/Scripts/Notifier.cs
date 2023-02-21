using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    [SerializeField] private  List<IObserver> observers = new List<IObserver>();


    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    protected void NotifyObservers(NotifyActions action)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(action);
        }
    }
}
