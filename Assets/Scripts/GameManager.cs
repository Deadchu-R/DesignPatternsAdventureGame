using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour, IObserver
{
    
    public  static  GameManager Instance { get; private set; }
    public int Score = 0;
    public float PlayerHealth = 1f;
    [SerializeField] int winScore = 10;
    public string scoreText = "Score";
    public string healthText = "HP:";
    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    [SerializeField] private  TextMeshProUGUI healthTextMesh;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private List<Notifier> notifiers;
    public bool Lost = false;
    private bool won = false;
   
    

    private void OnEnable()
    {
        foreach (Notifier notifier in notifiers)
        {
            notifier.AddObserver(this);
        }
       
    }

    private void OnDisable()
    {
        foreach (Notifier notifier in notifiers)
        {
            notifier.RemoveObserver(this);
        }
    }

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

public void Retry()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
}


private void Update()
{
  

    if (Score == 10)
    {
        won = true;
        uiCanvas.SetActive(false);
        winCanvas.SetActive(true);
    }
    if (Lost == true)
    {
        uiCanvas.SetActive(false);
        loseCanvas.SetActive(true);
    }
}

public void OnNotify(NotifyActions action)
{
 
    if (action == NotifyActions.PickablePickedUp)
    {
        scoreTextMesh.text = scoreText + Score;
    }
    else if (action == NotifyActions.PlayerDamaged)
    {
        healthTextMesh.text = healthText + PlayerHealth;
    }
    else if(action == NotifyActions.PlayerDead)
    {
        Lost = true;
    }
}

}
