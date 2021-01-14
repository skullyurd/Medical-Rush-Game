using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private int medNumberContained;
    [SerializeField] private Syringe syringeScript;
    [SerializeField] private Vector3[] medPosition;

    public void TakeMeds()
    {
        switch (medNumberContained)
        {
            case 1: // Green
                syringeScript.medNumberCarried = medNumberContained;
                syringeScript.SyringeChange();
                this.transform.position = medPosition[Random.Range(1, 6)];
                break;

            case 2: // Red
                syringeScript.medNumberCarried = medNumberContained;
                syringeScript.SyringeChange();
                this.transform.position = medPosition[Random.Range(1, 6)];
                break;

            case 3: //Blue
                syringeScript.medNumberCarried = medNumberContained;
                syringeScript.SyringeChange();
                this.transform.position = medPosition[Random.Range(1, 6)];
                break;
        }
    }
}
