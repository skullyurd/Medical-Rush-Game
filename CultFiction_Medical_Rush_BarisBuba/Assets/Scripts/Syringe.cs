using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    [SerializeField] public int medNumberCarried;
    [SerializeField] private Renderer MedColour;

    public void SyringeChange()
    {
        switch (medNumberCarried)
        {
            case 1: //Green
                MedColour.materials[2].color = Color.green;
                break;

            case 2: // Red
                MedColour.materials[2].color = Color.red;
                break;

            case 3: // Blue
                MedColour.materials[2].color = Color.blue;
                break;

            case 0: // white
                MedColour.materials[2].color = Color.white;
                break;
        }

    }

}
