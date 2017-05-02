using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public Transform canvasPause;
	public Transform canvasPauseMenu;
	public Transform canvasAudioMenu;
	public Transform canvasVideoMenu;

	public AudioSource audioSource;

	public GameObject player;

	void Start()
	{
		canvasPause.gameObject.SetActive (false);
		canvasPauseMenu.gameObject.SetActive (false);
		canvasAudioMenu.gameObject.SetActive (false);
		canvasVideoMenu.gameObject.SetActive (false);
		audioSource.volume = 0.5f;
	}

	void Update ()
	{
		PauseWorld ();
	}

	public void PauseWorld()
	{
		if(Input.GetKeyDown(KeyCode.Escape)) // Se il tasto esc è stato premuto
		{
			if (canvasPause.gameObject.activeInHierarchy == false) // Guarda la gerarchia e vedi se c'è il canvas di pausa disattivato
			{
				canvasPause.gameObject.SetActive (true); // Attivo il canvas di pausa (background)
				canvasPauseMenu.gameObject.SetActive (true); // Attivo il canvas del menu di pausa
				Time.timeScale = 0; // Metti in pausa il mondo
				player.GetComponent<Player> ().velocita = 0; // Setto la velocità a 0, cosi il player si blocca istantaneamente, altrimenti andrebbe avanti anche se in pausa fino a finire il movimento

			} else // Se invece il canvas di pausa è già attivo
			{
				canvasPause.gameObject.SetActive (false); // Lo disattivo
				canvasPauseMenu.gameObject.SetActive (true); // Disattivo anche il canvas del menu di pausa all'interno del canvas
				Time.timeScale = 1; // Tolgo la pausa al mondo
				player.GetComponent<Player> ().velocita = 0.20f; // Setto la velocità alla sua velocita standard
			}
		}
	}

	public void Resume() // Se il tasto riprendi è stato premuto, mentre il canvas è attivo
	{
		canvasPause.gameObject.SetActive (false); // Disattivo il canvas di pausa 
		canvasPauseMenu.gameObject.SetActive (false); // Disattivo il canvas del menu di pausa
		canvasAudioMenu.gameObject.SetActive (false); // Disattivo il canvas del menu audio
		canvasVideoMenu.gameObject.SetActive (false); // Disattivo il Canvas del menu video
		Time.timeScale = 1; // Tolgo la pausa al mondo
		player.GetComponent<Player> ().velocita = 0.20f; // Setto la velocità alla sua velocità standard
	}

	public void AudioMenu()
	{
		canvasPauseMenu.gameObject.SetActive (false);
		canvasAudioMenu.gameObject.SetActive (true);

	}
		
	public void BackFromAudioMenu()
	{
		canvasAudioMenu.gameObject.SetActive (false);
		canvasPauseMenu.gameObject.SetActive (true);
	}
		
	public void VideoMenu()
	{
		canvasPauseMenu.gameObject.SetActive (false);
		canvasVideoMenu.gameObject.SetActive (true);

	}
		
	public void BackFromVideoMenu()
	{
		canvasVideoMenu.gameObject.SetActive (false);
		canvasPauseMenu.gameObject.SetActive (true);
	}

	public void ExitWorld()
	{
		Application.Quit ();
	}

	public void ScreenSize(int size)
	{
		switch (size)
		{
		case 0:
			Screen.SetResolution (1920, 1080, true);
			break;

		case 1:
			Screen.SetResolution (1600, 900, true);
			break;

		case 2:
			Screen.SetResolution (1280, 1024, true);
			break;
		}
	}

	public void Volume(float volume)
	{
		audioSource.volume = volume;

	}


}
