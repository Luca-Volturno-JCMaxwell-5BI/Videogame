using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour{

	public Transform dialogCanvas;
	public Text nameNPC;
	public Text dialogText;

	void Update()
	{
		Dialog ();
	}

	void Dialog()
	{
		if (Player.isNPCTouched) {
			nameNPC.GetComponent<Text> ().text = Player.npcName;
			dialogCanvas.gameObject.SetActive (true);
		} else {
			dialogCanvas.gameObject.SetActive (false);
		}

	}
		
}
