using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	public float velocita; // Velocità del personaggio
	private float attack = 30f;

	private int rayLength = 2;	//Distanza del raggio che rileva la vicinanza di un NPC o di un Evento

	//HPSystem
	public Image healthBar; // UI - Barra degli HP
	public static float health = 100; // Vita del personaggio compresa tra 0 e 100
	//---------------------

	//NPC near the player
	public static string npcName;
	public static bool isNPCTouched = false;
	//---------------------------------------


	//Enemy near the player
	public static bool isEnemyTouched = false;
	public static bool isEnemyInFront = false;



	void Start ()
	{
		
		velocita = 0.20f; //Imposto la velocità iniziale a 0.20
		gameObject.GetComponent<Rigidbody> ().freezeRotation = true; //Blocco ogni rotazione in tutti gli assi

	}
	
	// Update is called once per frame
	void Update ()
	{
		HealthChecker ();
		Movement ();
		CharacterRaycast ();

	}

	void CharacterRaycast()
	{
		RaycastHit hit; 

		Vector3 forward = transform.TransformDirection (Vector3.forward);

		if (Physics.Raycast (transform.position, forward, out hit, rayLength)) {
			if (hit.collider.gameObject.tag == "Enemy") {
				isEnemyInFront = true;
				if (Input.GetMouseButtonDown (0) && isEnemyTouched == false) {
					isEnemyTouched = true;
					Debug.Log ("Toccato il nemico: " + hit.collider.gameObject.name);
					hit.collider.gameObject.GetComponent<Enemy> ().SubtractHealth (attack);
				} 

				if (Input.GetMouseButtonUp (0)) {
					isEnemyTouched = false;
				}
			}

			if (hit.collider.gameObject.tag == "NPC") { // 
				if (Input.GetKeyDown (KeyCode.E)) {
					isNPCTouched = true;	
					npcName = hit.collider.gameObject.name;
				}
			}
				
		} else {
			isNPCTouched = false;
			isEnemyInFront = false;
		}
	}

	void Movement()
	{
		float orizzontale = Input.GetAxis ("Horizontal") * velocita;
		transform.Translate (Vector3.right * orizzontale);

		float avanti = Input.GetAxis ("Vertical") * velocita;
		transform.Translate (Vector3.forward * avanti);

		if (gameObject.GetComponent<Transform> ().localPosition.y > 1) {
			gameObject.GetComponent<Transform> ().position.y--;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			velocita = 0.25f;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			velocita = 0.20f;
		}
			
	}

	void HealthChecker()
	{
		healthBar.rectTransform.localScale = new Vector3 (health / 100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
		if (health <= 0.0f) {
			//Morte del personaggio
		}
			
	}
		
	void AddHealth(float amount)
	{
		if (health + amount >= 100) {
			health = 100;
		} else {
			health += amount;
		}

	}

	public static void SubtractHealth(float amount)
	{
		if (health - amount <= 0) {
			health = 0.0f;
		} else {
			health -= amount;
		}
	}
				

}


