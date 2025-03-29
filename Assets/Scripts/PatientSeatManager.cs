using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacientSeatManager : MonoBehaviour
{
    
    private PatientSeat[] _seats = { };
    [SerializeField] GameObject patientPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        _seats = this.GetComponentsInChildren<PatientSeat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public PatientSeat AddPatient () {
        foreach (var seat in _seats) {
            if (!seat.IsOccupied()) {
                seat.SetOccupied(true);
                Debug.Log("Patient added");
                Instantiate(patientPrefab, seat.transform);
                return seat;
            }
        }
        return null;
    }

    public GameObject RemovePatient()
    {
        foreach (var seat in _seats) {
            if (seat.IsOccupied()) {
                seat.SetOccupied(false);
                return seat.transform.GetChild(0).gameObject;
            }
        }
        return null;
    }
    
    public int GetOccupancy() {
        var count = 0;
        foreach (var seat in _seats) {
            if (seat.IsOccupied())
            {
                count++;
            }
        }
        return count;
    }
}
