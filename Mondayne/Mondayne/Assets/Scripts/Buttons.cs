using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void changeLevel (string next) {
		SceneManager.LoadScene (next);
	}

	public void quitGame () {
		Application.Quit ();
	}
}
