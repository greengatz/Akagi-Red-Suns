using UnityEngine;
using System.Collections;

public class VisibilitySwitch : MonoBehaviour {

	public SpriteRenderer sprite;
	public BoxCollider2D collider;
	public int makeVisible = 0;
	public int makeInvisible = 0;

	// Use this for initialization
	void Start () {
		if (GlobalState.run < makeVisible || GlobalState.run >= makeInvisible) {
			sprite.enabled = false;
			this.collider.enabled = false;
		} else {
			sprite.enabled = true;
			this.collider.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
