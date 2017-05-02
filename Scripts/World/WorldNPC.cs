using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNPC : MonoBehaviour {


	public Transform OsvaldoNPC; // Prefab di Osvaldo, il bartender
	public Transform SpiderEnemy; //

	void Start ()
	{

		OsvaldoNPC = Instantiate (OsvaldoNPC, new Vector3 (420, 14, 320), Quaternion.identity);
		OsvaldoNPC.gameObject.name = "Osvaldo";

		SpiderEnemy = Instantiate (SpiderEnemy, new Vector3 (503, 9f, 197), Quaternion.identity);
		SpiderEnemy.gameObject.name = "Ragno";


	}

}
