using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalState {

	public static Dictionary<int, Event> events = new Dictionary<int, Event>();
	public static int current = 0;

	public static string toDisplay = "idk what to do man";

	public static void testMethod() {
		Debug.Log("accessed static global");
	}
}
