using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class StartMenu : MonoBehaviour {

	public void EnterWorld()
	{
		SceneManager.LoadScene ("World", LoadSceneMode.Single);
	}

	public void ExitWorld()
	{
		SceneManager.LoadScene ("Exit", LoadSceneMode.Single);
	}
}
