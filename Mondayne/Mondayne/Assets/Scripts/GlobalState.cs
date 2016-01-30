using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalState {

	public static Dictionary<int, Event> events = new Dictionary<int, Event>();
	public static int current = 0;

	public static float speed = 3.0f;
	public static float doorRange = 0.2f;

	public static string toDisplay = "idk what to do man";

	public static void testMethod() {
		Debug.Log("accessed static global");
	}
}
