using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	private Image healthBar;
	private Image healthBarBackground;
	public float health = 200;

	public float attack = 5f;
	private GameObject player;
	private float minDistanceFromPlayer = 1.2f;
	private int maxDistanceFromPlayer = 5;
	private int moveSpeed = 2;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		healthBar = Image.FindObjectOfType<Image> ();
		healthBar.gameObject.SetActive (false);
		healthBarBackground = Image.FindObjectOfType<Image> ();
		healthBarBackground.gameObject.SetActive (false);
	}

	void Update()
	{
		HealthChecker ();
		playerChasing ();
	}

	void HealthChecker()
	{
		healthBar.rectTransform.localScale = new Vector3 (health / 100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
		if (Player.isEnemyInFront) {
			healthBar.gameObject.SetActive (true);
			healthBarBackground.gameObject.SetActive (true);
		} else {
			healthBar.gameObject.SetActive (false);
			healthBarBackground.gameObject.SetActive (false);
		}
			
		if (health <= 0.0f) 
		{
			gameObject.SetActive (false);
		}

	}

	public void SubtractHealth(float amount)
	{
		if (health <= 0) {
			health = 0;

		} else {
			health -= amount;
			Debug.Log ("Vita: " + health);
		}
	}

	void playerChasing()
	{
		if ((Vector3.Distance (transform.position, player.transform.position) >= minDistanceFromPlayer) && (Vector3.Distance (transform.position, player.transform.position) <= maxDistanceFromPlayer)) {
			transform.LookAt (player.transform.position);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		} else {
			transform.position = transform.position;
		}
			
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag ("Player")) {
			Player.SubtractHealth (attack);
		}
	}

}
