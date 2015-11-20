using UnityEngine;
using System.Collections;

public class Stick : Item {

	public float range = 0.3f;

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}

	protected override void CheckInputs() {
		if(Input.GetButtonDown("Fire")) {
			Hit();
		}
	}

	private void Hit() {
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(trans.position, trans.forward, out hit, range)) {
			GameObject objectHit = hit.collider.gameObject;
			if(objectHit.CompareTag("Rock")) {
				Rigidbody body = objectHit.GetComponent<Rigidbody>();
				if(body != null) {
					body.isKinematic = false;
					float force = 2000;
					body.AddForceAtPosition(trans.right * -force, hit.point);
				}
			}
		}
	}
}
