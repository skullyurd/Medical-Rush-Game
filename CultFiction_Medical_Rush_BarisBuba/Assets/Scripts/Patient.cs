using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    [SerializeField] private int medNumberNeeded;
    [SerializeField] private int HealthTimer;
    [SerializeField] private PlayerStat player;
    [SerializeField] private Syringe syringeScript;
    [SerializeField] private Text RoomText;

    private void Start()
    {
        medNumberNeeded = -5;
        StartCoroutine(StartCountDown());
        RoomText.text = "The patient is in need of meds soon";
    }

    private void requestingMed()
    {
        medNumberNeeded = Random.Range(1, 4);

        switch (medNumberNeeded)
        {
            case 1: //Green
                RoomText.text = "Patient needs some green stuff";
                break;

            case 2: // Red
                RoomText.text = "Patient needs some red stuff";
                break;

            case 3: // Blue
                RoomText.text = "Patient needs some blue stuff";
                break;
        }

    }

    public void checkMeds()
    {
        if (medNumberNeeded == syringeScript.medNumberCarried)
        {
            Debug.Log("Right meds");
            medNumberNeeded = -5; // No medicine has this number so no medicine can be used to the patient unless the script requests a new valid number
            player.gainPoints(HealthTimer);
            StopAllCoroutines();
            RoomText.text = "The patient is healthy";
            medNumberNeeded = -5;
            StartCoroutine(StartCountDown());
            syringeScript.medNumberCarried = 0;
            syringeScript.SyringeChange();
            return;

        }
        else
        {
            Debug.Log("Wrong meds");
            player.losePoints(HealthTimer);
            StopAllCoroutines();
            player.loseLife();
            medNumberNeeded = -5;
            StartCoroutine(StartCountDown());
            RoomText.text = "The patient feels unwell";
            syringeScript.medNumberCarried = 0;
            syringeScript.SyringeChange();
        }

    }

    private IEnumerator StartCountDown(int PatientTimer = 60)
    {
        yield return new WaitForSeconds(Random.Range(8, 15));
        requestingMed();
        HealthTimer = PatientTimer;
        while (HealthTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            HealthTimer--;
            if(HealthTimer < 1)
            {
                player.loseLife();
            }
        }
    }
}
