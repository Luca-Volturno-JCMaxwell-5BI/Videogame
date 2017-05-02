using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	public void ReturnToStart()
	{
		SceneManager.LoadScene ("MenuPrincipale", LoadSceneMode.Single);
	}

	public void ReturnToWorld()
	{
		SceneManager.LoadScene ("World", LoadSceneMode.Single);
	}

	public void ExitWorld()
	{
		Application.Quit ();
	}
}
