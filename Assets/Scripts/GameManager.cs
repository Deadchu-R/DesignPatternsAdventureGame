using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
 //   public Action<int> ScoreChanged;
    //public Action<int> HealthChanged;
    
    [SerializeField] private UnityEvent healthChangedEvent;
    [SerializeField] private UnityEvent scoreChangedEvent;
    public  static  GameManager Instance { get; private set; }
    public int Score = 0;
    public float PlayerHealth = 1f;
    [SerializeField] int winScore = 10;
    public string scoreText = "Score";
    public string healthText = "HP:";
    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    [SerializeField] private  TextMeshProUGUI healthTextMesh;
    
    private bool lost = false;
    private bool won = false;
    
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

private void Update()
{
    healthTextMesh.text = healthText + PlayerHealth;
    scoreTextMesh.text = scoreText + Score;
    if (Score == 10)
    {
        won = true;
    }
    if (lost == true)
    {
        
    }
}
}
