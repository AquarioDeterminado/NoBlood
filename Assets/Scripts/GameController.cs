using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float roundTime = 90;
    private int _roundTimeCounter;
    
    [SerializeField] GameObject PointCounter;
    private int _points = 0;
    
    private GameObject[] _pacients;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundTime -= Time.deltaTime;

        if (roundTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        Application.LoadLevel("MainPage");
    }
    
    public void AddPoints(int points)
    {
        _points += points;
        
    }
}

