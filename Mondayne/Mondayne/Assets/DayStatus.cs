using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DayStatus : MonoBehaviour {

	public List<GameObject> toDo = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] arrayForm = toDo.ToArray ();
		if(arrayForm.Length > 0) {
			GameObject eve = arrayForm[0];
			/*
			if(eve.SendMessage("")) {
				//asdf
			}
			*/
		}
	}
}
