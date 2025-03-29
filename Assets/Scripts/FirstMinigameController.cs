using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMinigameController : MonoBehaviour
{
    
    [SerializeField] private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMinigame()
    {
        
    }
    
    public void End(bool win)
    {
        gameController.endMinigame1(win);
    }
}
