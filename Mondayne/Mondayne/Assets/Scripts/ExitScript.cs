using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	public float doorRange = 0.3f;
	public string transition = "next scene";
	public int lastRun = 5;
	public string endTrans = "Outro";

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		Collider2D[] nearDest = Physics2D.OverlapCircleAll(GetComponent<Transform>().position, doorRange);
		for (int i = 0; i < nearDest.Length; i++)
		{
			Collider2D near = nearDest [i];

			if (!gameObject.Equals(near.gameObject) && near.gameObject.CompareTag("Player"))
			{
				// TODO
				// reset state
				// progress day counter information
				Debug.Log("Resetting Day");

				GlobalState.current = 0;
				GlobalState.events.Clear ();
				GlobalState.run++;

				Debug.Log (GlobalState.run);
				Debug.Log (GlobalState.switchMusic);
				if(GlobalState.run == GlobalState.switchMusic) {
					GlobalState.music1.Stop ();
					GlobalState.music2.Play ();
				}

				if (GlobalState.run != lastRun) {
					SceneManager.LoadScene (transition);
				} else {
					GlobalState.music1.Stop ();
					GlobalState.music2.Stop ();
					SceneManager.LoadScene (endTrans);
				}
			}
		}
	}
}
