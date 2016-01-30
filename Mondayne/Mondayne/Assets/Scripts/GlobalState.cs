using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalState {

	public static Dictionary<int, Event> events = new Dictionary<int, Event>();
	public static int current = 0;

	public static void testMethod() {
		Debug.Log("accessed static global");
	}
}
