using UnityEngine;
using System.Collections;

public class VisibilitySwitch : MonoBehaviour {

	public SpriteRenderer sprite = null;
	public BoxCollider2D collider = null;
	public Animator anim = null;
	public int makeVisible = 0;
	public int makeInvisible = 0;

	// Use this for initialization
	void Start () {
		if (GlobalState.run < makeVisible || GlobalState.run >= makeInvisible) {
			if (this.sprite != null) {
				this.sprite.enabled = false;
			}
			if (this.anim != null) {
				this.anim.enabled = false;
			}
			if (this.collider != null) {
				this.collider.enabled = false;
			}
		} else {
			if (this.sprite != null) {
				this.sprite.enabled = true;
			}
			if (this.anim != null) {
				this.anim.enabled = true;
			}
			if (this.collider != null) {
				this.collider.enabled = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
