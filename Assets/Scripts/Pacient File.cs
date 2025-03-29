using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacientFile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject MinigameController;
    private Component minigameController;
    private BloodType type;
    
    void Start()
    {
        minigameController = MinigameController.GetComponent<SecondMinigameMaanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Pacient File: " + type);
    }

    public void SetType(BloodType type)
    {
        this.type = type;
    }
}
