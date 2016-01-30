using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalState {

	public static Dictionary<int, Event> events = new Dictionary<int, Event>();
	public static int current = 0;
	public static int run = 0;

	public static float speed = 3.0f;
	public static float doorRange = 0.2f;

	public static AudioSource music1 = null;
	public static AudioSource music2 = null;
	public static int switchMusic = -1;

	public static bool characterActing = false;
	public static bool characterVis = true;

	public static string toDisplay = "idk what to do man";

	public static void testMethod() {
		Debug.Log("accessed static global");
	}
}
