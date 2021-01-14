using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor1: MonoBehaviour {

	[SerializeField] private AudioClip ClosingSound;
	[SerializeField] private AudioClip OpeningSound;
	[SerializeField] private AudioSource thisAudio;
	public Animator openandclose1;
	public bool DoorIsOpen;
	public Transform Player;


	void Start ()
	{
		DoorIsOpen = false;
	}

	void OnMouseOver ()
	{
		{
			if (Player)
			{
				float dist = Vector3.Distance (Player.position, transform.position);
				if (dist < 2.5)
				{
					if (DoorIsOpen == false)
					{
						if (Input.GetMouseButtonDown (0))
						{
							StartCoroutine (opening ());
						}
					}
					
					else
					{
						if (DoorIsOpen == true)
						{
							if (Input.GetMouseButtonDown (0))
							{
								StartCoroutine (closing ());
							}
						}
					}
				}
			}
		}
	}

	IEnumerator opening()
	{
		openandclose1.Play ("Opening 1");
		thisAudio.clip = OpeningSound;
		thisAudio.Play();
		DoorIsOpen = true;
		yield return new WaitForSeconds (0.5f);
	}

	IEnumerator closing()
	{
		openandclose1.Play ("Closing 1");
		thisAudio.clip = ClosingSound;
		thisAudio.Play();
		DoorIsOpen = false;
		yield return new WaitForSeconds (0.5f);
	}
}