using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSeat : MonoBehaviour
{
    // Start is called before the first frame update
    
    private bool _occupied = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool IsOccupied() {
        return _occupied;
    }
    
    public void SetOccupied(bool occupied) {
        _occupied = occupied;
    }
}
