using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTime : MonoBehaviour {

	public Transform canvasTime;
	public Text stringa;

	void Update ()
	{
		stringa.GetComponent <Text> ().text = System.DateTime.Now.ToString ();
	}
}
