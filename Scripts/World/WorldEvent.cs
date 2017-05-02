using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEvent : MonoBehaviour {

	public Transform recintoTaverna;

	// Use this for initialization

	void Start () {
		recintoTaverna = Instantiate (recintoTaverna, new Vector3 (0, 0, 0), Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
