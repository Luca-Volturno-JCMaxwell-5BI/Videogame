using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	Animator animator;
	bool doorOpen;
	bool doorIdle;

	void Start()
	{
		doorOpen = false;
		doorIdle = false;
		animator = GetComponent<Animator> ();
	}

	void Update()
	{

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("CIAO");
			doorOpen = true;
			doorIdle = false;
			DoorControl ("Open");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (doorOpen) {
			doorOpen = false;
			DoorControl ("Close");
			doorIdle = true;
		}

		if (doorIdle) {
			DoorControl ("Idle");
		}
	}

	void DoorControl(string action)
	{
		animator.SetTrigger (action);
	}
}
