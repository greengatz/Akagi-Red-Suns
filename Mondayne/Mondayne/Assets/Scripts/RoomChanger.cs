using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoomChanger : MonoBehaviour {

	public string transition = "next scene";

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	

		Collider2D[] nearDest = Physics2D.OverlapCircleAll(GetComponent<Transform>().position, GlobalState.doorRange);
		for (int i = 0; i < nearDest.Length; i++)
		{
			Collider2D near = nearDest [i];

			if (!gameObject.Equals(near.gameObject) && near.gameObject.CompareTag("Player"))
			{
				nearDest[i].gameObject.SendMessage("selected");
				Debug.Log("changing scene to " + transition);
				//SceneManager.GetSceneByName (transition);
				//SceneManager.SetActiveScene (SceneManager.GetSceneByName (transition));
				SceneManager.LoadScene (transition);
			}
		}
	}
}
