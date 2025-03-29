using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] float roundTime = 90;
    private int _roundTimeCounter;
    
    [SerializeField] GameObject pointCounter;
    private int _points = 0;
    
    [SerializeField] GameObject waitingRoom;
    private PacientSeatManager SeatManager;
    [SerializeField] private int maxTimeBetewenPatient = 2;
    private float timeToNextPatient = 0.0f;
    
    [SerializeField] GameObject Minigame1Controller;
    [SerializeField] Line patientLine;
    
    [SerializeField] GameObject Minigame2Controller;
    private SecondMinigameMaanger _minigame2Controller;
    
    [SerializeField] private GameObject cameraPlayer1;
    [SerializeField] private GameObject cameraPlayer2;
    [SerializeField] private GameObject cameraMinigame1;
    [SerializeField] private GameObject cameraMinigame2;
    
    // Start is called before the first frame update
    void Start()
    {
        SeatManager = waitingRoom.GetComponent<PacientSeatManager>();
        
        _minigame2Controller = Minigame2Controller.GetComponent<SecondMinigameMaanger>();
    }

    // Update is called once per frame
    void Update()
    {
        roundTime -= Time.deltaTime;
        timeToNextPatient -= Time.deltaTime;

        Random random = new Random();
        
        if (roundTime <= 0.0f)
        {
            timerEnded();
        } 
        else if (timeToNextPatient <= 0.0f)
        {
            timeToNextPatient = (float) random.Next(0, maxTimeBetewenPatient * 100) / 100;
            SeatManager.AddPatient();
        }
    }
    
    void timerEnded()
    {
        SceneManager.LoadScene("MainPage");
    }
    
    public void AddPoints(int points = 5)
    {
        _points += points;
    }

    public void AddTimePenalty(int time = 5)
    {
        roundTime -= time;
    }

    public void StartMinigame1()
    {
        cameraMinigame1.SetActive(true);
        cameraPlayer1.SetActive(false);
    }
    
    public void endMinigame1(bool win)
    {
        if (win)
        {
            AddPoints();
            patientLine.OnMinigame1Win();
        }
        else AddTimePenalty();
        
        cameraMinigame1.SetActive(false);
        cameraPlayer1.SetActive(true);
    }
    
    public void StartMinigame2()
    {
        _minigame2Controller.StartMinigame();
        
        cameraMinigame2.SetActive(true);
        cameraPlayer2.SetActive(false);
    }
    
    public void endMinigame2(bool win)
    {
        if (win) AddPoints();
        else AddTimePenalty();
        
        cameraMinigame2.SetActive(false);
        cameraPlayer2.SetActive(true);
    }

  
    
    
}

