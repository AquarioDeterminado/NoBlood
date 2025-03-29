using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMinigameController : MonoBehaviour
{
    
    [SerializeField] private GameController gameController;
    
    private bool _started = false;
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
        _started = true;
    }
    
    public void End(bool win)
    {
        if (_started)
        {
            gameController.endMinigame1(win);
            _started = false;
        }
    }
}
