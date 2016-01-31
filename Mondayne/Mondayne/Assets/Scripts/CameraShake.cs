using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	public float shakeAmount = 0.25f;
	public float decreaseFactor = 1.0f;

	private new Camera camera;
	private Vector2 cameraPos;
	private float shake = 0.0f;

	// Use this for initialization
	void Start () {
		this.camera = this.GetComponent<Camera> ();
		if (this.camera == null) {
			Debug.Log ("Camera not found");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.shake > 0.0f) {
			Vector2 newPos = Random.insideUnitCircle * this.shakeAmount;
			this.camera.transform.localPosition = new Vector3(newPos.x, newPos.y, this.camera.transform.localPosition.z);
			this.shake -= Time.deltaTime * this.decreaseFactor;

			if (this.shake <= 0.0f) {
				this.shake = 0.0f;
				this.camera.transform.localPosition = new Vector3(this.cameraPos.x, this.cameraPos.y, this.camera.transform.localPosition.z);
			}
		}
	}
		

	public void Shake(float amount) {
		if (this.shake <= 0.0f) {
			this.cameraPos = this.camera.transform.position;
		}
		this.shake = amount;
	}
}
