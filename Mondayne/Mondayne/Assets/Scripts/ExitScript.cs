﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	public float doorRange = 0.3f;
	public string transition = "next scene";

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

				SceneManager.LoadScene (transition);
			}
		}
	}
}