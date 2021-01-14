using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosHairInteraction : MonoBehaviour
{
    [SerializeField] private string selectableTagDoor = "Door";
    [SerializeField] private string selectableTagClosedDoor = "ClosedDoor";
    [SerializeField] private string selectableTagPatient = "Patient";
    [SerializeField] private string selectableMedicine = "Medicine";
    [SerializeField] private string selectableDragObject = "Drag";
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Transform player;
    [SerializeField] private Syringe syringeScript;
    [SerializeField] private AudioSource thisAudioSource;
    [SerializeField] private AudioClip LockedSound;

    private Transform _selection;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {

        if (_selection != null)
        {
            crosshair.SetActive(false);
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            float dist = Vector3.Distance(player.position, selection.position);
            if (dist < 2.5)
            {
                if (selection.CompareTag(selectableTagDoor)) // INTERACTION WITH OPEN DOOR
                {
                    var selectableDoor = selection.transform;
                    if (selectableDoor != null)
                    {
                        crosshair.SetActive(true);
                    }
                    _selection = selection;
                }

                if (selection.CompareTag(selectableTagClosedDoor)) //  INTERACTION WITH CLOSED DOOR
                {
                    var selectableClosedDoor = selection.transform;
                    if (selectableClosedDoor != null)
                    {
                        crosshair.SetActive(true);
                        if(Input.GetMouseButtonUp(0))
                        {
                            thisAudioSource.clip = LockedSound;
                            thisAudioSource.Play();
                        }
                    }
                    _selection = selection;
                }

                if (selection.CompareTag(selectableTagPatient)) //  INTERACTION WITH PATIENT
                {
                    var selectablePatient = selection.transform;
                    var selectablePatientScript = selection.GetComponent<Patient>();
                    if (selectablePatient != null)
                    {
                        crosshair.SetActive(true);
                        if(Input.GetMouseButtonUp(0))
                        {
                            selectablePatientScript.checkMeds();
                        }
                    }
                    _selection = selection;
                }

                if (selection.CompareTag(selectableMedicine)) //  INTERACTION WITH MEDICINE
                {
                    var selectableMedicine = selection.transform;
                    var selectedMedicineScript = selection.GetComponent<Medicine>();
                    if (selectableMedicine != null)
                    {
                        crosshair.SetActive(true);
                        if (Input.GetMouseButtonUp(0))
                        {
                            selectedMedicineScript.TakeMeds();
                        }
                    }
                    _selection = selection;
                }

                if (selection.CompareTag(selectableDragObject)) //  INTERACTION WITH OBJECT
                {
                    var selectabledrag = selection.transform;
                    if (selectabledrag != null)
                    {
                        crosshair.SetActive(true);
                    }
                    _selection = selection;
                }
            }
        }
    }
}
